using System.Reflection.Metadata.Ecma335;
using System.Text;
using BlockScript;

ProgramEnvironment programEnvironment = new ProgramEnvironment(5);

Console.WriteLine(programEnvironment.DefineVar(
    $"hello", ObjectType.IntType
));    

TestingTool.PrintMemory(programEnvironment.EnvironmentMemory);

TestingTool.PrintEnvironment(programEnvironment);
