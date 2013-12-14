using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace LoveCleanStreetsTests
{
    [TestFixture]
    public class AverageTests
    {
        private const string Report1 = "1,2,3,4,2013-10-21,5,,2013-10-21,Cleared,1,,,,Leicester,,";
        private const string Report2 = "1,2,3,4,2013-10-21,5,,2013-10-21,Cleared,1,,,,London,,";
        private const string Report3 = "1,2,3,4,2013-10-21,5,,2013-10-21,Cleared,1,,,,London,,";

        [Test]
        public void TestMapper()
        {
        }

        [Test]
        public void TestAveragingReducer()
        {

        }
    }
}
