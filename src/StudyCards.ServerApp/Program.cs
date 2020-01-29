using StudyCards.Local.Repositories;
using StudyCards.Local.Services;
using StudyCards.Sql;
using System;
using System.Threading.Tasks;

namespace StudyCards.ServerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dataContextFactory = new DataContextFactory();

            var categoryService = new CategoryService(new CategoryRepository(dataContextFactory));
            var groupService = new GroupService(new GroupRepository(dataContextFactory));
            var studyCardService = new StudyCardService(new StudyCardRepository(dataContextFactory));
            var port = 10987;
            var server = StudyCards.Server.StudyCardServer.Start(port, categoryService, groupService, studyCardService);
            Console.WriteLine("Server started");
            Console.WriteLine("Press any key to shutdown");
            Console.ReadKey();
            await server.ShutdownAsync().ConfigureAwait(false);           
        }
    }
}
