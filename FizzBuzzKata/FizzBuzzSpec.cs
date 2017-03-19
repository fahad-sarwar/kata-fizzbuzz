using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzSpec
    {
        [TestMethod]
        public void Number_Returns_Result_Using_DefaultSubsitutions()
        {
            Assert.AreEqual("", new FizzBuzzGame().Convert(0));
            Assert.AreEqual("1", new FizzBuzzGame().Convert(1));
            Assert.AreEqual("Fizz", new FizzBuzzGame().Convert(3));
            Assert.AreEqual("Buzz", new FizzBuzzGame().Convert(5));
            Assert.AreEqual("FizzBuzz", new FizzBuzzGame().Convert(15));
            Assert.AreEqual("Pop", new FizzBuzzGame().Convert(7));
            Assert.AreEqual("FizzPop", new FizzBuzzGame().Convert(21));
            Assert.AreEqual("BuzzPop", new FizzBuzzGame().Convert(35));
            Assert.AreEqual("FizzBuzzPop", new FizzBuzzGame().Convert(105));
            Assert.AreEqual("97", new FizzBuzzGame().Convert(97));
        }

        [TestMethod]
        public void Number_Returns_Result_Using_CustomPreferences()
        {
            var _customPreference = new Dictionary<int, string>
            {
                { 2, "Fuzz" },
                { 3, "Bizz" }
            };

            Assert.AreEqual("", new FizzBuzzGame(_customPreference).Convert(0));
            Assert.AreEqual("1", new FizzBuzzGame(_customPreference).Convert(1));
            Assert.AreEqual("Fuzz", new FizzBuzzGame(_customPreference).Convert(2));
            Assert.AreEqual("Bizz", new FizzBuzzGame(_customPreference).Convert(9));
            Assert.AreEqual("FuzzBizz", new FizzBuzzGame(_customPreference).Convert(12));
        }
    }

    public class FizzBuzzGame
    {
        private static readonly Dictionary<int, string> _defaultLookup = new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 5, "Buzz" },
            { 7, "Pop" }
        };

        private readonly Dictionary<int, string> _lookup = new Dictionary<int, string>();

        public FizzBuzzGame(Dictionary<int, string> lookup = null)
        {
            _lookup = lookup ?? _defaultLookup;
        }

        public string Convert(int number)
        {
            if (number == 0)
                return "";

            return string.Join("", _lookup.Keys
                .Where(key => number % key == 0)
                .Select(key => _lookup[key])
                .DefaultIfEmpty(number.ToString())
                .ToList());
        }
    }
}
