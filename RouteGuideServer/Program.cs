using System;
using Grpc.Core;
using Routeguide;

namespace RouteGuideServer
{
    class Routeguide 
    {
        static void Main(string[] args)
        {
            const int Port = 30052;

            var features = RouteGuideUtil.LoadFeatures();

            Server server = new Server
            {
                Services = { RouteGuide.BindService(new RouteGuideImpl(features)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("RouteGuide server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
