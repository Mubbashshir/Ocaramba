﻿using System.IO;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Helpers;

namespace Objectivity.Test.Automation.UnitTests.Tests
{
    [TestFixture()]
    [TestFixture, Parallelizable(ParallelScope.Self)]
    public class FilesHelperTests
    {
        [Test()]
        public void GetFilesOfGivenTypeFromAllSubFolderTest()
        {
            var files = FilesHelper.GetFilesOfGivenTypeFromAllSubFolders(TestContext.CurrentContext.TestDirectory, FileType.Xls);
            Assert.IsTrue(files.Count > 0);
        }

        [Test()]
        public void GetFilesOfGivenTypeFromAllSubFoldersTest()
        {
            var files = FilesHelper.GetFilesOfGivenTypeFromAllSubFolders(TestContext.CurrentContext.TestDirectory, FileType.Xml, "Driven");
            Assert.IsTrue(files.Count > 0);
        }

        [Test()]
        public void GetAllFilesFromAllSubFoldersTest()
        {
            var files = FilesHelper.GetAllFilesFromAllSubFolders(TestContext.CurrentContext.TestDirectory);
            Assert.IsTrue(files.Count > 0);
        }

        [Test()]
        public void GetAllFilesFromAllSubFoldersPrefixTest()
        {
            var files = FilesHelper.GetAllFilesFromAllSubFolders(TestContext.CurrentContext.TestDirectory, "Common.dll");
            Assert.IsTrue(files.Count > 0);
            File.Create("testfile.txt");

        }

        [Test()]
        public void RenameDeleteFileTest()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "testfile1.txt");
            File.Create(path).Close();
            path = Path.Combine(TestContext.CurrentContext.TestDirectory, "testfile2.txt");
            File.Create(path).Close();
            FilesHelper.RenameFile(BaseConfiguration.ShortTimeout, "testfile1.txt", "testfile2.txt", TestContext.CurrentContext.TestDirectory);
        }

        [Test()]
        public void CopyDeleteFileTest()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "testfile3.txt");
            File.Create(path).Close();
            path = Path.Combine(TestContext.CurrentContext.TestDirectory, "testfile4.txt");
            File.Create(path).Close();
            FilesHelper.CopyFile(BaseConfiguration.ShortTimeout, "testfile3.txt", "testfile4.txt", TestContext.CurrentContext.TestDirectory);
        }
    }
}