using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.CommandExecutor.Exception;
using MeetingCoreLib.CommandExecutor.Meeting;
using MeetingCoreLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DirectumTest.Executor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    public class CommandExecutorTest
    {
        private static DateTime getDateTime(int year_, int month_, int day_) => new DateTime(year_, month_, day_);

        [Fact]
        public void CreateMeeting_thowNotArchive()
        {
            //Arrange
            var current = DateTime.Now;
            var meetingThrow = new Meeting(-1, current.AddHours(-2), current.AddHours(-1));
            var model = new MainModel();
            var executor = new CreateMeetingCommandExecutor(model);
            var cmdExcpt = new CreateMeetingCommand(meetingThrow, false);

            //Act Assert
            Assert.Throws<CommandException<CreateMeetingCommand>>(() => executor.Execute(cmdExcpt));


        }

        [Fact]
        public void CreateMeeting_First()
        {
            //Arrange
            var current = DateTime.Now;
            var meetingFirst = new Meeting(123, current.AddHours(1), current.AddHours(2));
            var model = new MainModel();
            var executor = new CreateMeetingCommandExecutor(model);
            var cmdFirst = new CreateMeetingCommand(meetingFirst, false);

            //Act
            executor.Execute(cmdFirst);

            Assert.Single<int>(model.MeetingDisct.Keys);
            Assert.True(model.MeetingDisct.ContainsKey(1));


        }

        [Fact]
        public void CreateMeeting_notFirst()
        {
            //Arrange
            var current = DateTime.Now;
            var meetingAdded = new Meeting(123, current.AddHours(3), current.AddHours(4));

            var meetingNew = new Meeting(-1, current.AddHours(1), current.AddHours(2));
            var model = new MainModel();
            model.MeetingDisct.Add(meetingAdded.Id, meetingAdded);

            var executor = new CreateMeetingCommandExecutor(model);
            var cmdNew = new CreateMeetingCommand(meetingNew, false);

            //Act
            executor.Execute(cmdNew);

            //Assert
            Assert.True(model.MeetingDisct.ContainsKey(meetingAdded.Id + 1));

        }

        [Fact]
        public void CreateMeeting_intersection()
        {
            //Arrange
            var current = DateTime.Now;
            var meetingAdded = new Meeting(123, current.AddHours(3), current.AddHours(5));
            var meetingNew = new Meeting(-1, current.AddHours(2), current.AddHours(4));

            var model = new MainModel();
            model.MeetingDisct.Add(meetingAdded.Id, meetingAdded);

            var executor = new CreateMeetingCommandExecutor(model);
            var cmdNew = new CreateMeetingCommand(meetingNew);

            //Act
            executor.Execute(cmdNew);

            //Act Assert
            Assert.Throws<CommandException<CreateMeetingCommand>>(() => executor.Execute(cmdNew));

            //Assert
            Assert.True(model.MeetingDisct.ContainsKey(meetingAdded.Id + 1));

        }
    }
}
