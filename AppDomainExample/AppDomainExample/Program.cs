using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Turn on monitoring for the entire process
            // https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.monitoringisenabled
            AppDomain.MonitoringIsEnabled = true;

            DumpAppDomainInfo();

            // https://docs.microsoft.com/en-us/dotnet/framework/app-domains/how-to-create-an-application-domain
            Console.WriteLine(Environment.NewLine + "Creating new AppDomain.");
            AppDomain newDomain = AppDomain.CreateDomain("Newly-created AppDomain");

            // https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.docallback
            newDomain.DoCallBack(new CrossAppDomainDelegate(DumpAppDomainInfo));
            
            Console.ReadLine();
        }

        static void DumpAppDomainInfo()
        {
            AppDomain domain = AppDomain.CurrentDomain;

            Console.WriteLine("Domain name: {0}", domain.FriendlyName);
            Console.WriteLine("  ID: {0}", domain.Id);

            // https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.isdefaultappdomain
            Console.WriteLine("  Is Default Domain: {0}", domain.IsDefaultAppDomain());

            // https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.monitoringtotalallocatedmemorysize
            Console.WriteLine("  Total memory bytes used: {0}", domain.MonitoringTotalAllocatedMemorySize);

            // https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.monitoringtotalprocessortime
            Console.WriteLine("  Total CPU time used: {0}", domain.MonitoringTotalProcessorTime);
        }
    }
}
