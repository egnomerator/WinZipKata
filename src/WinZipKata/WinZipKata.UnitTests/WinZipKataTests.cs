﻿using NUnit.Framework;
using System.Windows.Forms;
using WinZipKata.TestUtilities;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class WinZipKataTests
    {
        [SetUp]
        public void Setup()
        {
            Support.Fixture.Setup();
        }

        [TearDown]
        public void Cleanup()
        {
            Support.Fixture.Cleanup();
        }

        [Test]
        public void ShouldResetParentPathToEmptyString()
        {
            // setup
            var existingPath = Support.Fixture.ParentPath;
            var path = new TextBox();
            path.Text = Support.Fixture.ParentPath;

            // run
            var SUT = new ParentPath(path);
            SUT.Reset();

            // assert
            Assert.That(path.Text, Is.Empty);

        }

        [Test]
        public void ShouldDetermineThatParentPathChanged()
        {
            // setup
            var existingPath = Support.Fixture.ParentPath;
            var path = new TextBox();
            var newPath = string.Empty;

            // run
            var SUT = new ParentPath(path);
            path.Text = newPath;
            var isChanged = SUT.IsChanged();

            // assert
            Assert.That(isChanged, Is.True);

        }

        [Test]
        public void ShouldDetermineThatParentPathDidNotChanged()
        {
            // setup
            var existingPath = Support.Fixture.ParentPath;
            var path = new TextBox();
            var newPath = string.Empty;

            // run
            var SUT = new ParentPath(path);
            path.Text = newPath;
            var isChanged = SUT.IsChanged();

            // assert
            Assert.That(isChanged, Is.False);

        }
    }
}
