using System.Reflection.Metadata.Ecma335;
using System.Text;
using BlockScript;

ProgramEnvironment programEnvironment = new ProgramEnvironment(2);

Console.WriteLine(programEnvironment.DefineVar(
    "hello", ObjectType.IntType
));

TestingTool.PrintEnvironment(programEnvironment);
