namespace Evee
{
    public sealed partial class CodeWriter
    {
        public sealed class InterfaceScope : IDisposable
        {
            public InterfaceScope(CodeWriter writer, string name,
                                  AccessModifier accessModifier = AccessModifier.Public,
                                  string[] generics = null)
            {
                m_Writer = writer;
                
                string genericsStr = generics == null ? "" : $"<{string.Join(", ", generics)}>";
                m_Writer.WriteLine($"{accessModifier.ToString().ToLower()} interface {name}{genericsStr}");
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