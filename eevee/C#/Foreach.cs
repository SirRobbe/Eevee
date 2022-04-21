namespace Eevee;

public partial class CSharpWriter
{
    public sealed class Foreach : IDisposable
    {
        public Foreach(CSharpWriter writer, string elementName, string collectionName,
                       string elementType = null)
        {
            m_Writer = writer;
            m_Writer.WriteLine($"foreach({elementType ?? "var"} {elementName} in {collectionName})");
            m_Writer.BeginBlock();
        }

        public void Dispose()
        {
            m_Writer.EndBlock();
        }

        private readonly CSharpWriter m_Writer;
    }    
}