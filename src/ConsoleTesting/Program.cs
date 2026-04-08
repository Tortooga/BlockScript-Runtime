using System.Reflection.Metadata.Ecma335;
using System.Text;
using BlockScript;

ProgramEnvironment programEnvironment = new ProgramEnvironment(2);

BindingMetaData bindingMetaData = new BindingMetaData(0, ObjectType.IntType, false);

programEnvironment.Bindings.Add("x", bindingMetaData);

Console.WriteLine(programEnvironment.DefineVar(
    "hello", ObjectType.IntType
));

Console.WriteLine(programEnvironment.Bindings["hello"].ToString());
