namespace Eevee
{
    public partial class CSharpWriter
    {
        public sealed class Namespace : IDisposable
        {
            public Namespace(CSharpWriter writer, string name)
            {
                m_Writer = writer;
                m_Writer.WriteLine($"namespace {name}");
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