namespace PA1
{
    [TestClass]
    public class FitSetTests
    {
        [TestMethod]
        public void IsCompleted_True()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            test.setTargetReps(10);
            test.setPerformedReps(10);
            Assert.AreEqual(test.isCompleted(), true);
        }

        [TestMethod]
        public void IsCompleted_False()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            test.setTargetReps(10);
            test.setPerformedReps(5);
            Assert.AreEqual(test.isCompleted(), false);
        }

        [TestMethod]
        public void IsValid_True()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            Assert.AreEqual(test.isValid(), true);
        }

        [TestMethod]
        public void IsValid_WeightFalse()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            test.setWeight(10);
            Assert.AreEqual(test.isValid(), false);
        }


        [TestMethod]
        public void IsValid_PerformedRepsFalse()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            test.setPerformedReps(10);
            Assert.AreEqual(test.isValid(), false);
        }

        [TestMethod]
        public void PercentageCompleted()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            test.setTargetReps(10);
            test.setPerformedReps(5);
            Assert.AreEqual(test.percentageCompleted(), 50);
        }

        [TestMethod]
        public void TotalScore_True()
        {
            FitSet test = new FitSet("", "", "", 10, 10, 5);
            Assert.AreEqual(test.totalScore(), 50);
        }

        [TestMethod]
        public void TotalScore_False()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            test.setTargetReps(10);
            test.setPerformedReps(5);
            test.setWeight(10);
            Assert.AreEqual(test.totalScore(), 0);
        }

    }
}