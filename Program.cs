using System;

namespace DIO.Ligas
{
    class Program
    {
        static LigaRepositorio repositorio = new LigaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarLigas();
						break;
					case "2":
						InserirLiga();
						break;
					case "3":
						AtualizarLiga();
						break;
					case "4":
						ExcluirLiga();
						break;
					case "5":
						VisualizarLiga();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirLiga()
		{
			Console.Write("Digite o id da liga: ");
			int indiceLiga = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceLiga);
		}

        private static void VisualizarLiga()
		{
			Console.Write("Digite o id da liga: ");
			int indiceLiga = int.Parse(Console.ReadLine());

			var liga = repositorio.RetornaPorId(indiceLiga);

			Console.WriteLine(liga);
		}

        private static void AtualizarLiga()
		{
			Console.Write("Digite o id da liga: ");
			int indiceLiga = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Modalidade)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Modalidade), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaModalidade = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da liga: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Ano de Início da liga: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Divisão da liga: ");
			string entradaDivisao = Console.ReadLine();

			Liga atualizaLiga = new Liga(id: indiceLiga,
										modalidade: (Modalidade)entradaModalidade,
										nome: entradaNome,
										ano: entradaAno,
										divisao: entradaDivisao);

			repositorio.Atualiza(indiceLiga, atualizaLiga);
		}
        private static void ListarLigas()
		{
			Console.WriteLine("Listar ligas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma liga cadastrada.");
				return;
			}

			foreach (var liga in lista)
			{
                var excluido = liga.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", liga.retornaId(), liga.retornaNome(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirLiga()
		{
			Console.WriteLine("Inserir nova liga");

			
			foreach (int i in Enum.GetValues(typeof(Modalidade)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Modalidade), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaModalidade = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da liga: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Ano de Início da liga: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Divisão da liga: ");
			string entradaDivisao = Console.ReadLine();

			Liga novaLiga = new Liga(id: repositorio.ProximoId(),
										modalidade: (Modalidade)entradaModalidade,
										nome: entradaNome,
										ano: entradaAno,
										divisao: entradaDivisao);

			repositorio.Insere(novaLiga);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Ligas Esportivas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Ligas");
			Console.WriteLine("2- Inserir nova Liga");
			Console.WriteLine("3- Atualizar liga");
			Console.WriteLine("4- Excluir liga");
			Console.WriteLine("5- Visualizar liga");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
