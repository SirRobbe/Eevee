namespace Eevee;

public partial class CSharpWriter
{
    public sealed class Class : IDisposable
    {
        public Class(CSharpWriter writer, string name, string[] interfaces = null,
                     AccessModifier accessModifier = AccessModifier.Public,
                     bool isSealed = false,
                     bool isAbstract = false,
                     bool isPartial = false)
        {
            m_Writer = writer;
            string accessTypeStr = accessModifier.ToString().ToLower();
            string classAnnotations = $"{(isSealed ? " sealed " : "")}{(isAbstract ? " abstract " : "")}" +
                                      $"{(isPartial ? " partial " : "")}";
            
            m_Writer.WriteLine($"{accessTypeStr} {classAnnotations} class " +
                               $"{name}{m_Writer.MakeInterfacesDefinition(interfaces)}");
            m_Writer.BeginBlock();
        }

        public void Dispose()
        {
            m_Writer.EndBlock();
        }

        private readonly CSharpWriter m_Writer;
    }    
}