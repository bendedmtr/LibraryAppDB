# Könyvtár — Unit tesztelés & Git

## Áttekintés

Egy részben elkészített C# solution-t kapsz.  
Az osztály és a metódus-szignatúrák adottak, de **a logika nincs implementálva**.  
A feladatod: bővíteni a teszteket, implementálni a logikát, és a munkát Git-ben követni.

---

## Az adatszerkezet működése

A `Library` osztály két `List<string>` listát használ a könyvek nyilvántartásához:

- `_availableBooks` — a jelenleg elérhető (ki nem kölcsönzött) példányok listája
- `_borrowedBooks` — a jelenleg kikölcsönzött példányok listája

Minden egyes fizikai példány egy külön bejegyzés a listában.  
Például 3 példány hozzáadása után: `_availableBooks = ["Dune", "Dune", "Dune"]`

**Kölcsönzéskor** egy `"Dune"` bejegyzés átkerül `_availableBooks`-ból `_borrowedBooks`-ba.  
**Visszahozáskor** egy `"Dune"` bejegyzés visszakerül `_borrowedBooks`-ból `_availableBooks`-ba.

---

## Fontos szabályok (olvasd el implementáció előtt!)

- `AddBook("Dune", 3)` — 3 darab `"Dune"` stringet adj hozzá az `_availableBooks` listához. Ugyanezt a metódust meghívva még egyszer csak újabb bejegyzések kerülnek a listába.
- `GetAvailableCopies()` — az `_availableBooks` listában szereplő példányok számát adja vissza. 
- `ReturnBook()` — csak akkor sikeres, ha a cím megtalálható a `_borrowedBooks` listában.
- `GetTotalBorrowed()` — egyszerűen a `_borrowedBooks` lista teljes hossza.

---

## Projektstruktúra

```
LibraryExam/
├── LibraryApp/                  ← Console projekt (ezt implementálod)
│   ├── Library.cs
│   └── Program.cs
└── LibraryApp.Tests/            ← MSTest projekt (ezt bővíted)
    └── LibraryTests.cs
```

---

## Lépések

### 1. lépés — Klónozás és megnyitás
Hozz létre egy repót klónozd le és rakd bele a kibontott zip fájljait (ez a readme jelenjen majd meg a githubon), és nyisd meg a `.sln` fájlt Visual Studio 2022-ben.

### 2. lépés — Futtasd a teszteket (mind el kell, hogy bukjon)
Nyisd meg a **Test Explorer**-t és futtass minden tesztet.  
📸 **Készíts képernyőképet a bukó tesztekről.** Ez lesz a „before" képed.
A kép is kerüljön bele a repóba a saját névvel ellátva
Példa: kovacs_bela_test_before.png

### 3. lépés — Bővítsd a teszteket
Minden tesztmetódus alatt `// TODO` kommentek jelzik a hiányzó eseteket.  
Írj új tesztmetódusokat minden egyes `// TODO`-hoz, mielőtt bármit implementálsz.

```
git add .
git commit -m "Edge case tesztek hozzáadva implementáció előtt"
```

(vagy a visual studio-ban a grafikus felületen)

### 4. lépés — Implementáld az osztályt
Javasolt sorrend:
1. Konstruktor és `GetName`
2. `AddBook` és `GetTotalTitles`
3. `BorrowBook` és `GetAvailableCopies`
4. `ReturnBook` és `IsAvailable`
5. `GetTotalBorrowed` és `RemoveBook`

**Minden metódus (vagy kis csoport) után commitolj:**

```
git commit -m "BorrowBook és GetAvailableCopies implementálva"
```



### 5. lépés — Minden teszt zöld
📸 **Készíts képernyőképet az összes átmenő tesztről.** Ez lesz az „after" képed.

Ez a kép is kerüljön bele a repóba a saját névvel ellátva

Példa: kovacs_bela_test_after.png

---

## Pontozás
 
Az implementációs pontokat csak akkor kapod meg teljes egészében, ha az adott metódushoz saját tesztet is írtál.  
Ha nincs hozzá írott teszt, az implementáció **2 pontot** ér az 5 helyett.
 
| Feladat | Teszt | Implementáció (teszt nélkül) |
|---|:---:|:---:|
| Constructor | 5 | 5 (2) |
| AddBook | 5 | 5 (2) |
| BorrowBook | 5 | 5 (2) |
| ReturnBook | 5 | 5 (2) |
| GetAvailableCopies | 5 | 5 (2) |
| IsAvailable | 5 | 5 (2) |
| GetTotalBorrowed | 5 | 5 (2) |
| RemoveBook | 5 | 5 (2) |
| Képernyőképek (before + after) | 10 | — |
| Git history (min. 5 commit) | 10 | — |
| **Összesen** | **80** | **20** |
 
---
 
## Érdemjegyek
 
| Jegy | Ponthatár |
|:---:|---|
| 5 – Jeles | 89–100 pont |
| 4 – Jó | 75–88 pont |
| 3 – Közepes | 62–74 pont |
| 2 – Elégséges | 45–61 pont |
| 1 – Elégtelen | 0–44 pont |