namespace Eevee;

public partial class CppWriter
{
    public class Function : IDisposable
    {
        public Function(CodeWriter writer, string name, string returnType = "void",
                        string prefix = "",
                        string[] arguments = null)
        {
            string args = arguments == null ? "" : string.Join(", ", arguments);
            
            m_Writer = writer;
            m_Writer.WriteLine($"{prefix} {returnType} {name}({args})");
            m_Writer.BeginBlock();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                m_Writer.EndBlock();
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