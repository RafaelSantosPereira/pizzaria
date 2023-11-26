using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10e11_progeto_final
{
    
    public class pizas
    {
        private string sabor;
        private string nome;
        private string credito;
        private string telefone;
        private string morada;
        private int quantidade;
        private double preco;
        public string molho = "molho de tomate";
        public string queijo = "queijo muçarela";
        private string tamanho;


        public string Nome { get => nome; set => nome = value; }
        public string Credito { get => credito; set => credito = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double Preco { get => preco; set => preco = value; }
        public string Sabor { get => sabor; set => sabor = value; }
        public string Morada { get => morada; set => morada = value; }
        public string Tamanho { get => tamanho; set => tamanho = value; }

        public virtual double calcular()
        {
            return Preco;
        }
    }
    public class peperoni : pizas
    {
        public override double calcular()
        {
            base.calcular();
            if (Tamanho == "Media") Preco = 8 * Quantidade;
            else if (Tamanho == "Pequena") Preco = 5 * Quantidade;
            else if (Tamanho == "Grande") Preco = 12 * Quantidade;
            return Preco;

        }
        public string ingpeperoni = "peperoni";
        public string oreganos = "oreganos";
    }
    public class queijos : pizas
    {
        public override double calcular ()
        {
            base.calcular ();
            if (Tamanho == "Media") Preco = 9 * Quantidade;
            else if (Tamanho == "Pequena") Preco = 6 * Quantidade;
            else if (Tamanho == "Grande") Preco = 13 * Quantidade;
            return Preco;

        }
        public string gorgonzola = "queijo gorgonzola";
        public string parmesão = "queijo parmesão";

    }
    public class frango : pizas
    {
        public override double calcular()
        {
            base.calcular();
            if (Tamanho == "Media") Preco = 8.5 * Quantidade;
            else if (Tamanho == "Pequena") Preco = 5.5 * Quantidade;
            else if (Tamanho == "Grande") Preco = 12.50 * Quantidade;
            return Preco;

        }
        public string ingfrango = "frango";
        public string azeitona = "azeitonas";
    }
    
    static class classlista
    {
        public static List<pizas> listapizas = new List<pizas>();
    }
}
