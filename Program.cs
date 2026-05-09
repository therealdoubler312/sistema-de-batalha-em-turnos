using Sistema_de_Batalha_em_Turnos;

Unidade jogador = new Unidade(100, 20, 12, "Jogador");
Unidade inimigo = new Unidade(75, 10, 7, "Inimigo");
Random random = new Random();

while (!jogador.estaMorto && !inimigo.estaMorto)
{
    Console.WriteLine(jogador.NomeUnidade + " HP = " + jogador.Hp + " " + inimigo.NomeUnidade + " HP = " + inimigo.Hp);
    Console.WriteLine("Turno do Jogador! O que você irá fazer? [A] Atacar [C] Curar");
    string choice = Console.ReadLine();
    choice = choice.ToLower();

    if (choice == "a")
    {
        jogador.Ataque(inimigo);
    }
    else if (choice == "c")
    {
        jogador.Curar();
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    }
        
    Console.WriteLine("Pressione ENTER para continuar");
    Console.ReadLine();
    Console.Clear();

    if (jogador.estaMorto || inimigo.estaMorto)
        break;

    Console.WriteLine(jogador.NomeUnidade + " HP = " + jogador.Hp + ". " + inimigo.NomeUnidade + " HP = " + inimigo.Hp);
    Console.WriteLine("Turno do Inimigo!");

    int rand = random.Next(0, 2);

    if (rand == 0)
    {
        inimigo.Ataque(jogador);
    }
    else
        inimigo.Curar();
}