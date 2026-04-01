using CalculationLibrary;

namespace CalculationTests
{
    [TestClass]
    public sealed class CalculationTests
    {
        private static Calculation? calculation;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            //arrange
            calculation = new();
            testContext.WriteLine("initialized");
        }


        [ClassCleanup]
        public static void Down()
        {
            //arrange
            calculation = null;
        }

        //[TestInitialize]
        //public void Initialize()
        //{
        //    //arrange
        //    calculation = new();
        //}

        //[TestCleanup]
        //public void Dispose() => calculation = null;

        [TestMethod]
        public void DividePositiveTest()
        {
            //act
            var actual = calculation?.Divide(12, 3);

            //assert
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void DivideExceptionTest()
        {
            try
            {
                //act
                calculation?.Divide(12, 0);
            }
            catch (Exception e)
            {
                //asserting exception
                //Assert.AreEqual(typeof(DivideByZeroException), e.GetType());
                Assert.AreEqual("divisor should not be zero", e.Message);
            }

        }
    }
}
