using System.Reflection;
using IImporter;
using IServices;

namespace Services;

public class ReflectionService(string reflectionFolderPath) : IReflectionService
{
        private readonly string _reflectionFolderPath = reflectionFolderPath ?? throw new ArgumentNullException(nameof(reflectionFolderPath));

        public IEnumerable<string> GetAssembliesWithImporter()
        {
            if (!Directory.Exists(_reflectionFolderPath))
            {
                return Enumerable.Empty<string>();
            }

            var dllFiles = Directory.GetFiles(_reflectionFolderPath, "*.dll");
            var assembliesFound = new List<string>();

            foreach (var file in dllFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(file);

                    if (AssemblyContainsImporter(assembly))
                    {
                        assembliesFound.Add(Path.GetFileName(file));
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return assembliesFound;
        }

        private bool AssemblyContainsImporter(Assembly assembly)
        {
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (typeof(ImporterInterface).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    return true;
                }
            }

            return false;
        }
    }