// See https://aka.ms/new-console-template for more information
using CoreLib.Command;
using CoreLib.Query;
using DirectumConsoleApp01.Helper;
using DirectumConsoleApp01.UserCommand;
using MeetingCoreLib;
using MeetingCoreLib.Command;
using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.Command.Notification;
using MeetingCoreLib.Model;
using MeetingCoreLib.Query.Meeting;
using MeetingDomainLib;
using MeetingDomainLib.Entities;
using SimpleInjector;

internal class Program
{
    private static void Main(string[] args)
    {
        
        DateTime dateTime = DateTime.Now;
        
        var diContainer = new Container();

        diContainer.Register(typeof(ICommandExecutor<>), AppDomain.CurrentDomain.GetAssemblies());
        diContainer.Register(typeof(IQueryExecutor<,>), AppDomain.CurrentDomain.GetAssemblies());
        diContainer.RegisterSingleton<MainModel>();

        var cmdDispatcher = new CommandDispatcher(diContainer);
        var queryDispatcher = new QueryDispatcher(diContainer);
        
        MeetingHelper.QueryDispatcher = queryDispatcher;
        MeetingHelper.CommandDispatcher = cmdDispatcher;

        NotificationHelper.QueryDispatcher = queryDispatcher;
        NotificationHelper.CommandDispatcher = cmdDispatcher;
       
        var firstStep = new MainMenuStep();
        firstStep.Execute();

        Console.ReadKey();
    }
}