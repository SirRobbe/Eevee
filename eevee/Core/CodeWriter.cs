using System.Text;

namespace Eevee
{
    public partial class CodeWriter
    {
        public CodeWriter(string fileHeaderContent = "")
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
        
        public void BeginIf(string condition)
        {
            WriteLine($"if({condition})");
            BeginBlock();
        }

        public void BeginElse()
        {
            WriteLine("else");
            BeginBlock();
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

        // TODO(Fabian): These functions need a scoped class. - Issue#1
        // ---------------------------------------------------------------------------------------------------------- //
        // NOTE(Fabian): The End-Methods are just wrappers around EndBlock to make the
        //               generation code using the API more readable.
        public void EndIf() => EndBlock();
        public void EndElse() => EndBlock();
        // ---------------------------------------------------------------------------------------------------------- //
        
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