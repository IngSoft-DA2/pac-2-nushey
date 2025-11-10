namespace IServices;

public interface IReflectionService
{
    IEnumerable<string> GetAssembliesWithImporter();
}