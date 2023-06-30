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
using System.Collections;

namespace Trampo
{
    public partial class Form1 : Form
    {
        private ProductForm productForm;
        private EditForm editForm;
        public Form1()
        {
            InitializeComponent();
            productForm = new ProductForm();
            editForm = new EditForm();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listProduct.Columns.Add("Código", 70).TextAlign = HorizontalAlignment.Center;
            listProduct.Columns.Add("Nome", 280).TextAlign = HorizontalAlignment.Center;
            listProduct.Columns.Add("Preço", 110).TextAlign = HorizontalAlignment.Center;
            listProduct.Columns.Add("Unidades Vendidas (Por ano)", 180).TextAlign = HorizontalAlignment.Center;
            listProduct.View = View.Details;

            listProduct.FullRowSelect = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            productForm.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (listProduct.SelectedItems.Count > 0) {
                ListViewItem selectedItem = listProduct.SelectedItems[0];

                int codigo = int.Parse(selectedItem.SubItems[0].Text);
                string nome = selectedItem.SubItems[1].Text;
                double preco = double.Parse(selectedItem.SubItems[2].Text, CultureInfo.InvariantCulture);
                List<int> unidadesVendidas = selectedItem.SubItems[3].Text.Split(',').Select(int.Parse).ToList();

                EditForm editForm = new EditForm(codigo, nome, preco, unidadesVendidas);

                editForm.ShowDialog();

                if (editForm.DialogResult == DialogResult.OK)
                {
                    selectedItem.SubItems[0].Text = editForm.Codigo.ToString();
                    selectedItem.SubItems[1].Text = editForm.Nome;
                    selectedItem.SubItems[2].Text = editForm.Preco.ToString("F2", CultureInfo.InvariantCulture);
                    selectedItem.SubItems[3].Text = string.Join(", ", editForm.UnidadesVendidas);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.", "Editar Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
    

        private void rmvBtn_Click(object sender, EventArgs e)
        {
            if (listProduct.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listProduct.SelectedItems[0];

                listProduct.Items.Remove(selectedItem);
            }
        }

        private void nomeMenu_Click(object sender, EventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            items.AddRange(listProduct.Items.Cast<ListViewItem>());

            items.Sort((x, y) => string.Compare(x.SubItems[1].Text, y.SubItems[1].Text, StringComparison.OrdinalIgnoreCase));

            listProduct.BeginUpdate();
            listProduct.Items.Clear();
            listProduct.Items.AddRange(items.ToArray());
            listProduct.EndUpdate();
        }
    }
}
