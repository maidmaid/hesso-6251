using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using _6251App.Filter.Base;

namespace _6251Test
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void TestSubstitutedFilter()
        {
            var filter = Substitute.For<IFilter>();

            filter
                .Apply(Arg.Any<Bitmap>())
                .Returns(new Bitmap(50, 50));

            Assert.IsInstanceOfType(
                filter.Apply(new Bitmap(10, 20)), 
                typeof(Bitmap)
            );
        }
    }
}
