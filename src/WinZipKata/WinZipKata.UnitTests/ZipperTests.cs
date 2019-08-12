using NUnit.Framework;
using System.IO;
using System.Threading;
using WinZipKata.Core;
using WinZipKata.TestUtilities;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class ZipperTests
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
        public void ShouldZipFolder()
        {
            // setup
            var destinationPath = Support.Fixture.OutputFolder;
            Support.FileSystem.CreateFolder(destinationPath);

            var folderToZipPath = Support.Fixture.FirstFolderToZipPath;
            var zipFilePath = Path.Combine(destinationPath, $"{new DirectoryInfo(folderToZipPath).Name}.zip");

            // run
            var SUT = new Zipper(folderToZipPath, zipFilePath);
            SUT.ZipFolder(CancellationToken.None);

            // assert
            Assert.That(File.Exists(zipFilePath), Is.True);

        }
    }
}
