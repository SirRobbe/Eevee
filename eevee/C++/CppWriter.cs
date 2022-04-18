namespace Eevee;

public partial class CppWriter : CodeWriter
{
    public CppWriter(string fileHeaderContent = "") : base(fileHeaderContent) {}
    
    public void Include(params string[] files)
    {
        foreach(string file in files)
        {
            m_StringBuilder.AppendLine($"#include {file}");
        }
    }

    public void Macro(string name, string evaluation, string[] arguments = null)
    {
        string args = arguments == null ? "" : string.Join(", ", arguments);
        m_StringBuilder.AppendLine($"#define {name}({args}) {evaluation}");
    }
    
    
}