using System.Text;

namespace Eevee
{
    public partial class CodeWriter
    {
        public CodeWriter(string fileHeaderContent = "")
        {
            FileHeaderContent = fileHeaderContent;
            m_StringBuilder = new StringBuilder(FileHeaderContent);
            NewLine();
        }

        public void Clear()
        {
            IndentLevel = 0;
            m_StringBuilder.Clear();
            m_StringBuilder.AppendLine(FileHeaderContent);
        }

        public void NewLine()
        {
            m_StringBuilder.AppendLine("");
        }
        
        public void UsingNamespaces(params string[] namespaces)
        {
            foreach(string @namespace in namespaces)
            {
                WriteLine($"using {@namespace};");
            }
        }
        
        public void BeginNamespace(string name)
        {
            WriteLine($"namespace {name}");
            BeginBlock();
        }
        
        public void BeginIf(string condition)
        {
            WriteLine($"if({condition})");
            BeginBlock();
        }

        public void BeginElse()
        {
            WriteLine("else");
            BeginBlock();
        }

        public void BeginForeach(string elementName, string collectionName,
                                 string elementType = null)
        {
            WriteLine($"foreach({elementType ?? "var"} {elementName} in {collectionName})");
            BeginBlock();
        }

        public void BeginStruct(string name, string[] interfaces = null,
                                AccessModifier accessModifier = AccessModifier.Public)
        {
            WriteLine($"{accessModifier.ToString().ToLower()} struct {name}" +
                      $"{MakeInterfacesDefinition(interfaces)}");
            BeginBlock();
        }

        public void BeginClass(string name, string[] interfaces = null,
                               AccessModifier accessModifier = AccessModifier.Public,
                               bool isSealed = false,
                               bool isAbstract = false,
                               bool isPartial = false)
        {
            string accessTypeStr = accessModifier.ToString().ToLower();
            string classAnnotations = $"{(isSealed ? " sealed " : "")}{(isAbstract ? " abstract " : "")}" +
                                      $"{(isPartial ? " partial " : "")}";
            
            WriteLine($"{accessTypeStr} {classAnnotations} class {name}{MakeInterfacesDefinition(interfaces)}");
            BeginBlock();
        }

        public void BeginConstructor(string name,
                                     AccessModifier accessModifier = AccessModifier.Public,
                                     string[] parameters = null,
                                     string baseConstructor = null)
        {
            string parametersStr = string.Join(", ", parameters ?? Array.Empty<string>());
            baseConstructor = baseConstructor == null ? "" : $" : {baseConstructor}()";

            WriteLine($"{accessModifier.ToString().ToLower()} {name}({parametersStr}){baseConstructor}");
            BeginBlock();
        }

        public void BeginMethod(string name, string[] parameters = null,
                                AccessModifier accessModifier = AccessModifier.Public,
                                bool isPartial = false,
                                string modifier = "",
                                string returnType = "void")
        {
            string parametersStr = string.Join(", ", parameters ?? Array.Empty<string>());
            WriteLine($"{(isPartial ? "partial ": "")} {accessModifier.ToString().ToLower()} {modifier} " +
                      $"{returnType} {name}({parametersStr})");
            BeginBlock();
        }

        public void WriteLine(string line)
        {
            WriteIndentation();
            m_StringBuilder.AppendLine(line);
        }

        public void BeginBlock()
        {
            WriteIndentation();
            m_StringBuilder.AppendLine("{");
            IndentLevel++;
        }

        public void EndBlock(bool withSemicolon = false)
        {
            IndentLevel--;
            WriteIndentation();
            string line = withSemicolon ? "};" : "}";
            m_StringBuilder.AppendLine(line);
        }

        // ---------------------------------------------------------------------------------------------------------- //
        // NOTE(Fabian): The End-Methods are just wrappers around EndBlock to make the
        // generation code using the API more readable
        
        public void EndForeach() => EndBlock();
        public void EndIf() => EndBlock();
        public void EndElse() => EndBlock();
        public void EndMethod() => EndBlock();
        public void EndConstructor() => EndBlock();
        public void EndClass() => EndBlock();
        public void EndStruct() => EndBlock();
        public void EndNamespace() => EndBlock();
        // ---------------------------------------------------------------------------------------------------------- //
        
        private void WriteIndentation()
        {
            int indents = IndentLevel * 4;
            for(int i = 0; i < indents; i++)
            {
                m_StringBuilder.Append(' ');
            }
        }

        private string MakeInterfacesDefinition(string[] interfaces)
        {
            string result = "";

            if(interfaces != null)
            {
                result = " : " + string.Join(", ", interfaces);
            }

            return result;
        }

        public string GetCode() => m_StringBuilder.ToString();

        public string FileHeaderContent = "";
        public int IndentLevel;
        
        protected readonly StringBuilder m_StringBuilder;
    }
}