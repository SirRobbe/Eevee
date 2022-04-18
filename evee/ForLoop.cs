namespace Evee
{
    public sealed partial class CodeWriter
    {
        public sealed class ForLoop : IDisposable
        {
            public ForLoop(CodeWriter writer, string initialization, string condition, string afterthought)
            {
                m_Writer = writer;
                m_Writer.WriteLine($"for({initialization};{condition};{afterthought})");
                m_Writer.BeginBlock();
            }

            public void Dispose()
            {
                m_Writer.EndBlock();
            }

            private readonly CodeWriter m_Writer;
        }    
    }    
}