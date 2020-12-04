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
        public void IsNullOrEmpty_ShouldReturnTrue_WhenIsNullOrEmpty(string value)
        {
            //Act
            var actionResult = value.IsNullOrEmpty();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("Something")]
        public void IsNullOrEmpty_ShouldReturnFalse_WhenIsNotNullOrEmpty(string value)
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
        public void IsNullOrWhiteSpace_ShouldReturnTrue_WhenIsNullOrWhiteSpace(string value)
        {
            //Act
            var actionResult = value.IsNullOrWhiteSpace();

            //Assert
            actionResult.Should().BeTrue();
        }     

        [Theory]
        [InlineData("Something")]
        [InlineData(" - ")]        
        public void IsNullOrWhiteSpace_ShouldReturnFalse_WhenIsNotNullOrWhiteSpace(string value)
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
        public void Contain_ShouldReturnFalse_WhenNotContains(string compare, string source)
        {
            //Act
            var actionResult = source.Contain(compare);

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("1,2,3", "It's easy as 1,2,3")]
        [InlineData("123456", "Some 123456 text")]
        public void Contain_ShouldReturnTrue_WhenContains(string compare, string source)
        {
            //Act
            var actionResult = source.Contain(compare);

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("Text1", new string[] {"Text2", "Text3", "Text1"})]
        [InlineData("Text1", new string[] {"Text1"})]
        [InlineData("Text1 Text2", new string[] {"Text1", "Text1 Text3", "Text1 Text2"})]
        [InlineData("TEXT1", new string[] {"Text2", "Text3", "TEXT1"})]
        [InlineData("Text1", new string[] {"TEXT1", "Text1 Text2 TEXT3", "Text1 Text2"}, StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", new string[] {"text2"}, StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", new string[] {"TeXt2"}, StringComparison.OrdinalIgnoreCase)]
        public void In_ShouldReturnTrue_WhenStringInValues(string source, string[] values, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.In(values, stringComparison);

            //Assert
            actionResult.Should().BeTrue();
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
        public void In_ShouldReturnFalse_WhenStringNotInValues(string source, string[] values)
        {            
            //Act
            var actionResult = source.In(values);

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("Text1", "Text1")]                
        [InlineData("TEXT1", "TEXT1")]
        [InlineData("Text1", "TEXT1", StringComparison.OrdinalIgnoreCase)]        
        [InlineData("TEXT2", "text2", StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", "TeXt2", StringComparison.OrdinalIgnoreCase)]
        public void Equal_ShouldReturnTrue_WhenStringIsEqual(string source, string value, StringComparison stringComparison = StringComparison.Ordinal)
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
        public void Equal_ShouldReturnFalse_WhenStringIsNotEqual(string source, string value, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.Equal(value, stringComparison);

            //Assert
            actionResult.Should().BeFalse();
        }


        [Fact]
        public void IsNull_ShouldReturnTrue_WhenStringIsNull()
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
        public void IsNull_ShouldReturnFalse_WhenStringIsNotNull(string source)
        {            
            //Act
            var actionResult = source.IsNull();

            //Assert
            actionResult.Should().BeFalse();
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenStringIsEmpty()
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
        public void IsEmpty_ShouldReturnFalse_WhenStringIsNotEmpty(string source)
        {
            //Act
            var actionResult = source.IsEmpty();

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("ABC")]
        public void IsNotEmpty_ShouldReturnTrue_WhenStringIsNotEmpty(string source)
        {
            //Act
            var actionResult = source.IsNotEmpty();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Fact]        
        public void IsNotEmpty_ShouldReturnFalse_WhenStringIsNotEmpty()
        {
            //Arrange
            var source = "";

            //Act
            var actionResult = source.IsNotEmpty();

            //Assert
            actionResult.Should().BeFalse();
        }


        [Fact]
        public void IsNotNull_ShouldReturnFalse_WhenStringIsNull()
        {
            //Arrange
            string source = null;

            //Act
            var actionResult = source.IsNotNull();

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ABC")]
        public void IsNotNull_ShouldReturnTrue_WhenStringIsNotNull(string source)
        {
            //Act
            var actionResult = source.IsNotNull();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsNotNullOrEmpty_ShouldReturnFalse_WhenIsNullOrEmpty(string value)
        {
            //Act
            var actionResult = value.IsNotNullOrEmpty();

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("Something")]
        public void IsNotNullOrEmpty_ShouldReturnTrue_WhenIsNotNullOrEmpty(string value)
        {
            //Act
            var actionResult = value.IsNotNullOrEmpty();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("       ")]
        [InlineData(null)]
        public void IsNotNullOrWhiteSpace_ShouldReturnFalse_WhenIsNullOrWhiteSpace(string value)
        {
            //Act
            var actionResult = value.IsNotNullOrWhiteSpace();

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("Something")]
        [InlineData(" - ")]
        public void IsNotNullOrWhiteSpace_ShouldReturnTrue_WhenIsNotNullOrWhiteSpace(string value)
        {
            //Act
            var actionResult = value.IsNotNullOrWhiteSpace();

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData(" ", null)]
        [InlineData("ABC", "It's easy as 1,2,3")]
        public void NotContain_ShouldReturnTrue_WhenNotContains(string compare, string source)
        {
            //Act
            var actionResult = source.NotContain(compare);

            //Assert
            actionResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("1,2,3", "It's easy as 1,2,3")]
        [InlineData("123456", "Some 123456 text")]
        public void NotContain_ShouldReturnFalse_WhenContains(string compare, string source)
        {
            //Act
            var actionResult = source.NotContain(compare);

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("Text1", new string[] { "Text2", "Text3", "Text1" })]
        [InlineData("Text1", new string[] { "Text1" })]
        [InlineData("Text1 Text2", new string[] { "Text1", "Text1 Text3", "Text1 Text2" })]
        [InlineData("TEXT1", new string[] { "Text2", "Text3", "TEXT1" })]
        [InlineData("Text1", new string[] { "TEXT1", "Text1 Text2 TEXT3", "Text1 Text2" }, StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", new string[] { "text2" }, StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", new string[] { "TeXt2" }, StringComparison.OrdinalIgnoreCase)]
        public void NotIn_ShouldReturnFalse_WhenStringInValues(string source, string[] values, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.NotIn(values, stringComparison);

            //Assert
            actionResult.Should().BeFalse();
        }

        [Theory]
        [InlineData("", new string[] { })]
        [InlineData("", null)]
        [InlineData(null, new string[] { })]
        [InlineData(null, null)]
        [InlineData("Text1", new string[] { "", "", "" })]
        [InlineData("Text1", new string[] { "1Text", "ABC", "8989" })]
        [InlineData("Text1", new string[] { "Text1 ", "C", "9" })]
        [InlineData("Text1", new string[] { "TEXT1" })]
        public void NotIn_ShouldReturnTrue_WhenStringNotInValues(string source, string[] values)
        {
            //Act
            var actionResult = source.NotIn(values);

            //Assert
            actionResult.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("Text1", "Text1")]
        [InlineData("TEXT1", "TEXT1")]
        [InlineData("Text1", "TEXT1", StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", "text2", StringComparison.OrdinalIgnoreCase)]
        [InlineData("TEXT2", "TeXt2", StringComparison.OrdinalIgnoreCase)]
        public void NotEqual_ShouldReturnFalse_WhenStringIsEqual(string source, string value, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.NotEqual(value, stringComparison);

            //Assert
            actionResult.Should().BeFalse();
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
        public void NotEqual_ShouldReturnTrue_WhenStringIsNotEqual(string source, string value, StringComparison stringComparison = StringComparison.Ordinal)
        {
            //Act
            var actionResult = source.NotEqual(value, stringComparison);

            //Assert
            actionResult.Should().BeTrue();
        }
    }
}
