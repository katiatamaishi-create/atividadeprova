using System;

class Program
{
    static double calcularMedia(int[] roubos)
    {
        double soma = 0;

        for (int i = 0; i < roubos.Length; i++)
        {
            soma = soma + roubos[i];
        }

        double media = soma / roubos.Length;

        return media;
    }

    static void exibirTop3BairrosViolentos(string[] bairros, int[] roubos)
    {
        int[] usados = new int[3];

        Console.WriteLine("--- TOP 3 BAIRROS MAIS VIOLENTOS ---");

        for (int posicao = 0; posicao < 3; posicao++)
        {
            int maior = -1;
            int indiceMaior = -1;

            for (int i = 0; i < roubos.Length; i++)
            {
                bool jaUsado = false;

                for (int j = 0; j < posicao; j++)
                {
                    if (usados[j] == i)
                    {
                        jaUsado = true;
                    }
                }

                if (jaUsado == false && roubos[i] > maior)
                {
                    maior = roubos[i];
                    indiceMaior = i;
                }
            }

            usados[posicao] = indiceMaior;

            Console.WriteLine(
                (posicao + 1) + "o Lugar: " +
                bairros[indiceMaior] +
                " (Índice " + indiceMaior + ") - " +
                roubos[indiceMaior] + " roubos"
            );
        }
    }

    static void Main()
    {
        string[] bairros =
        {
            "Centro",
            "Moema",
            "Pinheiros",
            "Itaquera",
            "Tatuapé",
            "Santo Amaro",
            "Vila Mariana",
            "Lapa",
            "Capão Redondo",
            "Santana"
        };

        int[] roubos =
        {
            350, 120, 210, 480, 190,
            310, 150, 280, 520, 240
        };

        Console.WriteLine("=== ANÁLISE DE SEGURANÇA PÚBLICA - BAIRROS DE SP ===");

        double media = calcularMedia(roubos);

        Console.WriteLine("Média de roubos por bairro: " +
                          media.ToString("F2") +
                          " ocorrências");

        exibirTop3BairrosViolentos(bairros, roubos);
    }
}