using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Certificate
    /// </summary>
    [TestFixture]
    class CertificateTest
    {
        /// <summary>
        /// Тестирование метода LastPrice на позитивных тестах
        /// </summary>
        /// <param name="value1">Значение свойства Price</param>
        /// <param name="value2">Значение свойства Discount</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(1200, 100, 1100, TestName = "Тестирование Certificate.LastPrice при значениях Price = 1200 и Discount = 100.")]
        [TestCase(550, 325, 225, TestName = "Тестирование Certificate.LastPrice при значениях Price = 550 и Discount = 325.")]
        [TestCase(230, 60, 170, TestName = "Тестирование Certificate.LastPrice при значениях Price = 230 и Discount = 60.")]
        [TestCase(1000, 1000, 0, TestName = "Тестирование Certificate.LastPrice при значениях Price = 1000 и Discount = 1000.")]

        public void LastPricePosTest(double value1, double value2, double expected)
        {
            var c = new Certificate();
            c.Price = value1;
            c.Discount = value2;
            Assert.AreEqual(expected, c.LastPrice());
        }

        /// <summary>
        /// Тестирование метода LastPrice на негативном тесте
        /// </summary>
        /// <param name="value1">Значение свойства Price</param>
        /// <param name="value2">Значение свойства Discount</param>
        /// <param name="expectedException">Значение исключения</param>
        [Test]
        [TestCase(double.MaxValue, double.MaxValue, typeof(OverflowException), TestName = "Тестирование Certificate.LastPrice при max значениях")]

        public void LastPriceNegTest(double value1, double value2, Type expectedException)
        {
            var c = new Certificate();
            c.Price = value1;
            c.Discount = value2;
            try
            {
                checked
                {
                    c.LastPrice();
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}