using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace verificaLibreria
{
    internal class Biblioteca
    {
        public string nome { get; set; }
        public string indirizzo { get; set; }
        public TimeOnly orarioApertura { get; set; }
        public TimeOnly orarioChiusura { get; set; }
        public List<Libro> libri { get; }

        public Biblioteca(string nome, string indirizzo, TimeOnly orarioApertura, TimeOnly orarioChiusura)
        {
            this.nome = nome;
            this.indirizzo = indirizzo;
            this.orarioApertura = orarioApertura;
            this.orarioChiusura = orarioChiusura;
            libri = new List<Libro>();
        }

        public void AggiungiLibro(string autore, string titolo, int annoPubblicazione, string editore, int numeroPagine)
        {
            libri.Add(new Libro(autore, titolo, annoPubblicazione, editore, numeroPagine));
        }

        public Libro CercaLibro(string titolo)
        {
            foreach (Libro libro in libri)
            {
                if (libro.titolo == titolo)
                {
                    return libro;
                }
            }

            return null;
        }

        public List<Libro> CercaLibriDiAutore(string autore)
        {
            List<Libro> result = new();
            foreach (Libro libro in libri)
            {
                if (libro.autore == autore)
                {
                    result.Add(libro);
                }
            }
            return result;
        }

        public int numeroLibri() { return libri.Count; }
    }
}
