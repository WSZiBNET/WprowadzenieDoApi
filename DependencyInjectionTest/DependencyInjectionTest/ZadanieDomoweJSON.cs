using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WprowadzenieDoApi;

namespace DependencyInjectionTest
{
    public class ZadanieDomoweJSON : IZadanieDomowe
    {
        public void WczytajDane()
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
    }
}
