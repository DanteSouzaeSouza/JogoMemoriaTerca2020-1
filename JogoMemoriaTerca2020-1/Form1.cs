using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JogoMemoriaTerca2020_1
{
    public partial class FrmMemoria : Form
    {
        // criando a lista de ícone
        private readonly List<string> icones = new List<string>
        {
            // criando os pares de elementos a irem para o tabuleiro
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "H", "H", "z", "z"
        };

        // criando variáveis para armazenar os cliques
        private Label primeiroClique;
        private Label segundoClique;

        // adicionando código que gerará os
        // elementos do tabuleiro de forma aleatória:
        // instanciando um objeto Random
        private readonly Random random = new Random();

        public FrmMemoria()
        {
            InitializeComponent();
            AdicionaIconesQuadrados(); // chamando o método para criar o tabuleiro
        }

        // método que adiciona icones de forma aleatória ao tabuleiro
        private void AdicionaIconesQuadrados()
        {
            // nosso painel tem 16 casas
            // e a lista 16 elementos (8 pares)
            // ler a lista e adicionar o ícone ao tabuleiro
            // para cada controle ou elemento (labels) dentro do tlpTabuleiro
            foreach (var controle in tlpTabuleiro.Controls)
            {
                // executar:
                // ligando o ícone com uma das labels do formulário
                var icone = controle as Label;
                // se o ícone não está vazio, executar:
                if (icone != null)
                {
                    // recebendo o índice de algum dos ícones da Lista
                    // de ícones de forma aleatoria
                    var numeroAleatorio = random.Next(icones.Count);
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

        // função que checa se o jogo acabou e alguem ganhou
        private void checaGanhador()
        {
            // checar por ícones que não combinam
            foreach (var controle in tlpTabuleiro.Controls)
            {
                var icone = controle as Label;

                // se o ícone for diferente de nulo:
                if (icone != null)
                    // checando se as cores de frente e de fundo batem
                    if (icone.ForeColor == icone.BackColor)
                        // para tudo
                        return;
            }

            // mostrando janela ao vencedor:
            MessageBox.Show("Você acertou todas!", "Parabéns!!");
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // usando o sender para captar o icone clicado
            var iconeClicado = sender as Label;

            // checar se uma label foi realmente clicada
            if (iconeClicado != null)
            {
                // checando a cor atual do ícone clicado
                if (iconeClicado.ForeColor == Color.Black)
                    // a cor do ícone é preta,  não fazer nada
                    return;
                // checando se é o primeiro clique do jogador
                if (primeiroClique == null)
                {
                    // se for, joga iconeclicado dentro do primeiroclique
                    primeiroClique = iconeClicado;
                    // caso ele esteja invisivel, atribuir cor preta
                    primeiroClique.ForeColor = Color.Black;
                    // sair do método se for o primeiro clique:
                    return;
                }

                // se o jogador chegou até essa parte do código
                // é porque ele está clicando uma segunda vez
                segundoClique = iconeClicado;
                segundoClique.ForeColor = Color.Black;

                // checando se o jogo acabou
                checaGanhador();


                // checando se as dois icones clicados são iguais:
                if (primeiroClique.Text == segundoClique.Text)
                {
                    primeiroClique = null;
                    segundoClique = null;
                    return;
                }

                // iniciar a contagem do timer:
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // parar o timer se ele estiver rodando:
            timer1.Stop();

            // esconder os dois ícones
            primeiroClique.ForeColor = primeiroClique.BackColor;
            segundoClique.ForeColor = segundoClique.BackColor;

            // resetar as variáveis que computam os cliques:
            primeiroClique = null;
            segundoClique = null;
        }
    }
}