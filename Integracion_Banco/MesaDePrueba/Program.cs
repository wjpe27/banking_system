using Integracion_Banco.ConexionCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaDePrueba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Clientes pep = new Clientes();
            bool p = pep.RevisarContraseña("pep@gmail", "9Kg91649E", "Anonimo", 1);
            Console.ReadLine();

        }
    }
}
