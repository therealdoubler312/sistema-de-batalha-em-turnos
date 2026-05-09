using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Batalha_em_Turnos
{
    internal class Unidade
    {
        private int hpAtual;
        private int hpMaximo;
        private int poderAtaque;
        private int poderCura;
        private string nomeUnidade;
        private Random random;

        public int Hp { get { return hpAtual; } }

        public string NomeUnidade { get { return nomeUnidade; } }

        public bool estaMorto { get { return hpAtual <= 0; } }
        public Unidade(int hpMaximo, int poderAtaque, int poderCura, string nomeUnidade)
        {
            this.hpMaximo = hpMaximo;
            this.hpAtual = hpMaximo;
            this.poderAtaque = poderAtaque;
            this.poderCura = poderCura;
            this.nomeUnidade = nomeUnidade;
            this.random = new Random();
        }

        public void Ataque(Unidade unidadeAtacar)
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int ranDano = (int)(poderAtaque * rng);
            unidadeAtacar.levarDano(ranDano);
            Console.WriteLine(nomeUnidade + " Ataca " + unidadeAtacar.nomeUnidade + " e dá " + ranDano + " de Dano de Ataque! ");
            Console.WriteLine("-------------------------");
        }

        public void levarDano(int dano)
        {
            hpAtual -= dano;

            if (estaMorto)
            {
                Console.WriteLine(NomeUnidade + " foi derrotado(a)!");
            }
        }

        public void Curar()
        {
            if (hpAtual == hpMaximo)
                Console.WriteLine($"O HP do(a) {nomeUnidade} está no máximo!");
            else if (hpAtual < (hpMaximo * 40) / 100)
            {
                double rng = random.NextDouble();
                rng = rng / 2 + 0.75f;
                int cura = (int)(poderCura * rng);
                hpAtual = cura + hpAtual > hpMaximo ? hpMaximo : hpAtual + cura;
                Console.WriteLine(NomeUnidade + " se cura e recupera " + cura + " de HP! ");
            }
            
        }
    }
}
