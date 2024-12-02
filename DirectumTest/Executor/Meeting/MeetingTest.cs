using MeetingDomainLib.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectumTest.Executor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    public class MeetingTest
    {
        
        [Fact]
        public void Constructor()
        {
            //Arrange
            DateTime from_correct = DateTime.Now.AddHours(1);
            DateTime to_correct = DateTime.Now.AddHours(2);

            DateTime from_notCorrect1 = DateTime.Now.AddHours(3);
            DateTime to_notCorrect1 = DateTime.Now.AddHours(2);

            DateTime from_notCorrect2 = DateTime.Now.AddHours(4);
            DateTime to_notCorrect2 = from_notCorrect2;

            //Act
            var meeting = new Meeting(-1, from_correct, to_correct);
            //Assert
            Assert.Throws<MeetingFromToException>(() => new Meeting(-1, from_notCorrect2, to_notCorrect2));
            Assert.Throws<MeetingFromToException>(() => new Meeting(-1, from_notCorrect1, to_notCorrect1));
            
            Assert.Equal(from_correct, meeting.From);
            Assert.Equal(to_correct, meeting.To);


        }

    }
}
