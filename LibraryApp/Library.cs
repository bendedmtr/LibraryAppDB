namespace LibraryApp
{
    public class Library
    {
        private readonly string _name;

        // Minden fizikai példány egy külön string bejegyzés a listában.
        // Pl. 3 példány után: _availableBooks = ["Dune", "Dune", "Dune"]
        // Kölcsönzéskor: egy bejegyzés átkerül _availableBooks -> _borrowedBooks
        // Visszahozáskor: egy bejegyzés visszakerül _borrowedBooks -> _availableBooks
        private readonly List<string> _availableBooks;
        private readonly List<string> _borrowedBooks;

        // name nem lehet null vagy üres
        public Library(string name)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        // Minden példány egy külön bejegyzés — AddBook("Dune", 3) -> három "Dune" kerül a listába
        // copies >= 1
        public void AddBook(string title, int copies)
        {
            throw new NotImplementedException();
        }

        // Visszatér false-al ha nincs elérhető példány a megadott címből
        public bool BorrowBook(string title)
        {
            throw new NotImplementedException();
        }

        // Visszatér false-al ha nincs kikölcsönzött példány a megadott címből
        public bool ReturnBook(string title)
        {
            throw new NotImplementedException();
        }

        // Az _availableBooks listában szereplő példányok számát adja vissza — -1 ha a cím nem szerepel
        public int GetAvailableCopies(string title)
        {
            throw new NotImplementedException();
        }

        // Visszatér true-val ha legalább egy szabad példány elérhető
        public bool IsAvailable(string title)
        {
            throw new NotImplementedException();
        }

        // Az összes egyedi cím száma (elérhető és kikölcsönzött együtt)
        public int GetTotalTitles()
        {
            throw new NotImplementedException();
        }

        // Az összes jelenleg kikölcsönzött példány száma
        public int GetTotalBorrowed()
        {
            throw new NotImplementedException();
        }

        // Eltávolít minden példányt — visszatér false ha a cím nem létezik
        public bool RemoveBook(string title)
        {
            throw new NotImplementedException();
        }
    }
}
