using NUnit.Framework;
using System.IO;
using WinZipKata.TestUtilities;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class WinZipKataTests
    {
        [Test]
        public void ShouldDoAthing()
        {
            // setup
            var folderTozip = new DirectoryInfo(Support.Fixture.FirstFolderToZipPath);
            var zipFileName = $"{folderTozip.Name}.zip";

            // run
            var result = Zipper.ZipFileCanBeCreated(folderTozip);

            // assert
            Assert.That(result, Is.True);

        }
    }
}
