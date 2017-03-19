using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzSpec
    {
        [TestMethod]
        public void Number_Returns_Result()
        {
            Assert.AreEqual("0", FizzBuzzGame.Convert(0));
        }
    }

    public class FizzBuzzGame
    {
        public static string Convert(int number)
        {
            return "0";
        }
    }
}
