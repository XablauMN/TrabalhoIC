using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Trampo
{
    public partial class ProductForm : Form
    {
        
        private List<int> uniVen;

        public ProductForm()
        {
            InitializeComponent();
            uniVen = new List<int>();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataText_Enter(object sender, EventArgs e)
        {
                dataText.Text = string.Empty;
                dataText.ForeColor = SystemColors.WindowText;
        }

        private void dataText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dataText.Text))
            {
                dataText.Text = "dd/MM/aaaa";
                dataText.ForeColor = SystemColors.ScrollBar;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            uniVen.Clear();
            uniVen.Add(int.Parse(umText.Text));
            uniVen.Add(int.Parse(doisText.Text));
            uniVen.Add(int.Parse(tresText.Text));
            uniVen.Add(int.Parse(quatroText.Text));
            uniVen.Add(int.Parse(cincoText.Text));

            Produto produto = new Produto(nameText.Text, int.Parse(codText.Text), dataText.Text, double.Parse(priceText.Text, CultureInfo.InvariantCulture), uniVen, infText.Text);
            produto.UnidadesVendidas = uniVen;

            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                ListViewItem item = new ListViewItem(produto.Codigo.ToString());
                item.SubItems.Add(produto.Nome);
                item.SubItems.Add(produto.Preco.ToString("F2", CultureInfo.InvariantCulture));
                item.SubItems.Add(string.Join(", ", produto.UnidadesVendidas));

                form1.listProduct.Items.Add(item);
            }
            nameText.Clear();
            codText.Clear();
            dataText.Clear();
            priceText.Clear();
            infText.Clear();
            umText.Clear();
            doisText.Clear();
            tresText.Clear();
            quatroText.Clear();
            cincoText.Clear();

            this.Close();

        }
    }
}
