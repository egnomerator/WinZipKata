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
            _firstFolderToZipPath = Path.Combine(_baseCDrivePath, @"Parent\FolderToZip1");
            _secondFolderToZipPath = Path.Combine(_baseCDrivePath, @"Parent\FolderToZip2");
        }

        [Test]
        public void ShouldValidateParentPathGivenValidPath()
        {
            // setup
            var parentPath = _parentPath;

            // run
            bool result = Zipper.ValidateParentPath(parentPath);

            // assert
            Assert.That(result, Is.True);

        }
    }
}
