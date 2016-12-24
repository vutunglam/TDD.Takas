using System;
using System.Runtime.InteropServices.ComTypes;
using TDD.Takas;
using Xunit;

namespace TDD.Takas.Tests
{
    public class StringCalculatorTests
    {
        private StringCalculator cal = new StringCalculator();

        [Fact]
        public void TestAddEmptyString()
        {
            Assert.Equal(0, cal.Add(""));
        }

        [Fact]
        public void TestAddOneNumber()
        {
            Assert.Equal(9, cal.Add("9"));
        }

        [Fact]
        public void TestAddTwoNumbers()
        {
            Assert.Equal(10, cal.Add("9,1"));
        }

        [Fact]
        public void TestAddManyNumbers()
        {
            Assert.Equal(10, cal.Add("9,1,0"));
            Assert.Equal(20, cal.Add("9,1,1,9"));
        }

        [Fact]
        public void TestAddNumbersWithNewLine()
        {
            var cal = new StringCalculator();
            Assert.Equal(6, cal.Add("1\n2,3"));
        }

        [Fact]
        public void TestAddNumbersWithCustomDelimiter()
        {
            Assert.Equal(3, cal.Add(";\n1;2"));
            Assert.Equal(10, cal.Add("&\n1 & 2 & 7"));
        }

        [Fact]
        public void TestAddNumbersWithNegative()
        {
            var exception = Assert.Throws<Exception>(() => { cal.Add("1,-2"); });

            Assert.True(exception.Message.Equals("negatives not allowed: -2"));
        }

        [Fact]
        public void TestAddNumbersWithMultipleNegatives()
        {
            var exception = Assert.Throws<Exception>(() => { cal.Add("1,-2,4,-3,5,-6"); });

            Assert.True(exception.Message.Equals("negatives not allowed: -2 -3 -6"));
        }
    }
}