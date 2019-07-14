using NUnit.Framework;
using System;
using System.IO;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class WinZipKataTests
    {
        private const string CDrive = "C";
        private const string ParentFolder = "Parent";
        private const string Output = "Output";
        private string _solutionProjectBasePath;
        private string _baseCDrivePath;
        private string _parentPath;
        private string _outputFolder;
        private string _firstFolderToZipPath;
        private string _secondFolderToZipPath;

        [SetUp]
        public void Setup()
        {
            var localPath = Path.GetDirectoryName(new Uri(typeof(WinZipKataTests).Assembly.CodeBase).LocalPath);
            if (localPath == null) throw new Exception();
            _solutionProjectBasePath = new DirectoryInfo(localPath).Parent?.Parent?.FullName;
            if (_solutionProjectBasePath == null) throw new Exception();

            _baseCDrivePath = Path.Combine(_solutionProjectBasePath, CDrive);
            _parentPath = Path.Combine(_baseCDrivePath, ParentFolder);
            _outputFolder = Path.Combine(_parentPath, Output);
            _firstFolderToZipPath = Path.Combine(_parentPath, @"FolderToZip1");
            _secondFolderToZipPath = Path.Combine(_parentPath, @"FolderToZip2");
        }

        [TearDown]
        public void Cleanup()
        {
            if (Directory.Exists(_outputFolder)) Directory.Delete(_outputFolder, recursive: true);
        }

        [Test]
        public void ShouldValidateParentPath_Valid_GivenPathThatExists()
        {
            // setup
            var existingPath = _parentPath;

            // run
            bool result = Zipper.ValidateParentPath(existingPath);

            // assert
            Assert.That(result, Is.True);

        }

        [Test]
        public void ShouldValidateParentPath_NotValid_GivenPathThatDoesNotExist()
        {
            // setup
            const string nonExistentPathPart = @"Path\Does\Not\Exist";
            var nonExistentPath = Path.Combine(_baseCDrivePath, nonExistentPathPart);

            // run
            bool result = Zipper.ValidateParentPath(nonExistentPath);

            // assert
            Assert.That(result, Is.False);

        }

        [Test]
        public void ShouldValidateParentPath_NotValid_GivenPathThatContainsChildFolderNamed_Output()
        {
            // setup
            var parentPath = _parentPath;
            var outputFolder = Path.Combine(_parentPath, Output);
            if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);

            // run
            bool result = Zipper.ValidateParentPath(parentPath);

            // assert
            Assert.That(result, Is.False);

        }
    }
}
