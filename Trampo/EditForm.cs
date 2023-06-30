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
    public partial class EditForm : Form
    {

        public EditForm()
        {
            InitializeComponent();
        }

        public string Nome { get; set; }
        public int Codigo { get; set; }
        public double Preco { get; set; }
        public List<int> UnidadesVendidas { get; set; }

        private int codigo;
        private string nome;
        private double preco;
        private List<int> unidadesVendidas;

        public EditForm(int codigo, string nome, double preco, List<int> unidadesVendidas)
        {
            InitializeComponent();

            this.codigo = codigo;
            this.nome = nome;
            this.preco = preco;
            this.unidadesVendidas = unidadesVendidas;

            FillFields(); // Chamar o método para preencher os campos
        }

        public void FillFields()
        {
            codText.Text = codigo.ToString();
            nameText.Text = nome;
            priceText.Text = preco.ToString("F2", CultureInfo.InvariantCulture);
            umText.Text = unidadesVendidas[0].ToString();
            doisText.Text = unidadesVendidas[1].ToString();
            tresText.Text = unidadesVendidas[2].ToString();
            quatroText.Text = unidadesVendidas[3].ToString();
            cincoText.Text = unidadesVendidas[4].ToString();


        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Nome = nameText.Text;
            Codigo = int.Parse(codText.Text);
            Preco = double.Parse(priceText.Text, CultureInfo.InvariantCulture);
            UnidadesVendidas = new List<int>
        {
            int.Parse(umText.Text),
            int.Parse(doisText.Text),
            int.Parse(tresText.Text),
            int.Parse(quatroText.Text),
            int.Parse(cincoText.Text)
        };


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataText_Enter(object sender, EventArgs e)
        {
            dataText.Text = string.Empty;
            dataText.ForeColor = SystemColors.WindowText;
        }
    }
}
