using System.Text;

namespace Eevee
{
    public partial class CodeWriter
    {
        protected CodeWriter(string fileHeaderContent = "")
        {
            FileHeaderContent = fileHeaderContent;
            m_StringBuilder = new StringBuilder(FileHeaderContent);
            NewLine();
        }

        public string GetCode() => m_StringBuilder.ToString();
        
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

        private void WriteIndentation()
        {
            int indents = IndentLevel * 4;
            for(int i = 0; i < indents; i++)
            {
                m_StringBuilder.Append(' ');
            }
        }

        public string FileHeaderContent;
        public int IndentLevel;
        
        protected readonly StringBuilder m_StringBuilder;
    }
}