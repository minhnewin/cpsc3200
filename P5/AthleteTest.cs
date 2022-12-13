using System.Collections.Specialized;

namespace P5
{
    [TestClass]
    public class AthleteTest
    {
        [TestMethod]
        public void AddSessionLog_True()
        {
            Athlete athlete = new Athlete();
            SessionLog obj1 = new SessionLog("0/0/0000");
            FitSet test = new FitSet("", "0/0/0000", "", 0, 10, 0);
            obj1.addSet(test);
            athlete.AddSessionLog(obj1);
            Assert.AreEqual("Workout: FitSet\n Name:  Date: 0/0/0000 Completion: False\n Validity: True Percentage Completed: 0 Total Score: 0\n Class:  Weight: 0 TargetReps: 10 PerformedReps: 0", test.forPrint());
        }
        [TestMethod]
        public void Report_True()
        {
            Athlete athlete = new Athlete();
            SessionLog obj1 = new SessionLog("0/0/0000");
            FitSet test = new FitSet("", "0/0/0000", "", 0, 10, 0);
            obj1.addSet(test);
            athlete.AddSessionLog(obj1);
            Assert.AreEqual(athlete.Report(), "\n\n SessionLog 1\n\n\n" + test.forPrint() + "\n\n");
        }
    }
}