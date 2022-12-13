using System.Collections.Generic;

namespace PA3
{
    [TestClass]
    public class WorkoutTest
    {
        [TestMethod]
        public void GetName_True()
        {
            Workout test = new Workout("TEST", "");
            Assert.AreEqual(test.getName(), "TEST");
        }
        [TestMethod]
        public void GetDate_True()
        {
            Workout test = new Workout("", "TEST");
            Assert.AreEqual(test.getDate(), "TEST");
        }
        [TestMethod]
        public void GetComplete_False()
        {
            Workout test = new Workout("", "");
            Assert.AreEqual(test.getComplete(), false);
        }
        [TestMethod]
        public void GetValid_True()
        {
            Workout test = new Workout("", "");
            Assert.AreEqual(test.getValid(), true);
        }
        [TestMethod]
        public void ForPrint_True()
        {
            Workout test = new Workout("", "");
            Assert.AreEqual(test.forPrint(), "");
        }
    }
}