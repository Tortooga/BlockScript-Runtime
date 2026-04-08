using BlockScript;

ProgramEnvironment programEnvironment = new ProgramEnvironment(1);

BindingMetaData bindingMetaData = new BindingMetaData(0, ObjectType.IntType, false);

programEnvironment.Bindings.Add("x", bindingMetaData);

Console.WriteLine(programEnvironment.ValidateIdentifier("x"));