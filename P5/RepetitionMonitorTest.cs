using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace P5
{
    [TestClass]
    public class RepetitionMonitorTest
    {
        [TestMethod]
        public void Subscribe_True()
        {
            CoachedAthlete provider1 = new CoachedAthlete();
            TextWriter writer1 = Console.Out;
            RepetitionMonitor observer1 = new RepetitionMonitor("RepetitionMonitor", writer1);

            observer1.Subscribe(provider1);

            Assert.AreEqual(observer1, provider1.getFirstObserver());
        }

        [TestMethod]
        public void OnNext_True()
        {
            StringBuilder writer1 = new StringBuilder();
            StringWriter writer2 = new StringWriter(writer1);
            RepetitionMonitor observer1 = new RepetitionMonitor("RepetitionMonitor", writer2);
            CoachedAthlete provider1 = new CoachedAthlete();

            SessionLog obj1 = new SessionLog("0/0/0000");
            FitSet test = new FitSet("", "0/0/0000", "", 0, 10, 20);
            obj1.addSet(test);

            observer1.Subscribe(provider1);
            provider1.AddSessionLog(obj1);

            StringReader writer3 = new StringReader(writer1.ToString());

            string temp = "";
            while (writer3.Peek() > -1)
            {
                temp += writer3.ReadLine();
            }
            Assert.AreEqual("The given session log has at least one workout wherethe performed repetitions are greater than target repetitions", temp);

        }
    }
}