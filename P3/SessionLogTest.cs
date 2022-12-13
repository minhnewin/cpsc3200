namespace PA3
{
    [TestClass]
    public class SessionLogTest
    {
        [TestMethod]
        public void AddSet_True()
        {
            SessionLog test = new SessionLog("10/1/2022");
            test.addSet(new FitSet("","10/1/2022","",0,0,0));
            Assert.AreEqual(test.getObjCount(), 1);
        }
        [TestMethod]
        public void RemoveSet_True()
        {
            SessionLog test = new SessionLog("10/1/2022");
            test.addSet(new FitSet("", "10/1/2022", "", 0, 0, 0));
            test.removeSet(1);
            Assert.AreEqual(test.getObjCount(), 0);
        }
    }
}