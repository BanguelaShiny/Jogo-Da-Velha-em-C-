using System.Text.RegularExpressions;

namespace JogoDaVelha;
class Program
{
    static char[,] matriz = new char[3, 3];
    static char jogador = 'X';
    static bool fim = false;

    static void Main(string[] args)
    {
        PreencherMatriz();
        while (!fim)
        {
            ImprimirMatriz();
            Jogada();
            FimDeJogo();
            TrocarJogador();
        }
    }

    static void PreencherMatriz()
    {
        
        for(int i = 0; i < matriz.GetLength(0); i++)
        {
            for( int j = 0; j < matriz.GetLength(1); j++)
            {
                matriz[i, j] = '-';
                
            }
        }
    }
    static void ImprimirMatriz()
    {
        Console.Clear();
        Console.WriteLine($"Jogo Da Velha");
        Console.WriteLine();
        Console.WriteLine("---------------------");
        for (int i =0; i < matriz.GetLength(0); i++)
        {
            for(int j = 0;j < matriz.GetLength(1); j++)
            {
                Console.Write($" [ {matriz[i, j]} ] ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("---------------------");
    }
    static void Jogada()
    {
        Console.WriteLine($"Jogador {jogador}, faça sua jogada.");
        Console.Write("Digite a linha onde deseja jogar: ");
        int linhas = int.Parse(Console.ReadLine()!);
        Console.Write("Digite a coluna onde deseja jogar: ");
        int colunas = int.Parse(Console.ReadLine()!);

        if (matriz[linhas-1,colunas-1]=='-')
        {
            matriz[linhas-1, colunas - 1] = jogador;
        }
        else
        {
            Console.WriteLine("Jogada inválida, tente novamente.");
            Jogada();
        }
    }
    static void FimDeJogo()
    {
        if (Vencedor())
        {
            ImprimirMatriz();
            Console.WriteLine($"Vitória do Jodaro: {jogador} !");
            fim = true;
        }
        else if (Empate())
        {
            ImprimirMatriz();
            Console.WriteLine("Empate!");
            fim = true;
        }
    }
    static bool Vencedor()
    {
        //Vitória em linhas
        for(int i = 0; i < matriz.GetLength(0); i++)
        {
            if (matriz[i,0]==jogador && matriz[i,1]==jogador && matriz[i, 2] == jogador)
            {
                return true;
            }
        }
        //Vitória em Colunas
        for(int i = 0;i < matriz.GetLength(1); i++)
        {
            if (matriz[0,i]==jogador && matriz[1,i]==jogador && matriz[2, i] == jogador)
            {
                return true;
            }
        }
        //Vitória em Diagonais
        if((matriz[0, 0] == jogador && matriz[1, 1] == jogador && matriz[2, 2] == jogador) ||
          (matriz[0, 2] == jogador && matriz[1, 1] == jogador && matriz[2, 0] == jogador))
        {
             return true;
        }
        return false;
    }
    static bool Empate()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matriz[i, j] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }
    static void TrocarJogador()
    {
        jogador = (jogador == 'X') ? 'O' : 'X';
    }
}