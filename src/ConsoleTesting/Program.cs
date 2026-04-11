using System.Reflection.Metadata.Ecma335;
using System.Text;
using BlockScript;

ProgramEnvironment programEnvironment = new ProgramEnvironment(7);


DefineVarStatusCode status = programEnvironment.DefineVar("hello", ObjectType.IntType);

TestingTool.PrintEnvironment(programEnvironment);

TestingTool.PrintMemory(programEnvironment.EnvironmentMemory);