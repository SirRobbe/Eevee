namespace Eevee
{
    public partial class CSharpWriter
    {
        public sealed class Constructor : IDisposable
        {
            public Constructor(CSharpWriter writer, string name,
                               AccessModifier accessModifier = AccessModifier.Public,
                               string[] parameters = null,
                               string baseConstructor = null)
            {
                m_Writer = writer;
                string parametersStr = string.Join(", ", parameters ?? Array.Empty<string>());
                baseConstructor = baseConstructor == null ? "" : $" : {baseConstructor}()";

                m_Writer.WriteLine($"{accessModifier.ToString().ToLower()} {name}({parametersStr}){baseConstructor}");
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