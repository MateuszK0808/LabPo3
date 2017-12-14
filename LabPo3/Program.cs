using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPo3
{
    class Katalog : IZarzadzaniePozycjami
    {
        private string dzialTematyczny;
        private List<Pozycja> pozycje = new List<Pozycja>();

        public Katalog()
        {
            DzialTematyczny = "";
        }

        public Katalog(string dzialTematyczny_)
        {
            DzialTematyczny = dzialTematyczny_;
        }

        public string DzialTematyczny
        {
            get { return dzialTematyczny; }
            set { dzialTematyczny = value; }
        }

        public void DodajPozycje(Pozycja pozycja)
        {
            pozycje.Add(pozycja);
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Pozycje w katalogu");
            Console.WriteLine("Dział tematyczny " + DzialTematyczny);
            for (int i = 0; i < pozycje.Count; i++)
            {
                pozycje[i].WypiszInfo();
            }
        }

        public Pozycja ZnajdzPozycjePoTytule(string tytul)
        {
            for (int i = 0; i < pozycje.Count; i++)
            {
                if (pozycje[i].Tytul == tytul)
                {
                    return pozycje[i];
                }
            }
            return null;
        }

        public Pozycja ZnajdzPozycjePoId(int id)
        {
            for (int i = 0; i < pozycje.Count; i++)
            {
                if (pozycje[i].Id == id)
                {
                    return pozycje[i];
                }
            }
            return null;
        }

        public void WypiszWszystkiePozycje()
        {
            Console.WriteLine("Pozycje w katalogu:");
            Console.WriteLine(" ");
            pozycje.ForEach((p) => p.WypiszInfo());
        }
    }  //..........................................................................................................

    public abstract class Pozycja
    {
        protected string tytul;
        protected int id;
        protected string wydawnictwo;
        protected int rokWydania;

        public Pozycja()
        {
            tytul = "";
            id = 0;
            wydawnictwo = "";
            rokWydania = 0;
        }
        public Pozycja(string tytul_, int id_, string wydawnictwo_, int rokWydania_)
        {
            tytul = tytul_;
            id = id_;
            wydawnictwo = wydawnictwo_;
            rokWydania = rokWydania_;
        }

        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public abstract void WypiszInfo();
    }  //..........................................................................................................

    class Ksiazka : Pozycja
    {
        private int liczbaStron;
        private List<Autor> autorzy = new List<Autor>();

        public Ksiazka()
        {
            liczbaStron = 0;
            tytul = "";
            id = 0;
            wydawnictwo = "";
        }

        public Ksiazka(string tytul_, int id_, string wydawnictwo_, int rokWydania_, int liczbaStron_)
        {
            tytul = tytul_;
            id = id_;
            wydawnictwo = wydawnictwo_;
            rokWydania = rokWydania_;
            liczbaStron = liczbaStron_;
        }

        public void DodajAutora(Autor autor)
        {
            autorzy.Add(autor);
        }

        public override void WypiszInfo()
        {
            Console.WriteLine("Książka:");
            Console.WriteLine("Tytuł: " + tytul);
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Wydawnictwo: " + wydawnictwo);
            Console.WriteLine("Rok wydania: " + rokWydania);
            Console.WriteLine("Liczba stron: " + liczbaStron);
            Console.WriteLine("Autorzy: ");
            for (int i = 0; i < autorzy.Count; i++)
            {
                autorzy[i].WypiszInfo();
            }
        }
    }   //..........................................................................................................

    class Autor : Osoba
    {
        private string narodowosc;

        public Autor()
        {
            imie = "";
            nazwisko = "";
            narodowosc = "";
        }

        public Autor(string imie_, string nazwisko_, string narodowosc_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            narodowosc = narodowosc_;

        }

        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine("   Narodowość: " + narodowosc);
        }
    }   //..........................................................................................................

    class Czasopismo : Pozycja
    {
        private int numer;

        public Czasopismo()
        {
            tytul = "";
            id = 0;
            wydawnictwo = "";
            rokWydania = 0;
            numer = 0;
        }
        public Czasopismo(string tytul_, int id_, string wydawnictwo_, int rokWydania_, int numer_)
        {
            tytul = tytul_;
            id = id_;
            wydawnictwo = wydawnictwo_;
            rokWydania = rokWydania_;
            numer = numer_;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("Czasopismo: ");
            Console.WriteLine("Tytuł: " + tytul);
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Wydawnictwo: " + wydawnictwo);
            Console.WriteLine("Rok wydania: " + rokWydania);
            Console.WriteLine("Number: " + numer);
        }
    }   //..........................................................................................................

    class Osoba
    {
        protected string imie;
        protected string nazwisko;

        public Osoba()
        {
            imie = "";
            nazwisko = "";
        }

        public Osoba(string imie_, string nazwisko_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
        }

        public virtual void WypiszInfo()
        {
            Console.WriteLine("   Imie: " + imie);
            Console.WriteLine("   Nazwisko: " + nazwisko);
        }
    }   //..........................................................................................................

    class Bibliotekarz : Osoba
    {
        private string dataZatrudnienia;
        private double wynagrodzenie;

        public Bibliotekarz()
        {
            imie = "";
            nazwisko = "";
            dataZatrudnienia = "";
            wynagrodzenie = 0;
        }

        public Bibliotekarz(string imie_, string nazwisko_, string dataZatrudnienia_, double wynagrodzenie_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            dataZatrudnienia = dataZatrudnienia_;
            wynagrodzenie = wynagrodzenie_;
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine("   Data zatrudnienia: " + dataZatrudnienia);
            Console.WriteLine("   Wynagrodzenie: " + wynagrodzenie);
        }
    }    //..........................................................................................................

    interface IZarzadzaniePozycjami
    {
        Pozycja ZnajdzPozycjePoTytule(string tytul);
        Pozycja ZnajdzPozycjePoId(int id);
        void WypiszWszystkiePozycje();
    }   //................................................................................

    interface IZarzadzanieBibliotekarzami
    {
        List<Bibliotekarz> ZnajdzBibliotekarzyPoImieniu(string imie);
        List<Bibliotekarz> ZnajdzBibliotekarzyPoNazwisku(string nazwisko);
        Bibliotekarz ZnajdzBibliotekarzaPoInieniuINazwisku(string imie, string nazwisko);
    }    //......................................................................................

    class Biblioteka : IZarzadzaniePozycjami, IZarzadzanieBibliotekarzami
    {
        private string adres;
        private List<Bibliotekarz> bibliotekarze = new List<Bibliotekarz>();
        private List<Katalog> katalogi = new List<Katalog>();

        public Biblioteka()
        {
            adres = "";
        }

        public Biblioteka(string adres_)
        {
            adres = adres_;
        }

        public void DodajBibliotekarza(Bibliotekarz bibliotekarz)
        {
            bibliotekarze.Add(bibliotekarz);
        }

        public void WypiszBibliotekarzy()
        {
            for (int i = 0; i < bibliotekarze.Count; i++)
            {
                bibliotekarze[i].WypiszInfo();
            }
        }

        public void DodajKatalog(Katalog katalog)
        {
            katalogi.Add(katalog);
        }

        public void DodajPozycje(Pozycja pozycja, string dzialTematyczny)
        {
            for (int i = 0; i < katalogi.Count; i++)
            {
                if (katalogi[i].DzialTematyczny == dzialTematyczny)
                {
                    katalogi[i].DodajPozycje(pozycja);
                    break;
                }
            }
        }

        public Pozycja ZnajdzPozycjePoTytule(string tytul)
        {
            for (int i = 0; i < katalogi.Count; i++)
            {
                Pozycja pozycja = katalogi[i].ZnajdzPozycjePoTytule(tytul);
                if (pozycja != null)
                {
                    return pozycja;
                }
            }
            return null;
        }

        public Pozycja ZnajdzPozycjePoId(int id)
        {
            for (int i = 0; i < katalogi.Count; i++)
            {
                Pozycja pozycja = katalogi[i].ZnajdzPozycjePoId(id);
                if (pozycja != null)
                {
                    return pozycja;
                }
            }
            return null;
        }

        public void WypiszWszystkiePozycje()
        {
            for (int i = 0; i < katalogi.Count; i++)
            {
                katalogi[i].WypiszInfo();
            }
        }

        public List<Bibliotekarz> ZnajdzBibliotekarzyPoImieniu(string imie)
        {
            List<Bibliotekarz> wynikWyszukiwania = new List<Bibliotekarz>();
  
            for (int i = 0; i < bibliotekarze.Count; i++)
            {
                if (bibliotekarze[i].Imie == imie)
                {
                    wynikWyszukiwania.Add(bibliotekarze[i]);                  
                }
            }
            return wynikWyszukiwania;
        }

        public List<Bibliotekarz> ZnajdzBibliotekarzyPoNazwisku(string nazwisko)
        {
            List<Bibliotekarz> wynikWyszukiwania = new List<Bibliotekarz>();

            for (int i = 0; i < bibliotekarze.Count; i++)
            {
                if (bibliotekarze[i].Nazwisko == nazwisko)
                {
                    wynikWyszukiwania.Add(bibliotekarze[i]);
                }
            }
            return wynikWyszukiwania;
        }

        public Bibliotekarz ZnajdzBibliotekarzaPoInieniuINazwisku(string imie, string nazwisko)
        {
            for (int i = 0; i < bibliotekarze.Count; i++)
            {
                if (bibliotekarze[i].Imie == imie && bibliotekarze[i].Nazwisko == nazwisko)
                {
                    return bibliotekarze[i];
                }
            }
            return null;
        }

    }   //..........................................................................................................

    class Program   // >>>> Klasa TESTUJACA <<<< ....................................................................
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sprawdzenie.............................................................. ");

            Katalog katalog = new Katalog("Książki");
            Czasopismo czasopismo = new Czasopismo("gazeta", 1, "wszip", 1999, 2);
            Ksiazka ksiazka = new Ksiazka("Jakas książka", 2, "ORelly", 1889, 432);

            Console.WriteLine("-------------------------");
            czasopismo.WypiszInfo();
            Console.WriteLine("-------------------------");
            ksiazka.WypiszInfo();

            Autor autor = new Autor("Jan", "Kowalski", "Polska");
            ksiazka.DodajAutora(autor);
            Console.WriteLine("-------------------------");
            ksiazka.WypiszInfo();

            katalog.DodajPozycje(ksiazka);
            katalog.DodajPozycje(czasopismo);

            katalog.WypiszInfo();

            Bibliotekarz bibliotekarz = new Bibliotekarz("Roland", "ZeSpychowa", "08-09-1992", 3000);
            Bibliotekarz bibliotekarz2 = new Bibliotekarz("Jakies", "Imie", "08-12-1999", 2000);

            Biblioteka biblioteka = new Biblioteka("ul. Rolna 123");

            Czasopismo czasopismo2 = new Czasopismo("jakies", 3, "czasopismo", 2000, 4);

            biblioteka.DodajBibliotekarza(bibliotekarz);
            biblioteka.WypiszBibliotekarzy();
            biblioteka.DodajKatalog(katalog);
            biblioteka.DodajPozycje(czasopismo2, "Książki");

            Console.WriteLine("-------------------------");
            biblioteka.WypiszWszystkiePozycje();

            Pozycja wyszukanaPozycja = biblioteka.ZnajdzPozycjePoId(1);

            Pozycja wyszukanaPozycja2 = biblioteka.ZnajdzPozycjePoTytule("Jakas książka");

            List<Bibliotekarz> wyszukanyBibliotekarz = biblioteka.ZnajdzBibliotekarzyPoImieniu("Jakies");
            List<Bibliotekarz> wyszukanyBibliotekarz2 = biblioteka.ZnajdzBibliotekarzyPoNazwisku("ZeSpychowa");
            Bibliotekarz wyszukanyBibliotekarz3 = biblioteka.ZnajdzBibliotekarzaPoInieniuINazwisku("Roland", "ZeSpychowa");

            Console.WriteLine("-------------------------");
            wyszukanaPozycja.WypiszInfo();
            Console.WriteLine("-------------------------");
            wyszukanaPozycja2.WypiszInfo();

            Console.WriteLine("-------------------------");
            for (int i = 0; i < wyszukanyBibliotekarz.Count; i++)
            {
                wyszukanyBibliotekarz[i].WypiszInfo();
            }
            Console.WriteLine("-------------------------");
            for (int i = 0; i < wyszukanyBibliotekarz2.Count; i++)
            {
                wyszukanyBibliotekarz2[i].WypiszInfo();
            }
            Console.WriteLine("-------------------------");
            wyszukanyBibliotekarz3.WypiszInfo();

            Console.ReadKey();
        }
    }
}
