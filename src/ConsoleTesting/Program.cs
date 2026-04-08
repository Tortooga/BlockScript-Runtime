using System.Reflection.Metadata.Ecma335;
using System.Text;
using BlockScript;

ProgramEnvironment programEnvironment = new ProgramEnvironment(1);

BindingMetaData bindingMetaData = new BindingMetaData(0, ObjectType.IntType, false);

programEnvironment.Bindings.Add("x", bindingMetaData);

Console.WriteLine(TypeEncoder.Encode(ObjectType.FloatType, 3.14f));