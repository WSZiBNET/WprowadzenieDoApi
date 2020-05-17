using System;
using System.Globalization;
using System.Xml;

namespace WprowadzenieDoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Przelicznik walut--");
            Czytaj();
           // zapiszOsobe();
            Console.ReadKey();
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
