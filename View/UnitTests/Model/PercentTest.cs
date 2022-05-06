using System;
using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Percent
    /// </summary>
    [TestFixture]
    class PercentTest
    {
        /// <summary>
        /// Тестирование свойства Price на позитивных тестах
        /// </summary>
        /// <param name="value">Значение свойства Price</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(10, 10, TestName = "Тестирование Price при присваивании 10.")]
        [TestCase(1000, 1000, TestName = "Тестирование Price при присваивании значения 1000")]
        public void PricePosTest(double value, int expected)
        {
            var p = new Percent();
            p.Price = value;
            Assert.AreEqual(expected, p.Price);
        }

        /// <summary>
        /// Тестирование свойства Price на негативных тестах
        /// </summary>
        /// <param name="value">Значение свойства Price</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        [TestCase(-1, typeof(Exception), TestName = "Тестирование Price при присваивании -1")]
        [TestCase(double.MinValue, typeof(Exception), TestName = "Тестирование Price при присваивании min значения")]
        public void PriceNegTest(double value, Type expectedException)
        {
            var p = new Percent();
            Assert.Throws(expectedException, () => p.Price = value);
        }

        /// <summary>
        /// Тестирование свойства Discount на позитивных тестах
        /// </summary>
        /// <param name="value">Значение свойства Discount</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(10, 10, TestName = "Тестирование Discount при присваивании 10.")]
        [TestCase(1000, 1000, TestName = "Тестирование Discount при присваивании значения 1000")]
        public void DiscountPosTest(double value, int expected)
        {
            var p = new Percent();
            p.Discount = value;
            Assert.AreEqual(expected, p.Discount);
        }

        /// <summary>
        /// Тестирование свойства Discount на негативных тестах
        /// </summary>
        /// <param name="value">Значение свойства Discount</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        [TestCase(-1, typeof(Exception), TestName = "Тестирование Discount при присваивании -1")]
        [TestCase(double.MinValue, typeof(Exception), TestName = "Тестирование Discount при присваивании min значения")]
        public void DiscountNegTest(double value, Type expectedException)
        {
            var p = new Percent();
            Assert.Throws(expectedException, () => p.Discount = value);
        }

        /// <summary>
        /// Тестирование метода LastPrice на позитивных тестах
        /// </summary>
        /// <param name="value1">Значение свойства Price</param>
        /// <param name="value2">Значение свойства Discount</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(1200, 10, 1080, TestName = "Тестирование Percent.LastPrice при значениях Price = 1200 и Discount = 10.")]
        [TestCase(300, 50, 150, TestName = "Тестирование Percent.LastPrice при значениях Price = 300 и Discount = 50.")]
        [TestCase(220, 30, 154, TestName = "Тестирование Percent.LastPrice при значениях Price = 220 и Discount = 30.")]
        [TestCase(1000, 110, 0, TestName = "Тестирование Percent.LastPrice при значениях Price = 1000 и Discount = 110.")]

        public void LastPricePosTest(double value1, double value2, double expected)
        {
            var p = new Percent();
            p.Price = value1;
            p.Discount = value2;
            Assert.AreEqual(expected, p.LastPrice());
        }

        /// <summary>
        /// Тестирование метода LastPrice на негативном тесте
        /// </summary>
        /// <param name="value1">Значение свойства Price</param>
        /// <param name="value2">Значение свойства Discount</param>
        /// <param name="expectedException">Значение исключения</param>
        [Test]
        [TestCase(double.MaxValue, double.MaxValue, typeof(OverflowException), TestName = "Тестирование Percent.LastPrice при max значениях")]

        public void LastPriceNegTest(double value1, double value2, Type expectedException)
        {
            var p = new Percent();
            p.Price = value1;
            p.Discount = value2;
            try
            {
                checked
                {
                    p.LastPrice();
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}