using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
using WprowadzenieDoApi;

namespace WprowadzenieDoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            #region wybor aplikacji
            Console.WriteLine("Wybierz Program:");
            Console.WriteLine("1 - przelicznik walut");
            Console.WriteLine("2 - zapisz osobę do xml");
            Console.WriteLine("3 - zapisz pracownika firmy do xml");
            Console.WriteLine("4 - Deserializacja do słownika Json");
            Console.WriteLine("5 - Deserializacja do klasy Json");
            Console.WriteLine("6 - Serializacja do Json");
            Console.WriteLine("7 - Linq do Json");
            int prog= Convert.ToInt32(Console.ReadLine() );
            if (prog == 1)
            {
                Czytaj();
            }
            else if (prog == 2)
            {
                zapiszOsobe();
            }
            else if (prog == 3)
            {
                zapiszPracownika();
            }
            else if (prog == 4)
            {
                DeserializacjaSlownik();
            }
            else if (prog == 5)
            {
                DeserializacjaKlasa();
            }
            else if (prog == 6)
            {
                SerializacjaObiektu();
            }
            else if (prog == 7)
            {
                Linq2Json();
            }
            else
            {
                Console.WriteLine("Zły wybór");
            }
            Console.ReadKey();
            #endregion
        }

        static void zapiszPracownika()
        {
            #region pobieranie danych 
            Console.WriteLine("__Podaj dane pracownika__");
            Osoba pracownik = new Osoba(); 

            Console.WriteLine("Podaj Imie:");
            pracownik.Imie = Console.ReadLine();

            Console.WriteLine("Podaj Nazwisko");
            pracownik.Nazwisko = Console.ReadLine();

            Console.WriteLine("Podaj Wiek");
            pracownik.Wiek = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj Miasto");
            pracownik.Miasto = Console.ReadLine();

            Console.WriteLine("Podaj Ulice");
            pracownik.Ulica = Console.ReadLine();

            Console.WriteLine("Podaj numer domu");
            pracownik.NumerDomu = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj Kod pocztowy");
            pracownik.KodPocztowy = Console.ReadLine();

            Console.WriteLine("Podaj plec");
            pracownik.Plec = Console.ReadLine();

            Console.WriteLine("Czy jest w zwiazku?");
            pracownik.WZwiazku = Console.ReadLine();

            #endregion

            #region zapisz do xml
            XmlWriterSettings wpiszDoXMLPracownikSettings = new XmlWriterSettings();
            wpiszDoXMLPracownikSettings.OmitXmlDeclaration = true;
            wpiszDoXMLPracownikSettings.Indent = true;
            wpiszDoXMLPracownikSettings.NewLineOnAttributes = true;

            XmlWriter wpiszDoXMLPracownik = XmlWriter.Create($"pracownik{pracownik.Imie}{pracownik.Nazwisko}.xml", wpiszDoXMLPracownikSettings);
            wpiszDoXMLPracownik.WriteStartDocument();
            wpiszDoXMLPracownik.WriteStartElement("pracownik");
            wpiszDoXMLPracownik.WriteAttributeString("Imie", $"{pracownik.Imie}");
            wpiszDoXMLPracownik.WriteAttributeString("Nazwisko", $"{pracownik.Nazwisko}");

            wpiszDoXMLPracownik.WriteStartElement("Imie");
            wpiszDoXMLPracownik.WriteString($"{pracownik.Imie}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("Nazwisko");
            wpiszDoXMLPracownik.WriteString($"{pracownik.Nazwisko}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("Wiek");
            wpiszDoXMLPracownik.WriteString($"{pracownik.Wiek}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("Miasto");
            wpiszDoXMLPracownik.WriteString($"{pracownik.Miasto}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("Ulica");
            wpiszDoXMLPracownik.WriteString($"{pracownik.Ulica}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("NumerDomu");
            wpiszDoXMLPracownik.WriteString($"{pracownik.NumerDomu}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("KodPocztowy");
            wpiszDoXMLPracownik.WriteString($"{pracownik.KodPocztowy}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("Plec");
            wpiszDoXMLPracownik.WriteString($"{pracownik.Plec}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteStartElement("WZwiazku");
            wpiszDoXMLPracownik.WriteString($"{pracownik.WZwiazku}");
            wpiszDoXMLPracownik.WriteEndElement();

            wpiszDoXMLPracownik.WriteEndDocument();

            wpiszDoXMLPracownik.Close();

            Console.WriteLine("Zapisałem pracownika do xml-a ");
            #endregion

            #region Serialize
            StreamWriter serialWriter;
            // dont need to use XmlWriterSettings
            serialWriter = new StreamWriter($"serializeXML{pracownik.Imie}{pracownik.Nazwisko}.xml");
            XmlSerializer xmlWriter = new XmlSerializer(pracownik.GetType());
            xmlWriter.Serialize(serialWriter, pracownik);
            serialWriter.Close();
            Console.WriteLine("Zserializowałem pracownika do xml-a ");
            #endregion

        }



        static void zapiszOsobe()
        {
            #region Zapisz Osobe
            Console.WriteLine("__Zapisuję osobę do xml-a__");

            XmlWriter wpiszDoXML = XmlWriter.Create("osoby.xml");
            wpiszDoXML.WriteStartDocument();
                wpiszDoXML.WriteStartElement("Ludzie");

                    wpiszDoXML.WriteStartElement("Czlowiek1");
                    wpiszDoXML.WriteAttributeString("wiek", "37");
                    wpiszDoXML.WriteString("Janusz Wielki");
                    wpiszDoXML.WriteEndElement();

                    wpiszDoXML.WriteStartElement("Czlowiek2");
                    wpiszDoXML.WriteAttributeString("wiek", "74");
                    wpiszDoXML.WriteString("Mirosław Mały");
                    wpiszDoXML.WriteEndElement();

            wpiszDoXML.WriteEndElement();
            wpiszDoXML.WriteEndDocument();

            wpiszDoXML.Close();

            Console.WriteLine("Zapisałem do osobę do xml-a ");
            #endregion
        }

        static void Czytaj()
        {
            #region wczytaj xml
            Console.WriteLine("--Przelicznik walut--");
            decimal kurs = 0m;
            Console.WriteLine("___Czytam___");
            XmlReader xmlReader = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            Console.WriteLine("__Wczytano aktualne kursy__");
            #endregion

            #region klakulator walut
            Console.WriteLine("Podaj walute (trzyliterowy kod)");
            string waluta = Console.ReadLine();
            Console.WriteLine("Podaj kwotę");
            decimal kwota = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

            //TODO Stwórz aplikację do zapisywania w xml, danych pracowników firmy.
            //TODO Użyj modelu, z którego korzystałeś na poprzednich zajęciach. 
            
           while (xmlReader.Read())
            {
                if(xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name=="Cube" && xmlReader.HasAttributes)
                {
                    var checkCurrency = xmlReader.GetAttribute("currency");
                    if (!string.IsNullOrEmpty(checkCurrency) && checkCurrency == waluta)
                        {
                        kurs = Convert.ToDecimal(xmlReader.GetAttribute("rate"), CultureInfo.InvariantCulture);
                        Console.WriteLine($"Twoja kwota to: {decimal.Round(kwota/kurs, 2)} EUR");
                        }
                }

            }
            /* czy potrzeba dawać  xmlReader.Close() ?  */
            xmlReader.Close();

            Console.WriteLine("__Dziekuję za skorzystanie z Oski Kalkulator Walut __");
            #endregion
        }

        //static void testJson()
        //{
        //    var example = @"{""imię"":""Janusz Wielki"",""wiek"":42}";

        //}

        //Deserializacja do slownieka 
        static void DeserializacjaSlownik()
        {
            Console.WriteLine("--Deserializacja do słownika z json--");

            var example = @"{""imię"":""Janusz Wielki"",""wiek"":42}";
            var slownikCzlowek = JsonConvert.DeserializeObject<Dictionary<string,string>>(example);
            Console.WriteLine($"Imie to {slownikCzlowek["imię"]}, a wiek to {slownikCzlowek["wiek"]}"); 
        }

        //Deserializacja do klasy 
        static void DeserializacjaKlasa()
        {
            Console.WriteLine("--Deserializacja do klasy z json--");

            var example = @"{""Imie"":""Janusz Wielki"",""Wiek"":42}";
            var jakisCzlowek = JsonConvert.DeserializeObject<OsobaJson>(example);
            Console.WriteLine($"Imie to {jakisCzlowek.Imie}, a wiek to {jakisCzlowek.Wiek}");
        }

        static void SerializacjaObiektu()
        {
            Console.WriteLine("-Serializacja  do json--");
            var czlowiek = new Czlowiek
            {
                Imie = "Daniel",
                Nazwisko = "Kowalski",
                AdresDomowy = new Adres
                {
                    Ulica = "Tyniecka",
                    NumerDomu = 15,
                    KodPocztowy = "43-100",
                    Miasto = "Tychy"
                }
            };

            var tekst = JsonConvert.SerializeObject(czlowiek);
            //or
            var tekst2 = JsonConvert.SerializeObject(czlowiek, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine($"{tekst}");
            Console.WriteLine("-------");
            Console.WriteLine($"{tekst2}");
        }


    static void Linq2Json()
    {
        Czlowiek czlowiek1 = new Czlowiek
        {
            Imie = "Daniel",
            Nazwisko = "Krasnokucki",
            Wiek = 30,
            AdresDomowy = new Adres
            {
                KodPocztowy = "40-789",
                Miasto = "Katowice",
                Ulica = "Marszałkowska",
                NumerDomu = 109876545
            }
        };
        Czlowiek czlowiek2 = new Czlowiek
        {
            Imie = "Stefan",
            Nazwisko = "Nowak",
            Wiek = 130,
            AdresDomowy = new Adres
            {
                KodPocztowy = "50-789",
                Miasto = "Lublin",
                Ulica = "Piotrkowska",
                NumerDomu = 23
            }
        };

        Czlowiek czlowiek3 = new Czlowiek
        {
            Imie = "Iwona",
            Nazwisko = "Kowalska",
            Wiek = 20,
            AdresDomowy = new Adres
            {
                KodPocztowy = "30-543",
                Miasto = "Kraków",
                Ulica = "al. Pokoju",
                NumerDomu = 100
            }
        };

        List<Czlowiek> listaLudzi = new List<Czlowiek>();
        listaLudzi.Add(czlowiek1);
        listaLudzi.Add(czlowiek2);
        listaLudzi.Add(czlowiek3);

        string jsonLista = JsonConvert.SerializeObject(listaLudzi, Newtonsoft.Json.Formatting.Indented);
        Console.WriteLine(jsonLista);

        var lista = JArray.Parse(jsonLista);

            // Pokaż imię, nazwisko, Adres (ulica) ludzi, któzy mają poniżej 30 lat
            var ponizej30 = from czlowiek in lista
                            where Convert.ToInt32(czlowiek["Wiek"]) < 30
                            select new { imie = czlowiek["Imie"], nazwisko = czlowiek["Nazwisko"], ulica = czlowiek["AdresDomowy"]["Ulica"] };

            foreach (var osoba in ponizej30)
            {
                Console.WriteLine(osoba);
            }

        }

}
}
