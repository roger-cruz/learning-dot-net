using System;
using System.Reflection;


// More info on Assembly: 
// https://docs.microsoft.com/en-us/dotnet/framework/app-domains/assemblies-in-the-common-language-runtime

[assembly: AssemblyVersion("1.2.3.4")]
[assembly: AssemblyDescription("Learning about assemblies")]

namespace AppAssemblyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly
            Assembly assembly = typeof(Program).Assembly;
            Console.WriteLine("Assembly Full Name: {0}", assembly.FullName);

            // https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assemblyname
            AssemblyName assemblyName = assembly.GetName();
            Console.WriteLine("Assembly Name: {0}", assemblyName.Name);

            // Version information for an assembly:
            //
            // {Major Version}.{Minor Version}.{Build Number}.{Revision}
            //
            // You can use the [assembly: AssemblyVersion("1.0.0.0")] attribute to set the values
            // https://docs.microsoft.com/en-us/dotnet/framework/app-domains/assembly-versioning
            // Write the version in its individual components

            // Write version as a whole string.
            Console.WriteLine("Version: {0}", assemblyName.Version);

            Console.WriteLine("Version (components): Major: {0} Minor: {1} Build: {2} Revision: {3}",
                assemblyName.Version.Major, 
                assemblyName.Version.Minor,
                assemblyName.Version.Build,
                assemblyName.Version.Revision);

            // https://docs.microsoft.com/en-us/dotnet/api/system.attribute.getcustomattribute
            bool isDefined = Attribute.IsDefined(assembly, typeof(AssemblyDescriptionAttribute));
            Console.WriteLine("Is Description Attribute defined? {0}", isDefined);
            if (isDefined)
            {
                AssemblyDescriptionAttribute attribute = (AssemblyDescriptionAttribute)
                    Attribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute));
                Console.WriteLine("Description: {0}", attribute.Description);
            }    

            
           Console.ReadLine();
        }
    }
}
