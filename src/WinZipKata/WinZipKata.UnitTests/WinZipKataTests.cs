using NUnit.Framework;
using System.IO;
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
        public void ShouldDetermineZipFileCanBeCreated()
        {
            // setup
            var folderTozip = new DirectoryInfo(Support.Fixture.FirstFolderToZipPath);
            var zipFileName = $"{folderTozip.Name}.zip";

            // run
            var result = Zipper.ZipFileCanBeCreated(zipFileName, Support.Fixture.OutputFolder);

            // assert
            Assert.That(result, Is.True);

        }
    }
}
