using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoMemoriaTerca2020_1
{
    public partial class FrmMemoria : Form
    {
        // adicionando código que gerará os
        // elementos do tabuleiro de forma aleatória:
        // instanciando um objeto Random
        Random random = new Random();

        // criando a lista de ícone
        private List<string> icones = new List<string>()
        {  // criando os pares de elementos a irem para o tabuleiro
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "H", "H", "z", "z"
        };

        // método que adiciona icones de forma aleatória ao tabuleiro
        private void AdicionaIconesQuadrados()
        {
            // nosso painel tem 16 casas
            // e a lista 16 elementos (8 pares)
            // ler a lista e adicionar o ícone ao tabuleiro
            // para cada controle ou elemento (labels) dentro do tlpTabuleiro
            foreach (Control controle in tlpTabuleiro.Controls)
            {
                // executar:
                // ligando o ícone com uma das labels do formulário
                Label icone = controle as Label;
                // se o ícone não está vazio, executar:
                if (icone != null)
                {
                    // recebendo o índice de algum dos ícones da Lista
                    // de ícones de forma aleatoria
                    int numeroAleatorio = random.Next(icones.Count);
                    // alterar o texto de uma label usando o
                    // caractere de acordo com o índice obtido acima
                    icone.Text = icones[numeroAleatorio];
                    // pintar o ícone adicionado com a mesma cor do fundo
                    icone.ForeColor = icone.BackColor;
                    // removendo da lista o ícone usado acima:
                    icones.RemoveAt(numeroAleatorio);
                }
            }
        }
        public FrmMemoria()
        {
            InitializeComponent();
            AdicionaIconesQuadrados();// chamando o método para criar o tabuleiro
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // usando o sender para captar o icone clicado
            Label iconeClicado = sender as Label;

            // checar se uma label foi realmente clicada
            if (iconeClicado != null)
            {
                // checando a cor atual do ícone clicado
                if (iconeClicado.ForeColor == Color.Black)
                {
                    // a cor do ícone é preta,  não fazer nada
                    return;
                }
                // caso ele esteja invisivel, atribuir cor preta
                iconeClicado.ForeColor = Color.Black;
            }
        }
    }
}
