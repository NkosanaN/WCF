using System;
using System.ServiceModel;

namespace ConsoleApp4
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test();

            Console.ReadKey();
        }
        private static void Test()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;


            //https://saintfs.dsoffice.local:8736/api
            EndpointAddress ep = new EndpointAddress("https://saintfs.dsoffice.local:8736/api/");

            ChiliDataClient client = new ChiliDataClient(binding, ep);
            
            try
            {
                // var answer = client.GetTimesheets("ZODIAC", "nkosana", 19940114);

                var answer = client.GetStores("T", "loyd@datasaint.com");
                foreach (var item in answer)
                {
                    Console.WriteLine("{0}", item.CoyCode);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException);
            }

            Console.ReadLine();
        }

    }
}
    
