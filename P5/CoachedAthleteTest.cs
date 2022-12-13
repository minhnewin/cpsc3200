namespace P5
{
    [TestClass]
    public class CoachedAthleteTest
    {
        [TestMethod]
        public void Subscribe_True()
        {
            SessionLog obj1 = new SessionLog("10/1/2022");
            FitSet test = new FitSet("", "0/0/0000", "", 0, 10, 0);
            obj1.addSet(test);
            CoachedAthlete provider1 = new CoachedAthlete();
            TextWriter writer1 = Console.Out;
            RepetitionMonitor observer1 = new RepetitionMonitor("RepetitionMonitor", writer1);

            observer1.Subscribe(provider1);
            provider1.AddSessionLog(obj1);

            Assert.AreEqual(provider1.getFirstObserver(), observer1);
        }

        [TestMethod]
        public void AddSessionLog_True()
        {
            CoachedAthlete provider1 = new CoachedAthlete();
            SessionLog obj1 = new SessionLog("0/0/0000");
            FitSet test = new FitSet("", "0/0/0000", "", 0, 10, 0);
            obj1.addSet(test);
            provider1.AddSessionLog(obj1);
            Assert.AreEqual(provider1.Report(), "\n\n SessionLog 1\n\n\n" + test.forPrint() + "\n\n");
        }
    }
}