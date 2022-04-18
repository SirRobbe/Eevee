namespace Eevee;

public partial class CppWriter
{
    public class Struct : IDisposable
    {
        public Struct(CodeWriter writer, string name)
        {
            m_Writer = writer;
            m_Writer.WriteLine($"struct {name}");
            m_Writer.BeginBlock();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                m_Writer.EndBlock(true);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private readonly CodeWriter m_Writer;
    }
}