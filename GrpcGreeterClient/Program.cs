using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client =  new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient1" });
            Console.WriteLine("Greeting: " + reply.Message);

            
            var heyaReply = await client.SayHeyaAsync(
                              new HelloRequest { Name = "GreeterClient2" });
            Console.WriteLine("Greeting: " + heyaReply.Message);

            
            var normalClient =  new Normal.NormalClient(channel);
            var normalReply = await normalClient.GetActorsAsync(
                              new Google.Protobuf.WellKnownTypes.Empty());
            Console.WriteLine("Actor: " + normalReply.Actor + Environment.NewLine + "Actress: " + normalReply.Actress);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
