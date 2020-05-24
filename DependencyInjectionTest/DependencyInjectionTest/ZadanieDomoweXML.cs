using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace DependencyInjectionTest
{
    public class ZadanieDomoweXML : IZadanieDomowe
    {
        public void WczytajDane()
        {
            Console.WriteLine("--Przelicznik walut--");
            Console.WriteLine("___Czytam___");
            XmlReader xmlReader = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            Console.WriteLine("__Wczytano aktualne kursy__");
            xmlReader.Close();
        }

    }
}
