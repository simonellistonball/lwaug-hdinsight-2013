using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LoveCleanStreetsLib;
using Microsoft.Hadoop.MapReduce;
using FluentAssertions;

namespace LoveCleanStreetsTests
{
    [TestFixture]
    class TestLoveCleanStreet
    {
        private const string Report1 = "1,2,3,4,2013-10-21,5,,2013-10-21,Cleared,1,,,,Leicester,,";
        private const string Report2 = "1,2,3,4,2013-10-21,5,,2013-10-21,Cleared,1,,,,London,,";
        private const string Report3 = "1,2,3,4,2013-10-21,5,,2013-10-21,Cleared,1,,,,London,,";
        // this report has an invalid length of 15 
        private const string Report4 = "1,2,3,4,2013-10-21,5,,2013-10-21,Cleared,1,,,,London,";
        private const string Report5 = "1,2,3,4,2013-10-22,5,,2013-10-21,Cleared,1,,,,Leicester,,";

        private StreamingUnitOutput run(string[] data)
        {
            return StreamingUnit.Execute<LoveCleanStreetsMapper, LoveCleanStreetsReducer>(data);
        }
        [Test]
        public void LoveCleanStreetsMapper_FilterLA_ThreeItemsFromMapper()
        {
            var result = run(new[] { Report1, Report2, Report3, Report4 });
            result.ReducerResult.Count.Should().Be(2);
        }

        [Test]
        public void LoveCleanStreetsMapper_FilterLA_TwoItemsFromReducer()
        {
            var result = run(new[] { Report1, Report2, Report3, Report4 });
            result.ReducerResult.Count.Should().Be(2);
        }

        [Test]
        public void LoveCleanStreetsMapper_FilterLA_CheckReducerTwoPartsToLine()
        {
            var result = run(new[] { Report1, Report2, Report3, Report4 });
            result.ReducerResult[0].Split('\t').Length.Should().Be(2);
        }

        [Test]
        public void LoveCleanStreetsMapper_FilterLA_CheckReducerCountReports()
        {
            var result = run(new[] { Report1, Report2, Report3, Report4 });
            result.ReducerResult[0].Split('\t')[0].Should().Contain("Leicester");
            int.Parse(result.ReducerResult[0].Split('\t')[1]).Should().Be(1);
            result.ReducerResult[1].Split('\t')[0].Should().Contain("London");
            int.Parse(result.ReducerResult[1].Split('\t')[1]).Should().Be(2);

        }

        [Test]
        public void LoveCleanStreetsMapper_FilterLA_CheckReducerCountReportsByDay()
        {
            var result = run(new[] { Report1, Report2, Report3, Report4, Report5 });
            result.ReducerResult[0].Split('\t')[0].Should().Be("Leicester,2013-10-21");
            int.Parse(result.ReducerResult[0].Split('\t')[1]).Should().Be(1);
            result.ReducerResult[1].Split('\t')[0].Should().Be("Leicester,2013-10-22");
            int.Parse(result.ReducerResult[1].Split('\t')[1]).Should().Be(1);
            result.ReducerResult[2].Split('\t')[0].Should().Be("London,2013-10-21");
            int.Parse(result.ReducerResult[2].Split('\t')[1]).Should().Be(2);
        }


    }
}
