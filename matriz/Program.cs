using System;
using System.IO;

class Program
{
    static int[,] carregarMatriz(string nomeArquivo)
    {
        int[,] matriz = new int[6, 6];

        string[] linhas = File.ReadAllLines(nomeArquivo);

        for (int i = 0; i < 6; i++)
        {
            string[] valores = linhas[i].Split(',');

            for (int j = 0; j < 6; j++)
            {
                matriz[i, j] = int.Parse(valores[j]);
            }
        }

        return matriz;
    }

    static void exibirMatriz(int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write("| " + matriz[i, j] + " ");
            }

            Console.WriteLine("|");
        }
    }

    static double[] calcularPercentuaDesmatamento(int[,] matriz)
    {
        double[] percentual = new double[1];

        double quantidadeDesmatada = 0;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] == 0)
                {
                    quantidadeDesmatada++;
                }
            }
        }

        percentual[0] = quantidadeDesmatada * 100 / 36;

        return percentual;
    }

    static void analisarAumento(int[,] matrizAnterior, int[,] matrizAtual)
    {
        double[] percentualAnterior =
            calcularPercentuaDesmatamento(matrizAnterior);

        double[] percentualAtual =
            calcularPercentuaDesmatamento(matrizAtual);

        Console.WriteLine(
            "Percentual de ocorrências na matriz 6 meses atrás:"
        );

        Console.WriteLine(
            "Área Desmatada (Código 0): " +
            percentualAnterior[0].ToString("F2") + "%"
        );

        Console.WriteLine();

        Console.WriteLine(
            "Percentual de ocorrências na matriz atual:"
        );

        Console.WriteLine(
            "Área Desmatada (Código 0): " +
            percentualAtual[0].ToString("F2") + "%"
        );

        Console.WriteLine();

        if (percentualAtual[0] > percentualAnterior[0])
        {
            Console.WriteLine(
                "Houve Aumento no Desmatamento – Anterior " +
                percentualAnterior[0].ToString("F2") +
                "% -> Atual " +
                percentualAtual[0].ToString("F2") +
                "%"
            );
        }
        else if (percentualAtual[0] < percentualAnterior[0])
        {
            Console.WriteLine(
                "Houve Redução no Desmatamento – Anterior " +
                percentualAnterior[0].ToString("F2") +
                "% -> Atual " +
                percentualAtual[0].ToString("F2") +
                "%"
            );
        }
        else
        {
            Console.WriteLine(
                "O Desmatamento permaneceu igual – Anterior " +
                percentualAnterior[0].ToString("F2") +
                "% -> Atual " +
                percentualAtual[0].ToString("F2") +
                "%"
            );
        }
    }

    static void Main()
    {
        int[,] matrizAnterior =
            carregarMatriz("dados_matriz_6meses_atras.csv");

        int[,] matrizAtual =
            carregarMatriz("dados_matriz_atual.csv");

        Console.WriteLine("Matriz 6 Meses Atras:");
        exibirMatriz(matrizAnterior);

        Console.WriteLine();

        Console.WriteLine("Matriz Atual:");
        exibirMatriz(matrizAtual);

        Console.WriteLine();

        analisarAumento(matrizAnterior, matrizAtual);
    }
}