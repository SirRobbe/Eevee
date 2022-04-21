namespace Eevee
{
    public partial class CodeWriter
    {
        public sealed class If : IDisposable
        {
            public If(CSharpWriter writer, string condition)
            {
                m_Writer = writer;
                m_Writer.WriteLine($"if({condition})");
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