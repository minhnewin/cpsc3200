using System.Text;

namespace P5
{
    [TestClass]
    public class OvertrainingMonitorTest
    {
        [TestMethod]
        public void Subscribe_True()
        {
            CoachedAthlete provider1 = new CoachedAthlete();
            TextWriter writer1 = Console.Out;
            OvertrainingMonitor observer1 = new OvertrainingMonitor("OvertrainingMonitor", 20, writer1);

            observer1.Subscribe(provider1);

            Assert.AreEqual(observer1, provider1.getFirstObserver());
        }

        [TestMethod]
        public void OnNext_True()
        {
            StringBuilder writer1 = new StringBuilder();
            StringWriter writer2 = new StringWriter(writer1);
            OvertrainingMonitor observer1 = new OvertrainingMonitor("OvertrainingMonitor", 10, writer2);
            CoachedAthlete provider1 = new CoachedAthlete();

            SessionLog obj1 = new SessionLog("0/0/0000");
            TriWorkout test = new TriWorkout("", "0/0/0000", 0, 20, 10);
            obj1.addSet(test);

            observer1.Subscribe(provider1);
            provider1.AddSessionLog(obj1);

            StringReader writer3 = new StringReader(writer1.ToString());

            string temp = "";
            while (writer3.Peek() > -1)
            {
                temp += writer3.ReadLine();
            }
            Assert.AreEqual("The performed: 20The Target: 10The combined performed distance of all TriWorkouts in the given session logis greater than the target distance of the Monitor", temp);

        }
    }
}