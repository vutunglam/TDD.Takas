using Xunit;

namespace TDD.Takas.Tests
{
    public class InputParserTest
    {
        private InputParser parser = new InputParser();

        [Fact]
        public void TestParseEmptyString()
        {
            parser.Input = string.Empty;
            Assert.Equal(new string[] { ",", "\n" }, parser.Delimiters);
            Assert.Equal(new int[] { 0 }, parser.Numbers);
        }

        [Fact]
        public void TestParseOneNumber()
        {
            parser.Input = "9";
            Assert.Equal(new string[] { ",", "\n" }, parser.Delimiters);
            Assert.Equal(new int[] { 9 }, parser.Numbers);
        }

        [Fact]
        public void TestParseTwoNumbers()
        {
            parser.Input = "9,1";
            Assert.Equal(new string[] { ",", "\n" }, parser.Delimiters);
            Assert.Equal(new int[] { 9, 1 }, parser.Numbers);
        }

        [Fact]
        public void TestParseManyNumbers()
        {
            parser.Input = "9,1,0";
            Assert.Equal(new string[] { ",", "\n" }, parser.Delimiters);
            Assert.Equal(new int[] { 9, 1, 0 }, parser.Numbers);
        }

        [Fact]
        public void TestParseNumbersWithNewLine()
        {
            parser.Input = "1\n2,3";
            Assert.Equal(new string[] { ",", "\n" }, parser.Delimiters);
            Assert.Equal(new int[] { 1, 2, 3 }, parser.Numbers);
        }

        [Fact]
        public void TestParseNumbersWithCustomDelimiter()
        {
            parser.Input = ";\n1;2";
            Assert.Equal(new string[] { ";" }, parser.Delimiters);
            Assert.Equal(new int[] { 1, 2 }, parser.Numbers);
        }

        [Fact]
        public void TestHasCustomDelimiter()
        {
            Assert.True(InputParser.HasCustomDelimiter(";\n1;2"));
            Assert.False(InputParser.HasCustomDelimiter("1\n2,3"));
            Assert.False(InputParser.HasCustomDelimiter("1,2,3"));
        }
    }
}