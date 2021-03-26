using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Crud
{
    public class Funciones
    {

        public void Descomprime(string pathArchivo, string Archivo)
        {
            ZipFile.ExtractToDirectory(Archivo, pathArchivo);
        }

    }

}
