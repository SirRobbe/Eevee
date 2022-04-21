namespace Eevee
{
    public partial class CodeWriter
    {
        public sealed class Else : IDisposable
        {
            public Else(CSharpWriter writer)
            {
                m_Writer = writer;
                m_Writer.WriteLine("else");
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