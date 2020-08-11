using System;
using Xunit;
using FluentAssertions;

namespace Stringer.Tests
{
    public class StringExtentionsTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Return_True_When_IsNullOrEmpty(string value)
        {
            //Act
            var actionResult = value.IsNullOrEmpty();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("Something")]
        public void Should_Return_False_When_IsNotNullOrEmpty(string value)
        {
            //Act
            var actionResult = value.IsNullOrEmpty();

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("       ")]
        [InlineData(null)]
        public void Should_Return_True_When_IsNullOrWhiteSpace(string value)
        {
            //Act
            var actionResult = value.IsNullOrWhiteSpace();

            //Assert
            actionResult.Should().BeTrue();
        }     

        [Theory]
        [InlineData("Something")]
        [InlineData(" - ")]        
        public void Should_Return_False_When_IsNotNullOrWhiteSpace(string value)
        {
            //Act
            var actionResult = value.IsNullOrWhiteSpace();

            //Assert
            actionResult.Should().BeFalse();
        }          

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData(" ", null)]       
        [InlineData("ABC", "It's easy as 1,2,3")] 
        public void Should_Return_False_When_NotContains(string source, string compare)
        {
            //Act
            var actionResult = source.Contain(compare);

            //Assert
            actionResult.Should().BeFalse();
        } 

        [Theory]
        [InlineData("Text1", new string[] {"Text2", "Text3", "Text1"})]
        [InlineData("Text1", new string[] {"Text1"})]
        [InlineData("Text1 Text2", new string[] {"Text1", "Text1 Text3", "Text1 Text2"})]
        [InlineData("TEXT1", new string[] {"Text2", "Text3", "TEXT1"})]
        [InlineData("Text1", new string[] {"TEXT1", "Text1 Text2 TEXT3", "Text1 Text2"}, StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", new string[] {"text2"}, StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", new string[] {"TeXt2"}, StringComparison.OrdinalIgnoreCase)]
        public void Should_Return_True_When_StringInValues(string source, string[] values, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.In(values, stringComparison);

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("Text1", "Text1")]                
        [InlineData("TEXT1", "TEXT1")]
        [InlineData("Text1", "TEXT1", StringComparison.OrdinalIgnoreCase)]        
        [InlineData("TEXT2", "text2", StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", "TeXt2", StringComparison.OrdinalIgnoreCase)]
        public void Should_Return_True_When_StringIsEqual(string source, string value, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.Equal(value, stringComparison);

            //Assert
            actionResult.Should().BeTrue();
        }

        
        [Theory]
        [InlineData("Text1", "Text 1")]                        
        [InlineData("Text1", "TEXT1")]        
        [InlineData("TEXT2", "text2")]
        [InlineData("TEXT2", "TeXt2")]
        [InlineData("", "")]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData(null, null)]
        [InlineData(" ", "  ")]
        public void Should_Return_False_When_StringIsNotEqual(string source, string value, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.Equal(value, stringComparison);

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("", new string[]{})]
        [InlineData("", null)]
        [InlineData(null, new string[]{})]
        [InlineData(null, null)]
        [InlineData("Text1", new string[]{"", "", ""})]
        [InlineData("Text1", new string[]{"1Text", "ABC", "8989"})]
        [InlineData("Text1", new string[]{"Text1 ", "C", "9"})]
        [InlineData("Text1", new string[]{"TEXT1"})]
        public void Should_Return_False_When_StringNotInValues(string source, string[] values)
        {            
            //Act
            var actionResult = source.In(values);

            //Assert
            actionResult.Should().BeFalse();
        }

        [Fact]
        public void Should_Return_True_When_StringIsNull()
        {
            //Arrange
            string source = null;
            
            //Act
            var actionResult = source.IsNull();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ABC")]
        public void Should_Return_False_When_StringIsNotNull(string source)
        {            
            //Act
            var actionResult = source.IsNull();

            //Assert
            actionResult.Should().BeFalse();
        }

        [Fact]
        public void Should_Return_True_When_StringIsEmpty()
        {
            //Arrange
            string source = string.Empty;
            
            //Act
            var actionResult = source.IsEmpty();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("ABC")]
        public void Should_Return_False_When_StringIsNotEmpty(string source)
        {
            //Act
            var actionResult = source.IsEmpty();

            //Assert
            actionResult.Should().BeFalse();
        }
    }
}
