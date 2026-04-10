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
}