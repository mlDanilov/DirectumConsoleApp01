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
       
        MeetingHelper.CreateMeeting(new DateTime(2024, 12, 2, 1, 0, 0), new DateTime(2024, 12, 2, 2, 0, 0));
        MeetingHelper.CreateMeeting(new DateTime(2024, 12, 2, 2, 0, 1), new DateTime(2024, 12, 2, 3, 0, 0));
        MeetingHelper.CreateMeeting(new DateTime(2024, 12, 2, 10, 0, 1), new DateTime(2024, 12, 2, 11, 0, 0));
        NotificationHelper.CreateNotification(1, new TimeSpan(1, 15, 0));
        NotificationHelper.CreateNotification(3, new TimeSpan(5, 0, 0));

        var firstStep = new MainMenuStep();
        firstStep.Execute();

        Console.ReadKey();
    }
}