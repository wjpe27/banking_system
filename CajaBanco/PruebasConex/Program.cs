using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PruebasConex
{
    public class Program
    {
       
        static void Main(string[] args)
        {

            CoreClientes.ClientesSoapClient pep = new CoreClientes.ClientesSoapClient();

            bool p = pep.RevisarContraseña("pep@gmail", "9Kg91649E", "Anonimo", 1);
            Console.ReadLine();
        }
    }
}
