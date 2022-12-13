namespace PA3
{
    [TestClass]
    public class HiitTest
    {
        [TestMethod]
        public void GetName_True()
        {
            Hiit test = new Hiit("TEST", "", 0, 0, 10);
            Assert.AreEqual(test.getName(), "TEST");
        }
        [TestMethod]
        public void GetDate_True()
        {
            Hiit test = new Hiit("", "TEST", 0, 0, 10);
            Assert.AreEqual(test.getDate(), "TEST");
        }
        [TestMethod]
        public void Complete_True()
        {
            Hiit test = new Hiit("", "", 0, 10, 10);
            Assert.AreEqual(test.getComplete(), true);
        }
        [TestMethod]
        public void Complete_False()
        {
            Hiit test = new Hiit("", "", 0, 0, 10);
            Assert.AreEqual(test.getComplete(), false);
        }
        [TestMethod]
        public void Valid_True()
        {
            Hiit test = new Hiit("", "", 0, 0, 10);
            Assert.AreEqual(test.getValid(), true);
        }
        [TestMethod]
        public void Valid_False()
        {
            Hiit test = new Hiit("", "", 0, 0, 10);
            test.setPerformedReps(10);
            Assert.AreEqual(test.getValid(), false);
        }
        [TestMethod]
        public void PercentageCompleted_True()
        {
            Hiit test = new Hiit("", "", 0, 10, 10);
            Assert.AreEqual(test.getPercentageCompleted(), 100);
        }
        [TestMethod]
        public void TotalScore_True()
        {
            Hiit test = new Hiit("", "", 10, 10, 10);
            Assert.AreEqual(test.getTotalScore(), 3000);
        }
        [TestMethod]
        public void Print_True()
        {
            Hiit test = new Hiit("", "", 0, 0, 10);
            Assert.AreEqual(test.forPrint(), "Workout: Hiit\n Name:  Date:  Completion: False\n Validity: True Percentage Completed: 0 Total Score: 0\n Time: 0 Training Period: 0 Rest Period: 0\n Performed Reps: 0 TargetReps: 10");
        }
        [TestMethod]
        public void GetTime_True()
        {
            Hiit test = new Hiit("", "", 10, 0, 0);
            Assert.AreEqual(test.getTime(), 30);
        }
        [TestMethod]
        public void GetTrainingPeriod_True()
        {
            Hiit test = new Hiit("", "", 10, 0, 0);
            Assert.AreEqual(test.getTrainingPeriod(), 10);
        }
        [TestMethod]
        public void GetRestPeriod_True()
        {
            Hiit test = new Hiit("", "", 10, 0, 0);
            Assert.AreEqual(test.getRestPeriod(), 20);
        }
        [TestMethod]
        public void GetPerformedReps_True()
        {
            Hiit test = new Hiit("", "", 0, 10, 0);
            Assert.AreEqual(test.getPerformedReps(), 10);
        }
        [TestMethod]
        public void GetTargetReps_True()
        {
            Hiit test = new Hiit("", "", 0, 0, 10);
            Assert.AreEqual(test.getTargetReps(), 10);
        }
        [TestMethod]
        public void SetPerformedReps_True()
        {
            Hiit test = new Hiit("", "", 0, 0, 0);
            test.setPerformedReps(10);
            Assert.AreEqual(test.getPerformedReps(), 10);
        }
    }
}