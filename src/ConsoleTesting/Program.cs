using System.Reflection.Metadata.Ecma335;
using System.Text;
using BlockScript;

ProgramEnvironment programEnvironment = new ProgramEnvironment(5);

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(programEnvironment.DefineVar(
        $"hello{i}", ObjectType.IntType
    ));    
}

TestingTool.PrintEnvironment(programEnvironment);
