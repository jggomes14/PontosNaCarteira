namespace PontosNaCarteira
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // Definir o limite de pontos para suspensão da CNH
            const int CNH_SUSPENSION_LIMIT = 20;

            // Criar uma lista de multas
            var multas = new List<(DateTime data, int pontos)>();

            // Pedir que o usuário informe as multas até que ele não queira mais adicionar
            while (true)
            {
                Console.Write("Digite a data da multa (DD/MM/AAAA): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime data))
                {
                    Console.WriteLine("Data inválida. Tente novamente.");
                    continue;
                }

                Console.Write("Digite a pontuação da multa: ");
                if (!int.TryParse(Console.ReadLine(), out int pontos))
                {
                    Console.WriteLine("Pontuação inválida. Tente novamente.");
                    continue;
                }

                multas.Add((data, pontos));

                Console.Write("Deseja adicionar outra multa? (s/n): ");
                if (Console.ReadLine().ToLower() != "s")
                {
                    break;
                }
            }

            // Obter a data atual
            var hoje = DateTime.Now;

            // Calcular a pontuação do motorista nos últimos 12 meses
            int pontuacao = 0;
            foreach (var multa in multas)
            {
                if (multa.data > hoje.AddYears(-1))
                {
                    pontuacao += multa.pontos;
                }
            }

            // Verificar se a pontuação atual excede o limite para suspensão da CNH
            if (pontuacao >= CNH_SUSPENSION_LIMIT)
            {
                Console.WriteLine("Sua CNH foi suspensa!");
            }
            else
            {
                Console.WriteLine("Sua pontuação atual é de: " + pontuacao);
            }
        }
    }

}