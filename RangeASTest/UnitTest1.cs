namespace RangeASTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void endPointsTest1()
        {
            Range r1 = new Range("[2,6)");
            string result = r1.endPoints();
            Assert.AreEqual("[2,6) endPoints = {2,5}", result);
        }
        [TestMethod]
        public void endPointsTest2()
        {
            Range r1 = new Range("[2,6]");
            string result = r1.endPoints();
            Assert.AreEqual("[2,6] endPoints = {2,6}", result);
        }
        [TestMethod]
        public void endPointsTest3()
        {
            Range r1 = new Range("(2,6)");
            string result = r1.endPoints();
            Assert.AreEqual("(2,6) endPoints = {3,5}", result);
        }
        [TestMethod]
        public void endPointsTest4()
        {
            Range r1 = new Range("(2,6]");
            string result = r1.endPoints();
            Assert.AreEqual("(2,6] endPoints = {3,6}", result);
        }

        [TestMethod]
        public void GetAllPointsTest1()
        {
            Range r1 = new Range("[2,6)");
            string result = r1.GetAllPoints();
            Assert.AreEqual("[2,6) allPoints = {2,3,4,5}", result);
        }
        [TestMethod]
        public void EqualsTest1()
        {
            Range r1 = new Range("[3,5)");
            string result = r1.Equals("[3,5)");
            Assert.AreEqual("[3,5) equals [3,5)", result);
        }
        [TestMethod]
        public void EqualsTest2()
        {
            Range r1 = new Range("[2,10)");
            string result = r1.Equals("[3,5)");
            Assert.AreEqual("[2,10) neq [3,5)", result);
        }
        [TestMethod]
        public void EqualsTest3()
        {
            Range r1 = new Range("[2,5)");
            string result = r1.Equals("[3,10)");
            Assert.AreEqual("[2,5) neq [3,10)", result);
        }
        [TestMethod]
        public void EqualsTest4()
        {
            Range r1 = new Range("[3,5)");
            string result = r1.Equals("[2,10)");
            Assert.AreEqual("[3,5) neq [2,10)", result);
        }
        [TestMethod]
        public void IntegerRangeContainsTest1()
        {
            List<int> integerRange = new List<int>();
            integerRange.Add(2);
            integerRange.Add(4);
            Range r1 = new Range("[2,6)");
            string result = r1.IntegerRangeContain(integerRange);
            Assert.AreEqual("[2,6) contains {2,4}", result + r1.NumberContaining(integerRange));
        }
        [TestMethod]
        public void IntegerRangeContainsTest2()
        {
            List<int> integerRange = new List<int>();
            integerRange.Add(-1);
            integerRange.Add(1);
            integerRange.Add(6);
            integerRange.Add(10);
            Range r1 = new Range("[2,6)");
            string result = r1.IntegerRangeContain(integerRange);
            Assert.AreEqual("[2,6) doesn't contain {-1,1,6,10}", result + r1.NumberContaining(integerRange));
        }
        [TestMethod]
        public void ContainsRangeTest1()
        {
            Range r1 = new Range("[2,5)");
            string result = r1.ContainRange("[7,10)");
            Assert.AreEqual("[2,5) doesn't contain [7,10)",result);
        }
        [TestMethod]
        public void ContainsRangeTest2()
        {
            Range r1 = new Range("[2,5)");
            string result = r1.ContainRange("[3,10)");
            Assert.AreEqual("[2,5) doesn't contain [3,10)", result);
        }
        [TestMethod]
        public void ContainsRangeTest3()
        {
            Range r1 = new Range("[3,5)");
            string result = r1.ContainRange("[2,10)");
            Assert.AreEqual("[3,5) doesn't contain [2,10)", result);
        }
        [TestMethod]
        public void ContainsRangeTest4()
        {
            Range r1 = new Range("[2,10)");
            string result = r1.ContainRange("[3,5]");
            Assert.AreEqual("[2,10) contains [3,5]", result);
        }
        [TestMethod]
        public void ContainsRangeTest5()
        {
            Range r1 = new Range("[3,5]");
            string result = r1.ContainRange("[3,5)");
            Assert.AreEqual("[3,5] contains [3,5)", result);
        }
        [TestMethod]
        public void OverlapsTest1()
        {
            Range r1 = new Range("[2,5)");
            string result = r1.OverlapRange("[7,10)");
            Assert.AreEqual("[2,5) doesn't overlap with [7,10)", result);
        }
        [TestMethod]
        public void OverlapsTest2()
        {
            Range r1 = new Range("[2,10)");
            string result = r1.OverlapRange("[3,5)");
            Assert.AreEqual("[2,10) overlaps with [3,5)", result);
        }
        [TestMethod]
        public void OverlapsTest3()
        {
            Range r1 = new Range("[3,5)");
            string result = r1.OverlapRange("[3,5)");
            Assert.AreEqual("[3,5) overlaps with [3,5)", result);
        }
        [TestMethod]
        public void OverlapsTest4()
        {
            Range r1 = new Range("[2,5)");
            string result = r1.OverlapRange("[3,10)");
            Assert.AreEqual("[2,5) overlaps with [3,10)", result);
        }
        [TestMethod]
        public void OverlapsTest5()
        {
            Range r1 = new Range("[3,5)");
            string result = r1.OverlapRange("[2,10)");
            Assert.AreEqual("[3,5) overlaps with [2,10)", result);
        }
    }
}