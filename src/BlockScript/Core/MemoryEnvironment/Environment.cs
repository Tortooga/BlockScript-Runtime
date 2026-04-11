using System.Collections;
using System.Reflection;

namespace BlockScript;

public class ProgramEnvironment
{
    const int MaxIdentifierLength = 16;

    public ProgramMemory EnvironmentMemory {get; set;}
    public Dictionary<String,  BindingMetaData> Bindings {get; set;}
    public BitArray AddressIsUsed; //Address highlighting which addresses are used in memory


    public ProgramEnvironment(int memorySize)
    {
        this.EnvironmentMemory = new ProgramMemory(memorySize);
        this.Bindings = new Dictionary<string, BindingMetaData>();
        this.AddressIsUsed = new BitArray(memorySize); 
    } 

    public DefineVarStatusCode DefineVar(string name, ObjectType type)
    {
        DefineVarStatusCode statusCode;
        int? assignedIndex = GetFreeIndex();

        //Memory Validation
        if (assignedIndex == null)
        {
            return DefineVarStatusCode.OutOfMemory;
        }

        //IdentifierValidation
        statusCode = ValidateIdentifier(name);
        if (statusCode != DefineVarStatusCode.Success)
        {
            return statusCode;
        }
        
        //Preparing Metadata.
        BindingMetaData bindingMetaData = new BindingMetaData
        (
            Index: (int)assignedIndex,
            BindingType: type,
            IsInitialised: false
        );

        //Defining Variable
        Bindings.Add(name, bindingMetaData);

        //Mark memory as used in AddressIsUsed bitmap
        AddressIsUsed[(int)assignedIndex] = true;


        return DefineVarStatusCode.Success;
    }


    public DefineVarStatusCode ValidateIdentifier(string identifier)
    {
        if (identifier.Length <= 0 || identifier.Length > MaxIdentifierLength)
        {
            return DefineVarStatusCode.InvalidIdentifierLength;
        }

        //Checking if first character in identifier is invalid
        if (!CharIsInArray(identifier[0], IdentifierConstants.ValidIdentifierStartCharacters))
        {
            return DefineVarStatusCode.InvalidIdentifierStart;
        }
        

        //Checking if the rest of the body is valid
        for (int i = 1; i < identifier.Length; i++)
        {
            if (!CharIsInArray(identifier[i], IdentifierConstants.ValidIdentifierCharacters))
            {
                return DefineVarStatusCode.InvalidIdentifierBody;
            }
        }

        //Checking if keyword is reserved
        if (IsReserved(identifier))
        {
            return DefineVarStatusCode.ReservedKeyword;
        }

        //Checking if identifier is already a key in a binding
        if (IdentifierIsUsed(identifier))
        {
            return DefineVarStatusCode.IdentifierAlreadyUsed;
        }
        return DefineVarStatusCode.Success;
    }

    private bool IdentifierIsUsed(string identifier)
    {
        foreach (var binding in Bindings)
        {
            if (binding.Key == identifier)
            {
                return true;
            }
        }

        return false;
    }
    private static bool IsReserved(string keyword)
    {
        for (int i = 0; i < Keywords.ReservedKeywords.Length; i++)
        {
            if (keyword == Keywords.ReservedKeywords[i])
            {
                return true;
            }
        }

        return false;
    }

    private static bool CharIsInArray(char c, char[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (c == array[i])
            {
                return true;
            }
        }

        return false;
    }
    private int? GetFreeIndex()
    {
        for (int index = 0; index < AddressIsUsed.Length; index++)
        {
            if (!AddressIsUsed[index])
            {
                return index;
            }
        }
        return null;
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

    public override string ToString()
    {
        return $"Index: {Index}\nType: {BindingType}\nIsInitialised: {IsInitialised}";
    }
}