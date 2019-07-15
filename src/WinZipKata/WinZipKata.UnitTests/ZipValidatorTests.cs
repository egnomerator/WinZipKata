using NUnit.Framework;
using System.IO;
using WinZipKata.Core;
using WinZipKata.TestUtilities;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class ZipValidatorTests
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
            var folderTozipPath = Support.Fixture.FirstFolderToZipPath;
            var destinationPath = Support.Fixture.OutputFolder;

            // run
            var SUT = new ZipValidator(folderTozipPath, destinationPath);
            var canCreate = SUT.ZipFileCanBeCreated();

            // assert
            Assert.That(canCreate, Is.True);

        }

        [Test]
        public void ShouldDetermineZipFileCanNotBeCreated_SinceItAlreadyExists()
        {
            // setup
            var folderTozipPath = Support.Fixture.FirstFolderToZipPath;
            var destinationPath = Support.Fixture.OutputFolder;

            var zipFilePath = Path.Combine(destinationPath, $"{new DirectoryInfo(folderTozipPath).Name}.zip");
            Support.FileSystem.CreateZipOutput(zipFilePath);

            // run
            var SUT = new ZipValidator(folderTozipPath, destinationPath);
            var canCreate = SUT.ZipFileCanBeCreated();

            // assert
            Assert.That(canCreate, Is.False);

        }
    }
}
