using System;

namespace APP_simples_de_cadastro_de_jogos
{
    class Program
    {
        static JogosRepositorio repositorio = new JogosRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario.ToUpper())
                {
					case "1":
						ListarJogos();
						break;
					case "2":
						InserirJogo();
						break;
					case "3":
						AtualizarJogo();
						break;
					case "4":
						ExcluirJogo();
						break;
					case "5":
						VisualizarJogo();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
                }
				opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static void ListarJogos(){
            Console.WriteLine("Listar jogos");
            var lista = repositorio.Lista();
            if (lista.Count == 0){
                Console.WriteLine("Nenhum jogo cadastrado.");
            }else{
                foreach(var jogos in lista){
                    var excluido = jogos.getExcluido();
                    
                    Console.WriteLine("#Id {0}: - {1} {2}", jogos.getId(), jogos.getTitulo(), (excluido ? "*Excluido*" : ""));
                }
            }
        }

        private static void InserirJogo(){
            Console.WriteLine("Inserir novo jogo");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título do jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do inicio do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogos novoJogo = new Jogos(id: repositorio.ProximoId(), 
                                       genero: (Genero)entradaGenero, 
                                       titulo: entradaTitulo, 
                                       descricao: entradaDescricao,
                                       ano: entradaAno);
            repositorio.Insere(novoJogo);

        }

        public static void AtualizarJogo(){
            Console.WriteLine("Digite o id da série: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            foreach (var i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título do jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogos atualizaJogo = new Jogos(id: indiceJogo, 
                                       genero: (Genero)entradaGenero, 
                                       titulo: entradaTitulo, 
                                       descricao: entradaDescricao,
                                       ano: entradaAno);
            
            repositorio.Atualiza(indiceJogo, atualizaJogo);
        }


        public static void ExcluirJogo(){
            Console.WriteLine("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceJogo);
        }

        public static void VisualizarJogo(){
            Console.WriteLine("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);

            Console.WriteLine(jogo);
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Jogos a seu dispor!!!");
			
			Console.WriteLine("1 - Listar Jogos");
			Console.WriteLine("2 - Inserir novo jogo");
			Console.WriteLine("3 - Atualizar jogo");
			Console.WriteLine("4 - Exluir jogo");
			Console.WriteLine("5 - Visualizar jogo");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");

			Console.Write("\nInforme a opção desejada: ");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

    }
}
