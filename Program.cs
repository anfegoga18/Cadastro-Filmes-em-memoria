using System;

namespace SoundTrackFilm
{
    class Program
    {
        static BandaRepositorio repositorio = new BandaRepositorio();
        static void Main(string[] args)
        {
            string SelecaoUsuario = EscolhaDoUsuario();

            while(SelecaoUsuario.ToUpper() != "X")
            {
                switch(SelecaoUsuario)
                {
                    case "1":
                    ListarFilmes();
                    break;

                    case "2":
                    InserirFilme();
                    break;

                    case "3":
                    AtualizarFilme();
                    break;

                    case "4":
                    ExcluirFilme();
                    break;

                    case "5":
                    VisualizarFilme();
                    break;

                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException("O valor inserido não está na lista");
                }

                SelecaoUsuario = EscolhaDoUsuario();                
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            
        }

        private static void ListarFilmes()
        {
            Console.WriteLine(" => Listar os filmes & Autor Banda Sonora (gênero musical)");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("  * A LISTA de Filmes está VAZIA  *");
                return;
            }

            
            foreach (var filme in lista)
            {
                var filmeFora = filme.retornaExcluido();

                Console.WriteLine("{0} {1} {2}",
                                  filme.retonaId(),
                                  filme.retornaBandaS(),
                                  (filmeFora ? "*Excluido*" : ""));
            }
        }

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir um novo filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.WriteLine();

			Console.Write("Digite o gênero do filme entre as opções apresentadas: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaFilme = Console.ReadLine();

			Console.Write("Digite o Ano de estreia do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o autor da banda sonora do filme: ");
			string entradaAutor = Console.ReadLine();

            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(GeneroB)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroB), i));
                
			}

            Console.WriteLine();

            Console.Write("Digite o gênero da Banda Sonora do filme" + 
                          Environment.NewLine + "entre as opções apresentadas:");
            
            int entradaGeneroB = int.Parse(Console.ReadLine());

            if (entradaGeneroB>7 ^ entradaGeneroB<=0)
            {
                throw new ArgumentOutOfRangeException("Opção escolhida está fora da lista");
            }
            else
            {
			    BandaSonora novoFilme = new BandaSonora(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										nomeFilme: entradaFilme,
										ano: entradaAno,
										descricaoFilme: entradaDescricao,
                                        autorBanda: entradaAutor,
                                        generoB: (GeneroB)entradaGeneroB,
                                        excluido: false);
                                        

			    repositorio.Insere(novoFilme);
            }
            
		}

        private static void AtualizarFilme()
		{
			Console.WriteLine("Qual filme deseja atualizar?");
            int filmeAtualizar = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.WriteLine();

			Console.Write("Digite o novo gênero do filme entre as opções apresentadas: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o novo Título do filme: ");
			string entradaFilme = Console.ReadLine();

			Console.Write("Digite o novo Ano de estreia do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a nova Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o novo autor da banda sonora do filme: ");
			string entradaAutor = Console.ReadLine();

            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(GeneroB)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroB), i));
                
			}

            Console.WriteLine();

            Console.Write("Digite o novo gênero da Banda Sonora do filme" + 
                          Environment.NewLine + "entre as opções apresentadas:");
            
            int entradaGeneroB = int.Parse(Console.ReadLine());

            if (entradaGeneroB>7 ^ entradaGeneroB<=0)
            {
                throw new ArgumentOutOfRangeException("Opção escolhida está fora da lista");
            }
            else
            {
			    BandaSonora atualizarBanda = new BandaSonora(id: filmeAtualizar,
										genero: (Genero)entradaGenero,
										nomeFilme: entradaFilme,
										ano: entradaAno,
										descricaoFilme: entradaDescricao,
                                        autorBanda: entradaAutor,
                                        generoB: (GeneroB)entradaGeneroB,
                                        excluido: false);
                                        

			    repositorio.Atualiza(filmeAtualizar , atualizarBanda);
            }
            
		}

        private static void ExcluirFilme()
		{
			Console.WriteLine("Qual filme deseja excluir?, escreva o Id");
            var filmeAexcluir = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Deseja realmente excluir o registro a seguir?:" + 
            Environment.NewLine + Environment.NewLine + $"{repositorio.RetornaPorId(filmeAexcluir)}"+
            Environment.NewLine + Environment.NewLine + "Escreva S para Sim ou N para Não");
            Console.WriteLine();

            var Opcao = Console.ReadLine().ToUpper();

            switch(Opcao)
                {
                    case "S":
                    repositorio.Exclui(filmeAexcluir);
                    break;

                    case "N":
                    Console.WriteLine("Entendido, o filme continuará ativo");
                    break;

                    default:
                    throw new ArgumentOutOfRangeException("valor inserido invalido!");

                }        
            
        }

        private static void VisualizarFilme()
		{
			Console.WriteLine("Qual filme deseja visualizar?, escreva o Id");
            int filmeVisualizado = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(filmeVisualizado);
            Console.WriteLine();
            Console.WriteLine("   * DESCRIÇÃO *   "+ Environment.NewLine);
            Console.WriteLine(filme);

        }

        private static string EscolhaDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("BÉM-VINDO!");
            Console.WriteLine("Este é o Filmes & Bandas sonoras");
            Console.WriteLine("O quê gostaria de fazer?:");
            Console.WriteLine();

            Console.WriteLine("1. Listar os filmes & Autor Banda Sonora (Gênero)");
            Console.WriteLine("2. Inserir um novo filme");
            Console.WriteLine("3. Atualizar um filme");
            Console.WriteLine("4. Excluir um filme");
            Console.WriteLine("5. Ver descrição de um filme");
            Console.WriteLine("6. Limpar a Tela");
            Console.WriteLine("X  Sair");
            Console.WriteLine("");

            string EscolhaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return EscolhaUsuario;
        }
    }
}
