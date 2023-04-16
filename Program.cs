using System;
using ClinicaVeterinária.Serviço;

namespace ClinicaVeterinária
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Servico menu = new Servico();
            menu.PreData();
            Console.Clear();
            menu.MostrarMenu();
        }
    }
}
