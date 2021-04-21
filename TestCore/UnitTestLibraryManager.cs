using Core.LibraryHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCore
{
    [TestClass]
    public class UnitTestLibraryManager
    {
        [TestMethod]
        public void LoadLibraries()
        {
            var libraryManager = new LibraryManager("..\\bin");
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void DataConverterLibrariesLoaderCheckDuplicates()
        {
            var libraryManager = new LibraryManager("..\\bin");
            Assert.IsTrue(libraryManager.DataConverterLibrariesLoader.CheckDuplicates);
        }
    }
}