using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data.Entity;

namespace ConsolaPrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            CargaDeArchivos.IniciarDB();
            CargaDeArchivos.CargarGrupos();
            CargaDeArchivos.CargarUsuarios();
            CargaDeArchivos.CargarTramites();
            CargaDeArchivos.CargarEtapas();
            CargaDeArchivos.CargarAsignacionGrupos();
            CargaDeArchivos.CargarUsuariosNuevos();
            //Console.WriteLine("Presione una tecla");
            //Console.ReadKey(); 

        }
    }

}
