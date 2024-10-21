using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace verificaLibreria
{
    internal class Libro
    {
        public string autore {  get; set; }
        public string titolo { get; set; }
        public int annoPubblicazione { get; set; }
        public string editore { get; set; }
        public int numeroPagine { get; set; }

        public Libro(string autore, string titolo, int annoPubblicazione, string editore, int numeroPagine)
        {
            this.autore = autore;
            this.titolo = titolo;
            this.annoPubblicazione = annoPubblicazione;
            this.editore = editore;
            this.numeroPagine = numeroPagine;
        }

        public override string ToString()
        {
            return $"\"{titolo}\", {autore}, pubblicato nel {annoPubblicazione} da {editore}; {numeroPagine} pagine; tempo di lettura: {readingTime().TotalHours} ora/e";
        }

        public TimeSpan readingTime()
        {
            // implementato in modo che ritorni un ora per ogni 100 pagine
            return TimeSpan.FromHours(Math.Ceiling(numeroPagine / 100.0));
        }
    }
}
