using System;

class Program
{
    static void Main()
    {
        int qtdPal = 0;
        while (qtdPal < 3 || qtdPal > 10)
        {
            Console.Write("Defina a quantidade de palavras (3 a 10): ");
            qtdPal = int.Parse(Console.ReadLine());
        }

        string[] pal = new string[qtdPal];

        for (int i = 0; i < pal.Length; i++)
        {
            Console.Write($"Digite a palavra {i + 1}: ");
            pal[i] = Console.ReadLine().ToLower();
        }

        Console.Write("Jogador está pronto? (sim/nao): ");
        string pronto = Console.ReadLine().ToLower();

        if (pronto != "sim")
        {
            Console.WriteLine("Tchauuuuuuuuuuu");
            return;
        }

        Random r = new Random();
        string palavra = pal[r.Next(0, pal.Length)];

        char[] tabuleiro = new char[palavra.Length];
        for (int i = 0; i < tabuleiro.Length; i++)
        {
            tabuleiro[i] = '_';
        }

        int erros = 0;
        bool venceu = false;

        while (erros < 6 && !venceu)
        {
            Console.WriteLine("\nPalavra: " + string.Join(" ", tabuleiro));
            Console.Write("Digite uma letra: ");
            char letra = char.Parse(Console.ReadLine().ToLower());

            bool acertou = false;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] == letra)
                {
                    tabuleiro[i] = letra;
                    acertou = true;
                }
            }

            if (!acertou)
            {
                erros++;
                Console.WriteLine($"Errrrrrrrrou! Tentativas restantes: {6 - erros}");
            }
            else
            {
                Console.WriteLine("Acertou uma letra!");
            }

            venceu = true;
            for (int i = 0; i < tabuleiro.Length; i++)
            {
                if (tabuleiro[i] == '_') venceu = false;
            }
        }

        if (venceu)
        {
            Console.WriteLine("\nParabéns vey! Você descobriu a palavra: " + palavra);
        }
        else
        {
            Console.WriteLine("\nFim*! A palavra era: " + palavra);
        }
    }
}
