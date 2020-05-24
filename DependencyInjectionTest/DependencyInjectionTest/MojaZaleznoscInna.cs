using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionTest
{
    public class MojaZaleznoscInna : IMojaZaleznosc
    {
        public MojaZaleznoscInna()
        {

        }
        public void NapiszWiadomosc(string message)
        {
            Console.WriteLine($"Nie wiem, o co chodzi, ale przekazano taką wiadomość: {message}");
        }

    }
}
