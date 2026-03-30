namespace BlockScript;

public class ProgramEnvironment
{
    public ProgramMemory Memory {get; set;}
    public Dictionary<String,  BindingMetaData> Bindings {get; set;}

    public ProgramEnvironment(ProgramMemory Memory)
    {
        this.Memory = Memory;
        this.Bindings = new Dictionary<string, BindingMetaData>();
    } 

    public DefineVarStatusCode DefineVar(string name, ObjectType type, object? initialValue = null)
    {
        int? index = AllocateIndex();
        if (index == null)
        {
            return DefineVarStatusCode.OutOfMemory;
        }

        //TODO Implement Identifier validation
        //TODO Implement Type Validation

        //TODO Implement Binding and initialisation
        return DefineVarStatusCode.Success;
    }

    private int? AllocateIndex()
    {
        int index = 0; 

        //Finding the last index allocated
        foreach (var binding in Bindings)
        {
            if (binding.Value.Index > index)
            {
                index = binding.Value.Index;
            }
        }
        index++;

        if (index > Memory.Size - 1)
        {
            return null;
        }

        return index;
    }
}

public class BindingMetaData
{
    public int Index{get; init;}
    public ObjectType BindingType{get; init;}
    public bool IsInitialised{get; set;}

    public BindingMetaData(int Index, ObjectType BindingType, bool IsInitialised)
    {
        this.Index = Index;
        this.BindingType = BindingType;
        this.IsInitialised = false;
    }
}