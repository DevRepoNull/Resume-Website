namespace Resume.Application.Generator;

public static class CodeGenerator
{
    public static string GenerateUniqCode()
    {
        return Guid.NewGuid().ToString("N");
    }
}