using System.Collections.Generic;

namespace P5
{
    [TestClass]
    public class FitSetTest
    {
        [TestMethod]
        public void SetWeight_True()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 0);
            test.setWeight(10);
            Assert.AreEqual(test.getWeight(), 10);
        }
        [TestMethod]
        public void SetPerformedReps_True()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 0);
            test.setPerformedReps(10);
            Assert.AreEqual(test.getPerformed(), 10);
        }
        [TestMethod]
        public void GetClass_True()
        {
            FitSet test = new FitSet("", "", "TEST", 0, 10, 0);
            Assert.AreEqual(test.getClass(), "TEST");
        }
        [TestMethod]
        public void GetName_True()
        {
            FitSet test = new FitSet("TEST", "", "", 0, 10, 0);
            Assert.AreEqual(test.getName(), "TEST");
        }
        [TestMethod]
        public void GetDate_True()
        {
            FitSet test = new FitSet("", "TEST", "", 0, 10, 0);
            Assert.AreEqual(test.getDate(), "TEST");
        }
        [TestMethod]
        public void GetWeight_True()
        {
            FitSet test = new FitSet("", "TEST", "", 10, 10, 0);
            Assert.AreEqual(test.getWeight(), 10);
        }
        [TestMethod]
        public void GetTargetReps_True()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 0);
            Assert.AreEqual(test.getTarget(), 10);
        }
        [TestMethod]
        public void GetPerformedReps_True()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 10);
            Assert.AreEqual(test.getPerformed(), 10);
        }
        [TestMethod]
        public void IsCompleted_True()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 10);
            Assert.AreEqual(test.getComplete(), true);
        }

        [TestMethod]
        public void IsCompleted_False()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 5);
            Assert.AreEqual(test.getComplete(), false);
        }

        [TestMethod]
        public void IsValid_True()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 0);
            Assert.AreEqual(test.getValid(), true);
        }

        [TestMethod]
        public void IsValid_WeightFalse()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 0);
            test.setWeight(10);
            Assert.AreEqual(test.getValid(), false);
        }


        [TestMethod]
        public void IsValid_PerformedRepsFalse()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 0);
            test.setPerformedReps(10);
            Assert.AreEqual(test.getValid(), false);
        }

        [TestMethod]
        public void PercentageCompleted()
        {
            FitSet test = new FitSet("", "", "", 0, 10, 5);
            Assert.AreEqual(test.getPercentageCompleted(), 50);
        }

        [TestMethod]
        public void TotalScore_True()
        {
            FitSet test = new FitSet("", "", "", 10, 10, 5);
            Assert.AreEqual(test.getTotalScore(), 50);
        }

        [TestMethod]
        public void TotalScore_False()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            test.setPerformedReps(5);
            test.setWeight(10);
            Assert.AreEqual(test.getTotalScore(), 0);
        }
        [TestMethod]
        public void Print_True()
        {
            FitSet test = new FitSet("", "", "", 0, 0, 0);
            Assert.AreEqual(test.forPrint(), "Workout: FitSet\n Name:  Date:  Completion: False\n Validity: True Percentage Completed: 0 Total Score: 0\n Class:  Weight: 0 TargetReps: 0 PerformedReps: 0");
        }
    }
}
