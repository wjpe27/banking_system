using CoreBanco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoreBanco.Transferencias;
using System.Web.Services;
using static CoreBanco.Clientes;
using MesaPruebas.ServiceReference1;

namespace MesaPruebas
{
    internal class Program
    {

        static void Main(string[] args)
        {


            //Clientes pep = new Clientes();
            //Console.WriteLine(pep.CrearClientes("Fran", "Casa", "9", "pep@gmail", "paulino", "123").ToString());
            //Console.ReadKey();

            //Clientes pep = new Clientes();
            //Console.WriteLine(pep.EliminarCliente("123").ToString());
            //Console.ReadKey();

            //Clientes pep = new Clientes();

            //DataSet tb = pep.MostrarCliente(null);


            //Console.WriteLine();
            //Console.ReadKey();

            //Clientes pep = new Clientes();
            //Console.WriteLine(pep.CrearCuentaCliente(2,2,0).ToString());
            //Console.ReadKey();

            //Transferencias pep = new Transferencias();
            //Console.WriteLine(pep.RetirarDinero("0059669905",500).ToString());
            //Console.ReadKey();


            //        // Crear una instancia de la clase de servicio web (reemplazar 'MyWebService' con el nombre real de tu clase)
            //        Transferencias pep = new Transferencias();

            //        // Llamar al método MostrarTransacciones para obtener la lista de transacciones
            //        List<Transaccion> transacciones = pep.MostrarTransacciones();

            //        // Imprimir la transacción con un número de transacción específico (por ejemplo, '1234567890')
            //        string numeroTransaccionBuscado = "1732524074";
            //        Transaccion transaccionEncontrada = transacciones.Find(t => t.NumeroTransaccion == numeroTransaccionBuscado);

            //        if (transaccionEncontrada != null)
            //        {
            //            ImprimirTransaccion(transaccionEncontrada);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Transacción no encontrada");
            //        }




            //}
            //public static void ImprimirTransaccion(Transaccion transaccion)
            //{
            //    Console.WriteLine("ID: " + transaccion.Id);
            //    Console.WriteLine("Fecha y hora: " + transaccion.FechaHora);
            //    Console.WriteLine("Cuenta ID: " + transaccion.CuentaId);
            //    Console.WriteLine("Cantidad: " + transaccion.Cantidad);
            //    Console.WriteLine("Descripción: " + transaccion.Descripcion);
            //    Console.WriteLine("Número de transacción: " + transaccion.NumeroTransaccion);
            //    Console.ReadKey();

            //Clientes pep = new Clientes();
            //List<Cuenta> cuentas = pep.MostrarCuentasCliente("123");

            //if (cuentas.Count > 0)
            //{
            //    Console.WriteLine("Cuentas del cliente:");
            //    foreach (Cuenta cuenta in cuentas)
            //    {
            //        Console.WriteLine("---------------------");
            //        Console.WriteLine("ID: " + cuenta.Id);
            //        Console.WriteLine("Número de cuenta: " + cuenta.NumeroCuenta);
            //        Console.WriteLine("Saldo: " + cuenta.Saldo);
            //        Console.WriteLine("Cliente ID: " + cuenta.ClienteId);
            //        Console.WriteLine("---------------------");
            //        Console.ReadKey();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("El cliente no tiene cuentas asociadas.");
            //    Console.ReadKey();
            ////}
            ///



            //void abrir()
            //{
            //    Transferencias client = new Transferencias();

            //    int empleado_id = 1;
            //    DateTime fecha = DateTime.Now.Date;
            //    TimeSpan hora_inicio = new TimeSpan(9, 0, 0);
            //    int denominacion1 = 10;
            //    int denominacion5 = 5;
            //    int denominacion10 = 2;
            //    int denominacion25 = 0;
            //    int denominacion50 = 3;
            //    int denominacion100 = 1;
            //    int denominacion200 = 0;
            //    int denominacion500 = 0;
            //    int denominacion1000 = 0;
            //    int denominacion2000 = 0;

            //    int turno_id = client.InsertarTurnoConBilletes(empleado_id, fecha, hora_inicio, denominacion1, denominacion5, denominacion10, denominacion25, denominacion50, denominacion100, denominacion200, denominacion500, denominacion1000, denominacion2000);

            //    Console.WriteLine("Turno insertado con ID: " + turno_id);
            //    Console.ReadLine();
            //}
            //int turno_id_cerrar = 5;
            //void cerrar(){
            //    Transferencias client = new Transferencias();

            //     // Reemplaza esto con el ID del turno que deseas cerrar
            //    TimeSpan hora_fin = new TimeSpan(18, 0, 0);
            //    int denominacion1 = 12;
            //    int denominacion5 = 6;
            //    int denominacion10 = 3;
            //    int denominacion25 = 1;
            //    int denominacion50 = 4;
            //    int denominacion100 = 2;
            //    int denominacion200 = 0;
            //    int denominacion500 = 0;
            //    int denominacion1000 = 0;
            //    int denominacion2000 = 0;

            //    bool success = client.TerminarTurno(turno_id_cerrar, hora_fin, denominacion1, denominacion5, denominacion10, denominacion25, denominacion50, denominacion100, denominacion200, denominacion500, denominacion1000, denominacion2000);

            //    if (success)
            //    {
            //        Console.WriteLine("Turno con ID " + turno_id_cerrar + " cerrado exitosamente.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("No se pudo cerrar el turno con ID " + turno_id_cerrar + ".");
            //    }

            //    Console.ReadLine();
            //}
            //string n;
            //n=Console.ReadLine();
            //while (true)
            //{

            //    if (n == "si")
            //    {
            //        abrir();
            //    }
            //    else if (n == "no")
            //    {
            //        string l = Console.ReadLine();
            //        turno_id_cerrar = int.Parse(l);
            //        cerrar();
            //    }


            //}

            ////Transferencias client = new Transferencias();

            ////int cliente_id = 2;
            ////DateTime fecha_inicio = DateTime.Now;
            ////DateTime fecha_fin = fecha_inicio.AddYears(2);
            ////DateTime dia_corte_pago = fecha_inicio.AddDays(30);
            ////decimal sueldo_restante = 10000m;
            ////decimal tasa_interes = 5.0m;

            ////bool result = client.CrearPrestamo(cliente_id, fecha_inicio, fecha_fin, dia_corte_pago, sueldo_restante, tasa_interes);

            ////if (result)
            ////{
            ////    Console.WriteLine("Préstamo creado exitosamente.");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Error al crear el préstamo.");
            ////}

            ////Console.ReadKey();

            //Transferencias client = new Transferencias();

            //int prestamo_id = 4; // Asegúrate de ingresar un ID de préstamo válido
            //decimal monto_pago = 500;

            //bool resultado = client.PagoPrestamo(prestamo_id, monto_pago);

            //if (resultado)
            //{
            //    Console.WriteLine("Pago realizado exitosamente.");
            //}
            //else
            //{
            //    Console.WriteLine("Error al realizar el pago.");
            //}

            //Console.ReadKey();

            General lol = new General();
            DataTable pep = lol.SelectTable("Transacciones", "id", "123SARSAno12nio");
            Console.ReadKey();



        }
    }
}