using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using XmlZadanie;

namespace WprowadzenieDoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz Program:");
            Console.WriteLine("1 - przelicznik walut");
            Console.WriteLine("2 - zapisz osobę do xml");
            Console.WriteLine("3 - zapisz pracownika firmy do xml");
            int prog= Convert.ToInt32(Console.ReadLine() );
            if(prog==1)
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
            Console.ReadKey();
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
        }

        static void Czytaj()
        {
            Console.WriteLine("--Przelicznik walut--");
            decimal kurs = 0m;
            Console.WriteLine("___Czytam___");
            XmlReader xmlReader = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            Console.WriteLine("__Wczytano aktualne kursy__");

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
        }


    }
}
