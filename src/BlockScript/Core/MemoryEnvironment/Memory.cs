using System.Dynamic;
using System.Runtime.InteropServices.ObjectiveC;
using System.Runtime.InteropServices.Swift;

namespace BlockScript;

public class ProgramMemory
{
    public int Size {get; init;}
    public int[] Data {get; set;}
    

    public ProgramMemory(int Size)
    {
        this.Size = Size;   
        this.Data = new int[Size];
    }
}
