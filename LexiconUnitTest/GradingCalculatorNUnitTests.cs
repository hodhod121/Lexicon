using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator;
        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator();
        }
        [Test]
        public void GradeCalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("A"));
        }
        [Test]
        public void GradeCalc_InputScore85Attendance90_GetBGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }
        [Test]
        public void GradeCalc_InputScore65Attendance90_GetCGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("C"));
        }
        [Test]
        public void GradeCalc_InputScore95Attendance65_GetBGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        [Test]
        public void GradeCalc_FailoreScenarios_GetFGrade(int Score,int Attendance)
        {
            gradingCalculator.Score = Score;
            gradingCalculator.AttendancePercentage = Attendance;
            string result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }
        [TestCase(95, 90,ExpectedResult ="A")]
        [TestCase(85, 90,ExpectedResult ="B")]
        [TestCase(65, 90,ExpectedResult ="C")]
        [TestCase(95, 65,ExpectedResult ="B")]
        [TestCase(95, 55,ExpectedResult ="F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        [Test]
        public string GradeCalc_AllGradeLogicalScenarios_GradeGrade(int Score, int Attendance)
        {
            gradingCalculator.Score = Score;
            gradingCalculator.AttendancePercentage = Attendance;
            return gradingCalculator.GetGrade();           
        }
    }
}
