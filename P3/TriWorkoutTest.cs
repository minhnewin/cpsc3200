namespace PA3
{
    [TestClass]
    public class TriWorkoutTest
    {
        [TestMethod]
        public void GetName_True()
        {
            TriWorkout test = new TriWorkout("TEST", "", 0, 0, 10);
            Assert.AreEqual(test.getName(), "TEST");
        }
        [TestMethod]
        public void GetDate_True()
        {
            TriWorkout test = new TriWorkout("", "TEST", 0, 0, 10);
            Assert.AreEqual(test.getDate(), "TEST");
        }
        [TestMethod]
        public void Complete_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 10, 10);
            Assert.AreEqual(test.getComplete(), true);
        }
        [TestMethod]
        public void Complete_False()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            Assert.AreEqual(test.getComplete(), false);
        }
        [TestMethod]
        public void Valid_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            Assert.AreEqual(test.getValid(), true);
        }
        [TestMethod]
        public void Valid_False()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            test.setPerformedDistance(10);
            Assert.AreEqual(test.getValid(), false);
        }
        [TestMethod]
        public void PercentageCompleted_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 10, 10);
            Assert.AreEqual(test.getPercentageCompleted(), 100);
        }
        [TestMethod]
        public void TotalScore_True()
        {
            TriWorkout test = new TriWorkout("", "", 10, 10, 10);
            Assert.AreEqual(test.getTotalScore(), 10000);
        }
        [TestMethod]
        public void Print_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            Assert.AreEqual(test.forPrint(), "Workout: TriWorkout\n Name:  Date:  Completion: False\n Validity: True Percentage Completed: 0 Total Score: 0\n Time: 0 Performed Distance: 0 Target Distance: 10 Pace: 0");
        }
        [TestMethod]
        public void GetTime_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            Assert.AreEqual(test.getTime(), 0);
        }
        [TestMethod]
        public void GetPerformedDistance_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            Assert.AreEqual(test.getPerformedDistance(), 0);
        }
        [TestMethod]
        public void GetTargetDistance_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            Assert.AreEqual(test.getTargetDistance(), 10);
        }
        [TestMethod]
        public void GetPace_True()
        {
            TriWorkout test = new TriWorkout("", "", 10, 10, 10);
            Assert.AreEqual(test.getPace(), 100);
        }
        [TestMethod]
        public void SetPerformedDistance_True()
        {
            TriWorkout test = new TriWorkout("", "", 0, 0, 10);
            test.setPerformedDistance(10);
            Assert.AreEqual(test.getPerformedDistance(), 10);
        }
        [TestMethod]
        public void CalcPace_True()
        {
            TriWorkout test = new TriWorkout("", "", 10, 10, 10);
            test.calcPace();
            Assert.AreEqual(test.getPace(), 100);
        }
    }
}