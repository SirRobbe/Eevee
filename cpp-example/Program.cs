using Eevee;

// A file header will always be placed at the start of any file
const string fileHeader = @"// Attention! This file was automatically generated.
// Formatting was done with the Eevee library. Don't change the content of this file.
// Instead always change the generation code if logic of this file needs to change.
// If the generated code has errors, first check if the code generation is correct,
// otherwise report the issue on the Eevee github page.";


var writer = new CppWriter(fileHeaderContent: fileHeader);

writer.NewLine();
writer.Include("<stdio.h>");
writer.NewLine();

using(new CppWriter.Struct(writer, "ExampleStruct"))
{
    writer.WriteLine("int MemberA;");
    writer.WriteLine("float MemberB;");
}

writer.NewLine();

using(new CppWriter.Function(writer, "Add", "int", arguments:new []{"int a, int b"}))
{
    writer.WriteLine("return a + b;");
}
    
writer.NewLine();

using(new CppWriter.Function(writer, "PrintBoringStuff"))
{
    using(new CppWriter.ForLoop(writer, "int i = 0", "i < 100", "i++"))
    {
        writer.WriteLine(@"printf(""%d\n"", i);");
    }
}

// Prints the generated code to console for this example. Usually you would like to
// write the code to some file source file that will be included into your project.
Console.WriteLine(writer.GetCode());