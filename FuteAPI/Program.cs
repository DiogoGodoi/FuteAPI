
using FuteAPI.Controller;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FuteAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ApiFut api = new ApiFut();  

            var continua = "";

            var clubes = await api.GetClubes();

            var ranking = clubes.OrderBy(i => i.posicao);

            do
            {
                Console.WriteLine("TABELA BRASILEIRÃO SERIE A");

                Console.WriteLine(" ");

                foreach (var club in ranking)
                {

                    Console.WriteLine($"{club.posicao} | {club.time.nome_popular} | Pontos: {club.pontos}");

                }

                Console.WriteLine(" ");
                Console.WriteLine("DESEJA FAZER NOVA PESQUISA?");
                continua = Console.ReadLine();
                Console.WriteLine(" ");

            } while (continua == "Sim" || continua == "SIM" || continua == "sim");

        }
    }
}
