using IServices;

namespace Services;

public class ReflectionService : IReflectionService
{
    public IEnumerable<string> GetAssembliesWithImporter()
    {
        return Enumerable.Empty<string>();
    }
}