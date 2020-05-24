using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionTest.Pages
{
    public class IndexModel : PageModel
    {
        // private readonly ILogger<IndexModel> _logger;
        private IMojaZaleznosc _zaleznosc; // = new MojaZaleznosc();
        private IZadanieDomowe _zadanie; 
        public IndexModel(IMojaZaleznosc zaleznosc, IZadanieDomowe zadanie) // (ILogger<IndexModel> logger)
        {
            //_logger = logger;
            _zaleznosc = zaleznosc;
            _zadanie = zadanie; 
        }



        public void OnGet()
        {
            _zaleznosc.NapiszWiadomosc("Ta wiadomośc zostałą wysłana z metody OnGet");
            _zadanie.WczytajDane();
        }

        //TODO: Napisz 3 klasy implementujące interfejs zawierający metodę WczytajDane:
        // 1. Klasa czytająca z XML-a
        // 2. Klasa czytająca z JSON-a
        // 3. Wstrzyknij klasy do interfejsu i zobacz, jak zmienia się wynik.

    }
}
