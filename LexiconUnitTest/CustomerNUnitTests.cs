using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            //var customer = new Customer();

            // Act
            customer.GreetAndCombineNames("Ali", "Ezadkhaha");
            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ali Ezadkhaha"));
                //Assert.AreEqual(fullName, "Hello, Ali Ezadkhaha");
                Assert.That(customer.GreetMessage, Does.Contain(","));
                Assert.That(customer.GreetMessage, Does.StartWith("hello").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.EndWith("ha"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

            });
           
        }
       [Test]
       public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange
            //var customer = new Customer();

            // Act
            //customer.GreetAndCombineNames("Ali", "Ezadkhaha");
            //Assert
            Assert.IsNull(customer.GreetMessage);

        }
        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result=customer.Discount;
            Assert.That(result, Is.InRange(10,25));
        }
        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("Ali","");
            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }
        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var ExceptionDetails = Assert.Throws<ArgumentException>(() =>customer.GreetAndCombineNames("", "Ezadkhaha"));
            Assert.AreEqual("Empty First Name", ExceptionDetails.Message);
            //Assert.That(() => customer.GreetAndCombineNames("", "Ezadkhaha"),
            //Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Ezadkhaha"));
            //Assert.That(() => customer.GreetAndCombineNames("", "Ezadkhaha"),
            //Throws.ArgumentException);
        }
        [Test]
        public void GreetType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer() {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
        [Test]
        public void GreetType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
