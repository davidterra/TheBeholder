using Xunit;
using TheBeholder.Business;
using System;

namespace TheBeholder.Tests
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("30,04")]
        [InlineData("-18,01%")]
        [InlineData("1.834.440.000,00")]
        public void Should_be_convert_a_decimal(string str)
        {
            // Arrange

            // Act
            var result = str.ToMonetary();

            // Assert

            Assert.IsType<decimal>(result);
            
        }

        [Fact]
        public void Should_convert()
        {
            // Arrange

            // Act

            var test1 = "30,04".ToMonetary();
            var test2 = "-18,01%".ToMonetary();
            var test3 = "1.834.440.000,25".ToMonetary();
            
            // Assert

            Assert.Equal(30.04m, test1);
            Assert.Equal(-0.1801m, test2);
            Assert.Equal(1834440000.25m, test3);
        }
    }
}