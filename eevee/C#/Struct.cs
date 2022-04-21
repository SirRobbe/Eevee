namespace Eevee;

public partial class CSharpWriter
{
    public sealed class Struct : IDisposable
    {
        public Struct(CSharpWriter writer, string name, string[] interfaces = null,
                      AccessModifier accessModifier = AccessModifier.Public)
        {
            m_Writer = writer;
            m_Writer.WriteLine($"{accessModifier.ToString().ToLower()} struct {name}" +
                               $"{m_Writer.MakeInterfacesDefinition(interfaces)}");
            m_Writer.BeginBlock();
        }

        public void Dispose()
        {
            m_Writer.EndBlock();
        }

        private readonly CSharpWriter m_Writer;
    }    
}