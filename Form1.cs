using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaZakupów
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                if (textBox1.Text.Length > 0)
                {
                     if (listBox1.Items.Contains(textBox1.Text))
                    {
                        DialogResult result = MessageBox.Show("Ten element już istnieje, chcesz go dodać?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);//dialog result sluzy do przechowania informacji, ostrzeżenie o istniejącym elemencie
                        if (result == DialogResult.No)// jeśli użytkownik naciśnie "no"
                        {
                            return;
                        }
                    }
                    listBox1.Items.Add(textBox1.Text);//jesli lista ma jakies wartości, dodaj wpisaną wartość
                    aktualizujListę();//funkcja, która służy do aktualizowania wskaźnika
                    textBox1.Clear();//czyszczenie pola do wpisywania
                }
                else
                {
                    MessageBox.Show("Nie podano żadnej wartości!","Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista jest już pełna!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void aktualizujListę()
        {
            int ilość = listBox1.Items.Count;
            progressBar1.Value = ilość * 10;
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            int liczbaIndeksów = listBox1.SelectedIndex;
            if (liczbaIndeksów != -1)
            {
                listBox1.Items.RemoveAt(liczbaIndeksów);
            }
            else
            {
                MessageBox.Show("Żaden element nie został zaznaczony!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            aktualizujListę();

        }
    }
}
