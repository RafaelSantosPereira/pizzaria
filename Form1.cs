using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M10e11_progeto_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sabor;
        private void bt4queijos_Click(object sender, EventArgs e)
        {
            btfrango.Visible = false;
            btpeperoni.Visible = false;
            lbfrango.Visible = false;
            lbpeperoni.Visible = false;
            btlista.Visible = true;
            sabor = "4 queijos";
            this.Size = new Size(617, 549);
            tabControl1.Size = new Size(576, 460);
        }

        private void btpeperoni_Click(object sender, EventArgs e)
        {
            btfrango.Visible = false;
            bt4queijos.Visible = false;
            lb4queijos.Visible = false;
            lbfrango.Visible = false;
            btlista.Visible = true;
            sabor = "Peperoni";
            this.Size = new Size(617, 549);
            tabControl1.Size = new Size(576, 460);
        }

        private void btfrango_Click(object sender, EventArgs e)
        {
            bt4queijos.Visible = false;
            btpeperoni.Visible = false;
            lb4queijos.Visible = false;
            lbpeperoni.Visible = false;
            btlista.Visible = true;
            sabor = "Frango";
            this.Size = new Size(617, 549);
            tabControl1.Size = new Size(576, 460);
            
        }

        private void btvoltar_Click(object sender, EventArgs e)
        {
            _formload?.Close();
            bt4queijos.Visible = true;
            btpeperoni.Visible = true;
            lb4queijos.Visible = true;
            lbpeperoni.Visible = true;
            btfrango.Visible = true;
            lbfrango.Visible = true;
            btlista.Visible = false;
            tabControl1.Size = new Size(576, 260);
            this.Size = new Size(617, 348);
            lb4queijos.Text = "4 Queijos - 9€";
            lbfrango.Text = "Frango - 8.50€";
            lbpeperoni.Text = "Peperoni - 8€";
            cbtamanho.Text = "Media";
        }

        private Form _formload;

        /// <summary>
        /// Verifica se ja existe algum form aberto, caso isso seja verdade ele fecha o form aberto
        /// em seguida ele abre o form  escolhido, com as seguintes propriedades, e abre o form no
        /// panel pnlLista.
        /// </summary>
        private void btlista_Click(object sender, EventArgs e)
        {
            _formload?.Close();
            pnlista.Visible = true;
            if(bt4queijos.Visible == true)
            {
                _formload = new form_lista(bt4queijos)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                pnlista.Controls.Add(_formload);
                _formload.Show();         
            }
            else if(btpeperoni.Visible == true)
            {

                _formload = new form_lista(btpeperoni)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                pnlista.Controls.Add(_formload);
                _formload.Show();
            }
            else if (btfrango.Visible == true)
            {
                _formload = new form_lista(btfrango)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                pnlista.Controls.Add(_formload);
                _formload.Show();
            }
        }

        double preco;
        private void btcalcular_Click(object sender, EventArgs e)
        {

            
            int quant = (int)numericUpDown1.Value;
            string tamanho = cbtamanho.Text;
            if (bt4queijos.Visible == true)
            {
                queijos Queijos = new queijos();
                Queijos.Tamanho = tamanho;
                Queijos.Quantidade = quant;
                lbtotal.Text = Queijos.calcular().ToString()+"€";
                preco = Queijos.calcular();
            }
            else if (btpeperoni.Visible == true)
            {
                peperoni Peperoni = new peperoni();
                Peperoni.Tamanho = tamanho;
                Peperoni.Quantidade = quant;
                lbtotal.Text = Peperoni.calcular().ToString()+ "€";
                preco = Peperoni.calcular();
            }
            else if (btfrango.Visible == true)
            {
                frango Frango = new frango();
                Frango.Tamanho = tamanho;
                Frango.Quantidade = quant;
                lbtotal.Text = Frango.calcular().ToString()+"€";
                preco = Frango.calcular();
            }
            
            btpagar.Visible = true;
        }
        private void mostrar()
        {
            FileStream ficheiro2 = new FileStream("dados_pizas.xml", FileMode.Open, FileAccess.Read);

            XmlSerializer serie2 = new XmlSerializer(typeof(List<pizas>));//rever o tipo de dados

            classlista.listapizas = (List<pizas>)(serie2.Deserialize(ficheiro2));//rever o tipo de dados
            ficheiro2.Close();
            dgv.Rows.Clear();
            foreach (pizas p in classlista.listapizas)
            {
                dgv.Rows.Add(p.Nome, p.Credito, p.Telefone, p.Morada, p.Sabor,p.Tamanho, p.Quantidade, p.Preco + "€");
            }
        }
        private void btpagar_Click(object sender, EventArgs e)
        {
            try
            {
                pizas Pizas = new pizas();
                if (float.Parse(mtbcredito.Text) <= 999999999999999 || float.Parse(mtbtelefone.Text) <= 99999999)
                {
                    MessageBox.Show("intrduza todos os digitos necessarios nos campos");
                }
                else
                {               
                    Pizas.Nome = txtnome.Text;
                    Pizas.Telefone = mtbtelefone.Text;
                    Pizas.Credito = mtbcredito.Text;
                    Pizas.Quantidade = (int)numericUpDown1.Value;
                    Pizas.Morada = txtmorada.Text;
                    Pizas.Tamanho = cbtamanho.Text;
                    Pizas.Preco = preco;

                    Pizas.Sabor = sabor;
                    classlista.listapizas.Add(Pizas);

                    FileStream ficheiro = new FileStream("dados_pizas.xml", FileMode.Create, FileAccess.Write);
                    XmlSerializer serie = new XmlSerializer(typeof(List<pizas>));//rever o tipo de dados
                    serie.Serialize(ficheiro, classlista.listapizas);
                    ficheiro.Close();
                    mostrar();
                    MessageBox.Show("Parabens, compra bem sucedida");
                    tabControl1.SelectedIndex = 1;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("preencha todos os campos");
            }
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(576,260);
            this.Size = new Size(617, 348);
            if (File.Exists("dados_pizas.xml") == false)
            {
                FileStream ficheiro = new FileStream("dados_pizas.xml", FileMode.Create, FileAccess.Write);
                ficheiro.Close();
            }
            else
                mostrar();
            
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.Size = new Size(750, 375);
                this.Size = new Size(790, 460);
            }
            else
            {
                tabControl1.Size = new Size(576, 260);
                this.Size = new Size(617, 360);
                btpeperoni.Visible = true;
                btfrango.Visible = true;
                bt4queijos.Visible = true;
                lbpeperoni.Visible = true;
                lbfrango.Visible = true;
                lb4queijos.Visible = true;
                pnlista.Visible = false;

            }
        }

        private void cbtamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtamanho.SelectedIndex == 0)
            {
                lb4queijos.Text = "4 Queijos - 6€";
                lbfrango.Text = "Frango - 5.50€";
                lbpeperoni.Text = "Peperoni - 5€";
            }
            else if(cbtamanho.SelectedIndex == 1)
            {
                lb4queijos.Text = "4 Queijos - 9€";
                lbpeperoni.Text = "Peperoni - 8€";
                lbfrango.Text = "Frango - 8.50€";
            }
            else if(cbtamanho.SelectedIndex == 2)
            {
                lb4queijos.Text = "4 Queijos - 13€";
                lbpeperoni.Text = "Peperoni - 12€";
                lbfrango.Text = "Frango - 12.50€";
            }
        }
      
        private void btlimpar_Click(object sender, EventArgs e)
        {
            txtnome.Clear();
            txtmorada.Clear();
            mtbcredito.Clear();
            mtbtelefone.Clear();
            lbtotal.ResetText();
            numericUpDown1.Value = 1;
        }
    }
}
