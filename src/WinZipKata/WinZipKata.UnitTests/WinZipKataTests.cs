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

        [Test]
        public void ShouldDetermineZipFileCanNotBeCreated_SinceItAlreadyExists()
        {
            // setup
            var folderTozip = new DirectoryInfo(Support.Fixture.FirstFolderToZipPath);
            var zipFileName = $"{folderTozip.Name}.zip";

            Directory.CreateDirectory(Support.Fixture.OutputFolder);
            var file = File.Create(Path.Combine(Support.Fixture.OutputFolder, zipFileName));
            file.Close();

            // run
            var result = Zipper.ZipFileCanBeCreated(zipFileName, Support.Fixture.OutputFolder);

            // assert
            Assert.That(result, Is.False);

        }
    }
}
