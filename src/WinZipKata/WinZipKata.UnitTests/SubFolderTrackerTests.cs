using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using WinZipKata.Core;
using WinZipKata.TestUtilities;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class SubFolderTrackerTests
    {
        private Support.SubFolderListComparer _subFolderListComparer;

        [SetUp]
        public void Setup()
        {
            Support.Fixture.Setup();
            _subFolderListComparer = new Support.SubFolderListComparer();
        }

        [TearDown]
        public void Cleanup()
        {
            Support.Fixture.Cleanup();
        }

        [Test]
        public void ShouldFindSubFolders()
        {
            // setup
            var parentPath = Support.Fixture.ParentPath;
            var firstFolderName = Support.FileSystem.GetFolderName(Support.Fixture.FirstFolderToZipPath);
            var secondFolderName = Support.FileSystem.GetFolderName(Support.Fixture.SecondFolderToZipPath);

            var expectedSubFolders = new List<SubFolder>
            {
                new SubFolder(firstFolderName),
                new SubFolder(secondFolderName)
            };

            // run
            var SUT = new SubFolderTracker();
            SUT.FindSubFolders(parentPath);
            var actualSubFolders = SUT.GetSubFolders();

            // assert
            Assert.That(actualSubFolders, Is.EqualTo(expectedSubFolders).Using(_subFolderListComparer));

        }

        [Test]
        public void ShouldDetermineIsSubFolderProcessed()
        {
            // setup


            // run


            // assert



        }

        [Test]
        public void ShouldGetStats()
        {
            // setup


            // run


            // assert



        }
    }
}
