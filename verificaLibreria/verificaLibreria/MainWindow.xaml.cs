using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace verificaLibreria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Biblioteca biblioteca;

        private void btnCreaBib_Click(object sender, RoutedEventArgs e)
        {
            if (lblBibNome.Text == "Nome" || lblBibNome.Text == "")
            {
                MessageBox.Show("Il nome della biblioteca non è valido!");
                return;
            }
            if (lblBibIndirizzo.Text == "Indirizzo" || lblBibIndirizzo.Text == "")
            {
                MessageBox.Show("L'indirizzo della biblioteca non è valido!");
                return;
            }
            TimeOnly temp1;
            if (!TimeOnly.TryParse(lblBibApertura.Text, out temp1))
            {
                MessageBox.Show("L'orario di apertura della biblioteca non è valido!");
                return;
            }
            TimeOnly temp2;
            if (!TimeOnly.TryParse(lblBibChiusura.Text, out temp2))
            {
                MessageBox.Show("L'orario di chiusura della biblioteca non è valido!");
                return;
            }

            biblioteca = new Biblioteca(lblBibNome.Text, lblBibIndirizzo.Text, lblBibApertura.Text, temp1, temp2);

            lblBibNome.IsEnabled = false;
            lblBibIndirizzo.IsEnabled = false;
            lblBibApertura.IsEnabled = false;
            lblBibChiusura.IsEnabled = false;
            btnCreaBib.IsEnabled = false;

            lblLibroPagine.IsEnabled = true;
            lblLibroAnno.IsEnabled = true;
            lblLibroAutore.IsEnabled = true;
            lblLibroTitolo.IsEnabled = true;
            lblLibroEditore.IsEnabled = true;
            btnCreaLibro.IsEnabled = true;

            lblCercaAutore.IsEnabled = true;
            btnCercaAutore.IsEnabled = true;
            lblCercaLibro.IsEnabled = true;
            btnCercaLibro.IsEnabled = true;
            btnNumeroLibri.IsEnabled = true;
        }

        private void btnCreaLibro_Click(object sender, RoutedEventArgs e)
        {
            if (lblLibroAutore.Text == "Autore" || lblLibroAutore.Text == "")
            {
                MessageBox.Show("L'autore del libro non è valido!");
                return;
            }
            if (lblLibroTitolo.Text == "Titolo" || lblLibroTitolo.Text == "")
            {
                MessageBox.Show("Il titolo del libro non è valido!");
                return;
            }
            if (lblLibroEditore.Text == "Editore" || lblLibroEditore.Text == "")
            {
                MessageBox.Show("L'editore del libro non è valido!");
                return;
            }
            int anno;
            bool ok = int.TryParse(lblLibroAnno.Text, out anno);
            if (!ok)
            {
                MessageBox.Show("L'anno di pubblicazione del libro non è valido!");
                return;
            }
            int nPagine;
            ok = int.TryParse(lblLibroPagine.Text, out nPagine);
            if (!ok)
            {
                MessageBox.Show("Il numero di pagine del libro non è valido!");
                return;
            }

            biblioteca.AggiungiLibro(lblLibroAutore.Text, lblLibroTitolo.Text, anno, lblLibroEditore.Text, nPagine);
            MessageBox.Show("Libro aggiunto!");
        }

        private void btnCercaLibro_Click(object sender, RoutedEventArgs e)
        {
            Libro libro = biblioteca.CercaLibro(lblCercaLibro.Text);
            if(libro == null)
            {
                MessageBox.Show("Libro non trovato!");
                return;
            }
            MessageBox.Show(libro.toString());
        }

        private void btnCercaAutore_Click(object sender, RoutedEventArgs e)
        {
            List<Libro> libri = biblioteca.CercaLibridiAutore(lblCercaAutore.Text);
            if (libri.Count == 0)
            {
                MessageBox.Show("Autore non trovato!");
                return;
            }
            foreach(Libro l in libri) MessageBox.Show(l.toString());
        }

        private void btnNumeroLibri_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"La biblioteca contiene {biblioteca.NumeroLibri()} libri.");
        }
    }
}