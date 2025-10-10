using System;
using System.Globalization;
using System.Windows;

namespace Digitron
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool TryParseBroj(string input, out double value)
        {
     
            return double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(input, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out value) ||
                   double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private bool ProcitajUlaze(out double a, out double b)
        {
            txtPoruka.Text = string.Empty;
            if (!TryParseBroj(txtA.Text, out a))
            {
                txtPoruka.Text = "Unesite ispravan broj za A (dozvoljeni su i zarez i tačka).";
                txtA.Focus();
                b = 0;
                return false;
            }
            if (!TryParseBroj(txtB.Text, out b))
            {
                txtPoruka.Text = "Unesite ispravan broj za B (dozvoljeni su i zarez i tačka).";
                txtB.Focus();
                return false;
            }
            return true;
        }

        private void Prikazi(double rezultat)
        {
            txtRezultat.Text = rezultat.ToString(CultureInfo.CurrentCulture);
        }

        private void btnSabiranje_Click(object sender, RoutedEventArgs e)
        {
            if (ProcitajUlaze(out var a, out var b)) Prikazi(a + b);
        }

        private void btnOduzimanje_Click(object sender, RoutedEventArgs e)
        {
            if (ProcitajUlaze(out var a, out var b)) Prikazi(a - b);
        }

        private void btnMnozenje_Click(object sender, RoutedEventArgs e)
        {
            if (ProcitajUlaze(out var a, out var b)) Prikazi(a * b);
        }

        private void btnDeljenje_Click(object sender, RoutedEventArgs e)
        {
            if (ProcitajUlaze(out var a, out var b))
            {
                if (Math.Abs(b) < 1e-12)
                {
                    txtPoruka.Text = "Deljenje nulom nije dozvoljeno.";
                    return;
                }
                Prikazi(a / b);
            }
        }

        private void btnOcisti_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = string.Empty;
            txtB.Text = string.Empty;
            txtRezultat.Text = string.Empty;
            txtPoruka.Text = string.Empty;
            txtA.Focus();
        }

        private void txtB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
