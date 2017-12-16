using System;

namespace GraphApiTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var apiConnect = new ApiConnector();

            var list = apiConnect.Connect();

            foreach (var file in list)
            {
                Console.WriteLine(file);
            }

        }



        

    }
}
