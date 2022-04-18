namespace Evee
{
    public sealed partial class CodeWriter
    {
        public sealed class ClassScope : IDisposable
        {
            public ClassScope(CodeWriter writer, string className,
                              AccessModifier accessModifier = AccessModifier.Public,
                              bool isSealed = true,
                              bool isAbstract = false,
                              bool isPartial = false,
                              string[] interfaces = null)
            {
                m_Writer = writer;
                m_Writer.BeginClass(className, interfaces, accessModifier, isSealed,
                                    isAbstract,
                                    isPartial);
            }

            public void Dispose()
            {
                m_Writer.EndClass();
            }

            private readonly CodeWriter m_Writer;
        }    
    }    
}

