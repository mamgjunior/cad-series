using System;

namespace dio.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            const string sair = "X";
            string opcao = menu();
            while (opcao.ToUpper() != sair)
            {
                switch (opcao)
                {
                    case "1":
                        listarSeries();
                        break;
                    case "2":
                        inserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        excluirSerie();
                        break;
                    case "5":
                        visualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = menu();
            }
        }

        private static void visualizarSerie()
        {
            Console.Write("Digite o id da serie:");
            int id = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(id: id);
            Console.WriteLine(serie);
        }

        private static void excluirSerie()
        {
            Console.Write("Digite o id da serie:");
            int id = int.Parse(Console.ReadLine());
            repositorio.Excluir(id: id);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie:");
            int id = int.Parse(Console.ReadLine());

            foreach (int contador in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0} - {1}", contador, Enum.GetName(typeof(Genero), contador));

            Console.Write("Escolha um genero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da serie: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie: ");
            string descricao = Console.ReadLine();

            Serie serie = new Serie(id: id, genero: (Genero)genero, titulo: titulo, ano: ano, descricao: descricao);
            repositorio.Atualizar(id: id, entidade: serie);
        }

        private static void inserirSerie()
        {
            Console.WriteLine("*** Inserir uma nova serie ***");

            foreach (int contador in Enum.GetValues(typeof(Genero)))
                Console.WriteLine("{0} - {1}", contador, Enum.GetName(typeof(Genero), contador));

            Console.Write("Escolha um genero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da serie: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie: ");
            string descricao = Console.ReadLine();

            Serie serie = new Serie(id: repositorio.ProximoId(), genero: (Genero)genero, titulo: titulo, ano: ano, descricao: descricao);
            repositorio.Inserir(serie);
        }

        private static void listarSeries()
        {
            Console.WriteLine("*** Lista de Séries ***");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Não existe series cadastradas...");
                return;
            }                
            else
            {
                foreach (var serie in lista)
                {
                    Console.WriteLine("#Id - {0} | Descrição: {1}", serie.retornarId(), serie.retornarTitulo());
                }
            }
        }

        private static string menu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir séries");
            Console.WriteLine("3 - Atualizar séries");
            Console.WriteLine("4 - Excluir séries");
            Console.WriteLine("5 - Visualizar series");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }
    }
}
