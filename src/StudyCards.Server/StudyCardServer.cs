using Grpc.Core;
using Helloworld;
using System;
using System.Threading.Tasks;
using Grpc.Core;
using StudyCards.Data;
using StudyCards.GRPC;
using System.Net;
using System.Linq;
using System.Net.Sockets;

namespace StudyCards.Server
{
    public static class StudyCardServer
    {
        public static Grpc.Core.Server Start(int port, ICategoryService categoryService, IGroupService groupService, IStudyCardService studyCardService)
        {
            var hostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostByName(hostName);

            //var credentials = new Grpc.Core.SslServerCredentials()

            var serverPorts = iphostentry.AddressList
                .Where(x => x.AddressFamily == AddressFamily.InterNetwork)
                .Select(x => new ServerPort($"{x}", port, ServerCredentials.Insecure))
                .ToList();

            if (!serverPorts.Any(x => "127.0.0.1".Equals(x.Host, StringComparison.OrdinalIgnoreCase) || "localhost".Equals(x.Host, StringComparison.OrdinalIgnoreCase)))
                serverPorts.Add(new ServerPort("localhost", port, ServerCredentials.Insecure));

            var server = new Grpc.Core.Server
            {
                Services = {
                    CategoryService.BindService(new Services.CategoryService(categoryService)),
                    GroupService.BindService(new Services.GroupService(groupService)),
                    StudyCardService.BindService(new Services.StudyCardService(studyCardService))
                }
                //Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };

            foreach (var serverPort in serverPorts)
                server.Ports.Add(serverPort);

            server.Start();

            return server;
        }

    }
}
