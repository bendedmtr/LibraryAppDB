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

        // ---- AddBook ----

        [TestMethod]
        public void AddBook_NewTitle()
        {
            var lib = new Library("City Library");
            lib.AddBook("Dune", 2);
            Assert.AreEqual(1, lib.GetTotalTitles());
        }
        // TODO: ugyanazt a címet hozzáadva újabb bejegyzések kerülnek az _availableBooks listába, és GetTotalTitles nem változik
        // TODO: copies értéke 0 vagy negatív esetén ArgumentException-t kell dobni

        // ---- BorrowBook ----

        [TestMethod]
        public void BorrowBook_AvailableCopy()
        {
            var lib = CreateDefaultLibrary(); // Dune: 3 példány
            bool result = lib.BorrowBook("Dune");
            Assert.IsTrue(result);
            Assert.AreEqual(2, lib.GetAvailableCopies("Dune"));
        }
        // TODO: nem létező cím esetén false-t kell visszaadni és nem dob kivételt
        // TODO: az összes példány kikölcsönzése után újabb kölcsönzés false-t ad vissza

        // ---- ReturnBook ----

        [TestMethod]
        public void ReturnBook_BorrowedCopy()
        {
            var lib = CreateDefaultLibrary();
            lib.BorrowBook("1984");
            bool result = lib.ReturnBook("1984");
            Assert.IsTrue(result);
            Assert.AreEqual(1, lib.GetAvailableCopies("1984"));
        }
        // TODO: nem létező cím visszahozásakor false-t kell visszaadni
        // TODO: olyan könyv visszahozásakor, amelyből semmi sincs kikölcsönzve, false-t kell adni

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
