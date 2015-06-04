using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using _6251App;
using _6251App.Filter.Base;
using _6251App.FileManipulation.Base;

namespace _6251Test
{
    [TestClass]
    public class AppTest
    {
        protected IFilter GetSubstitutedFilter()
        {
            IFilter filter = Substitute.For<IFilter>();

            filter
                .Apply(Arg.Any<Bitmap>())
                .Returns(new Bitmap(50, 50));

            return filter;
        }

        protected IFileManipulation GetSubstitutedFileManipulation()
        {
            IFileManipulation manipuler = Substitute.For<IFileManipulation>();

            manipuler
                .Load()
                .Returns(new Bitmap(50, 50));

            manipuler.Save(Arg.Any<Bitmap>());

            return manipuler;
        }

        [TestMethod]
        public void TestSubstitutedFilter()
        {
            IFilter filter = GetSubstitutedFilter();

            Assert.IsInstanceOfType(filter.Apply(new Bitmap(10, 20)), typeof(Bitmap));
        }

        [TestMethod]
        public void TestSubstitutedFileManipulation()
        {
            IFileManipulation manipuler = GetSubstitutedFileManipulation();

            Assert.IsInstanceOfType(manipuler.Load(), typeof(Bitmap));
        }

        [TestMethod]
        public void TestApp()
        {
            App app = new App();
            app.manipuler = GetSubstitutedFileManipulation();
            app.filter = GetSubstitutedFilter();

            app.btnOpenOriginal_Click(new Object(), new EventArgs());
            app.btnSaveNewImage_Click(new Object(), new EventArgs());
        }
    }
}
