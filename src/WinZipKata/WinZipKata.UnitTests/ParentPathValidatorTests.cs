using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using WinZipKata.Core;
using WinZipKata.TestUtilities;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class ParentPathValidatorTests
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
        public void ShouldValidateParentPath_Valid_GivenPathThatExists()
        {
            // setup
            var existingPath = Support.Fixture.ParentPath;

            // run
            var SUT = new ParentPathValidator(existingPath);
            var result = SUT.ValidateParentPath();

            // assert
            Assert.That(result, Is.True);

        }

        [Test]
        public void ShouldValidateParentPath_NotValid_GivenPathThatDoesNotExist()
        {
            // setup
            const string nonExistentPathPart = @"Path\Does\Not\Exist";
            var nonExistentPath = Path.Combine(Support.Fixture.BaseCDrivePath, nonExistentPathPart);

            // run
            var SUT = new ParentPathValidator(nonExistentPath);
            var result = SUT.ValidateParentPath();

            // assert
            Assert.That(result, Is.False);

        }

        [Test]
        public void ShouldValidateParentPath_NotValid_GivenPathThatContainsChildFolderNamed_Output()
        {
            // setup
            var parentPath = Support.Fixture.ParentPath;
            var outputFolder = Support.Fixture.OutputFolder;
            Directory.CreateDirectory(outputFolder);

            // run
            var SUT = new ParentPathValidator(parentPath);
            var result = SUT.ValidateParentPath();

            // assert
            Assert.That(result, Is.False);

        }
    }
}
