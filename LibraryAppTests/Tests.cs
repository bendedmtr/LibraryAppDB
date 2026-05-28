using LibraryApp;

namespace LibraryAppTests
{
    [TestClass]
    public class Tests
    {
        private Library CreateDefaultLibrary()
        {
            var lib = new Library("City Library");
            lib.AddBook("Dune", 3);
            lib.AddBook("1984", 1);
            return lib;
        }

        // ---- Constructor ----

        [TestMethod]
        public void Constructor_ValidName()
        {
            var lib = new Library("City Library");
            Assert.AreEqual("City Library", lib.GetName());
        }
        // TODO: null vagy üres névvel létrehozva ArgumentException-t kell dobni
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NullName()
        {
            var lib = new Library(null);
        }

        // ---- AddBook ----

        [TestMethod]
        public void AddBook_NewTitle()
        {
            var lib = new Library("City Library");
            lib.AddBook("Dune", 2);
            Assert.AreEqual(1, lib.GetTotalTitles());
        }
        // TODO: ugyanazt a címet hozzáadva újabb bejegyzések kerülnek az _availableBooks listába, és GetTotalTitles nem változik
        [TestMethod]
        public void AddBook_ExistingTitle()
        {
            var lib = CreateDefaultLibrary();
            lib.AddBook("Dune", 2);
            Assert.AreEqual(1, lib.GetTotalTitles());
            Assert.AreEqual(5, lib.GetAvailableCopies("Dune"));
        }
        // TODO: copies értéke 0 vagy negatív esetén ArgumentException-t kell dobni
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBook_InvalidCopies()
        {
            var lib = new Library("City Library");
            lib.AddBook("Dune", 0);
        }

        // ---- BorrowBook ----

        [TestMethod]
        public void BorrowBook_AvailableCopy()
        {
            var lib = CreateDefaultLibrary();
            bool result = lib.BorrowBook("Dune");
            Assert.IsTrue(result);
            Assert.AreEqual(2, lib.GetAvailableCopies("Dune"));
        }
        // TODO: nem létező cím esetén false-t kell visszaadni és nem dob kivételt
        [TestMethod]
        public void BorrowBook_NonExistingTitle()
        {
            var lib = CreateDefaultLibrary();
            Assert.IsFalse(lib.BorrowBook("NonExisting"));
        }
        // TODO: az összes példány kikölcsönzése után újabb kölcsönzés false-t ad vissza
        [TestMethod]
        public void BorrowBook_AllCopiesBorrowed()
        {
            var lib = CreateDefaultLibrary();
            Assert.IsTrue(lib.BorrowBook("1984"));
            Assert.IsFalse(lib.BorrowBook("1984"));
        }

        // ---- ReturnBook ----

        [TestMethod]
        public void ReturnBook_BorrowedCopy()
        {
            var libr = CreateDefaultLibrary();
            libr.BorrowBook("1984");
            bool result = libr.ReturnBook("1984");
            Assert.IsTrue(result);
            Assert.AreEqual(1, libr.GetAvailableCopies("1984"));
        }
        // TODO: nem létező cím visszahozásakor false-t kell visszaadni
        [TestMethod]
        public void ReturnBook_NonExistingTitle()
        {
            var libr = CreateDefaultLibrary();
            Assert.IsFalse(libr.ReturnBook("Nemlétez Ödön"));
        }

        // TODO: olyan könyv visszahozásakor, amelyből semmi sincs kikölcsönzve, false-t kell adni
        [TestMethod]
        public void ReturnBook_NotBorrowed()
        {
            var libr = CreateDefaultLibrary();
            Assert.IsFalse(libr.ReturnBook("Dune"));
        }

        // ---- GetAvailableCopies ----

        [TestMethod]
        public void GetAvailableCopies_AfterBorrow()
        {
            var lib = CreateDefaultLibrary(); // Dune: 3 példány
            lib.BorrowBook("Dune");
            lib.BorrowBook("Dune");
            Assert.AreEqual(1, lib.GetAvailableCopies("Dune"));
        }
        // TODO: nem létező cím esetén -1-et kell visszaadni

        // ---- IsAvailable ----

        [TestMethod]
        public void IsAvailable_BookWithFreeCopies()
        {
            var lib = CreateDefaultLibrary();
            Assert.IsTrue(lib.IsAvailable("Dune"));
        }
        // TODO: teljesen kikölcsönzött könyv esetén false-t kell visszaadni
        // TODO: nem létező cím esetén false-t kell visszaadni

        // ---- GetTotalBorrowed ----

        [TestMethod]
        public void GetTotalBorrowed_AfterMultipleBorrows()
        {
            var lib = CreateDefaultLibrary();
            lib.BorrowBook("Dune");
            lib.BorrowBook("1984");
            Assert.AreEqual(2, lib.GetTotalBorrowed());
        }
        // TODO: újonnan létrehozott, üres könyvtárban GetTotalBorrowed() nullát ad vissza
        // TODO: visszahozás után a kikölcsönzött darabszám helyesen csökken

        // ---- RemoveBook ----

        [TestMethod]
        public void RemoveBook_ExistingTitle()
        {
            var lib = CreateDefaultLibrary(); // 2 cím
            bool result = lib.RemoveBook("1984");
            Assert.IsTrue(result);
            Assert.AreEqual(1, lib.GetTotalTitles());
        }
        // TODO: nem létező cím eltávolításakor false-t kell visszaadni
        // TODO: eltávolítás után a cím már nem érhető el, GetAvailableCopies -1-et ad vissza
    }
}
