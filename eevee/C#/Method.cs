namespace Eevee
{
    public partial class CSharpWriter
    {
        public sealed class Method : IDisposable
        {
            public Method(CSharpWriter writer, string name, string[] parameters = null,
                          AccessModifier accessModifier = AccessModifier.Public,
                          bool isPartial = false,
                          string modifier = "",
                          string returnType = "void")
            {
                m_Writer = writer;
                string parametersStr = string.Join(", ", parameters ?? Array.Empty<string>());
                m_Writer.WriteLine($"{(isPartial ? "partial ": "")} {accessModifier.ToString().ToLower()} {modifier} " +
                          $"{returnType} {name}({parametersStr})");
                m_Writer.BeginBlock();
            }

            public void Dispose()
            {
                m_Writer.EndBlock();
            }

            private readonly CSharpWriter m_Writer;
        }    
    }
}