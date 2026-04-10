using BlockScript;
public static class TestingTool
{
    public static void PrintEnvironment(ProgramEnvironment environment)
    {
        foreach (var binding in environment.Bindings)
        {
            Console.WriteLine($"Variable Name: {binding.Key}");
            Console.WriteLine(binding.Value.ToString());
            Console.WriteLine();
        }
    }

    public static void PrintMemory(ProgramMemory memory)
    {
        Console.WriteLine($"Memory Size: {memory.Size}");
        for (int i = 0; i < memory.Size; i++)
        {
            Console.Write($"{i}| {memory.Data[i]}    ");
        }
        Console.WriteLine();
    }
}