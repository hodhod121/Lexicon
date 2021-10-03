using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon
{
    [TestFixture]
    class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // Arrange
            Calculator calc = new();
            // Act
            int result = calc.AddNumbers(10, 20);
            // Assert
            Assert.AreEqual(30, result);
        }

    
        [Test]
        [TestCase(6)]
        [TestCase(10)]
        public void IsOddChecker_InputEvenNumber_ReturnFalse(int a)
        {
            Calculator calc = new();
            bool IsOdd = calc.IsOddNumber(a);
            Assert.That(IsOdd, Is.EqualTo(false));
            // Assert.IsFalse(IsOdd);
        }
        [Test]
        public void IsOddChecker_InputOddNumber_ReturnTrue()
        {
            Calculator calc = new();
            bool IsOdd = calc.IsOddNumber(3);
            Assert.That(IsOdd, Is.EqualTo(true));
            
        }
        [Test]
        [TestCase(10,ExpectedResult =false)]
        [TestCase(11,ExpectedResult =true)]
        public bool IsOddChecker_InputNumber_ReturnTrue(int a)
        {
            Calculator calc = new();
            return calc.IsOddNumber(a);          

        }
        [Test]
        [TestCase(5.3,3.5)]
        [TestCase(4.42,4.4)]
        [TestCase(6.51,2.3)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a,double b)
        {
            // Arrange
            Calculator calc = new();
            // Act
            double result = calc.AddNumbersDouble(a, b);
            // Assert
            Assert.AreEqual(8.8, result,.2);
        }
        [Test]
        public void OddRanger_InputMinAndMaxRanger_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange=new List<int>() { 5,7,9};

            // Act
            List<int> result=calc.GetOddRange(5,10);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOddRange));

        }
    }
}
