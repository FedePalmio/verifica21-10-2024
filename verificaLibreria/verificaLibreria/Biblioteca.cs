using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace verificaLibreria
{
    internal class Biblioteca
    {
        string nome;
        string indirizzo;
        TimeOnly orarioApertura;
        TimeOnly orarioChiusura;
        List<Libro> libri;
    }
}
