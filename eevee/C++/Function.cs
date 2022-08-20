using System.Text;

namespace Eevee;

public partial class CppWriter
{
    public sealed class Function : IDisposable
    {
        public Function(CodeWriter writer, string name, string returnType = "void",
                        string prefix = "",
                        string[] arguments = null)
        {
            string args = arguments == null ? "" : string.Join(", ", arguments);

            var builder = new StringBuilder(64);

            if(!string.IsNullOrEmpty(prefix))
            {
                builder.Append($"{prefix} ");
            }

            builder.Append($"{returnType} {name}({args})");
            
            m_Writer = writer;
            m_Writer.WriteLine(builder.ToString());
            m_Writer.BeginBlock();
        }

        public void Dispose()
        {
            m_Writer.EndBlock();
        }

        private readonly CodeWriter m_Writer;
    }
}