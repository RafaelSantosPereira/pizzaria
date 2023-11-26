using System;
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
    public partial class form_lista : Form
    {
        public form_lista(Button btn)
        {
            InitializeComponent();

            // Chama o metodo TipoIngredientes
            TipoIngrediente(btn);
        }

        /// <summary>
        /// Verifica se o nome do botão atribuido é igual ao da validação
        /// </summary>
        /// <param name="btn"> botão atribuido </param>
        private void TipoIngrediente(Button btn)
        {
            if (btn.Name == "bt4queijos")
            {
                queijos Queijos = new queijos();
                ingredientes.Items.Add(Queijos.molho);
                ingredientes.Items.Add(Queijos.queijo);
                ingredientes.Items.Add(Queijos.parmesão);
                ingredientes.Items.Add(Queijos.gorgonzola);
            }
            else if (btn.Name == "btpeperoni")
            {
                peperoni Peperoni = new peperoni();
                ingredientes.Items.Add(Peperoni.molho);
                ingredientes.Items.Add(Peperoni.queijo);
                ingredientes.Items.Add(Peperoni.ingpeperoni);
                ingredientes.Items.Add(Peperoni.oreganos);
            }
            else if (btn.Name == "btfrango")
            {
                frango Frango = new frango();
                ingredientes.Items.Add(Frango.molho);
                ingredientes.Items.Add(Frango.queijo);
                ingredientes.Items.Add(Frango.ingfrango);
                ingredientes.Items.Add(Frango.azeitona);
            }
        }
    }
}
