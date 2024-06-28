using BetUp.Logger;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Interfaces;
using System.Linq.Expressions;

namespace BetUpTests
{
    public class UnitTest1
    {
        //single test
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
            Assert.Equal(2, 2);
        }

        //multi test
        [Theory]
        [InlineData(1, 2, 2)]
        public void Test2(int x, int y, int z)
        {
            Assert.Equal(x * y, z);
        }

        //Check for exception
        [Fact]
        public void Test3()
        {
            Assert.Throws<DivideByZeroException>(() => { var a = 1;var b = 0; var c = a / b; });
        }
    }
}