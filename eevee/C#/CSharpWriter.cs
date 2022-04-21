namespace Eevee;

public partial class CSharpWriter : CodeWriter
{
    public CSharpWriter(string fileHeaderContent = "") : base(fileHeaderContent) {}
    
    public void UsingNamespaces(params string[] namespaces)
    {
        foreach(string @namespace in namespaces)
        {
            WriteLine($"using {@namespace};");
        }
    }
    
    private string MakeInterfacesDefinition(string[] interfaces)
    {
        string result = "";

        if(interfaces != null)
        {
            result = " : " + string.Join(", ", interfaces);
        }

        return result;
    }
}