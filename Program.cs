using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoDoUsuario();

            while (opcaoUsuario != "7")
            {
                switch(opcaoUsuario){
                
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "7":
                        break;
                    default:
                        Console.WriteLine();                        
                        Console.WriteLine("Valor de entrada incorreto, por favor, digite um valor válido!");
                        break;
                }
                opcaoUsuario = obterOpcaoDoUsuario();
            }
        }

        private static string obterOpcaoDoUsuario()
        {
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;

        }

        private static void ListarSeries(){
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Desculpe, a lista de série está vazia!");
            }
            else
            {
                foreach(var serie in lista){
                    Console.WriteLine(
                        "{0}: - {1} {2}", 
                        serie.retornaId(), 
                        serie.retornaTitulo(), 
                        serie.retornaExcluido()? "*Excluido*" : "");
                }
            }
            Console.WriteLine();

        }

        private static Serie gerenciarEntrada(int id){
            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
            }
            Console.WriteLine("Digite o número conforme o respectivo gênero da série a ser inserida!");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título:");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite o ano:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descriçao");
            string entradaDescricao = Console.ReadLine();

                Serie addSerie = new Serie(
                id: id,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

                return addSerie;
        }
        private static void InserirSerie(){
            Console.WriteLine("Inserir nova série:");
            
            Serie novaSerie = gerenciarEntrada(repositorio.ProximoId());
            
            repositorio.Insere(novaSerie);

            Console.WriteLine();

        }

        private static void AtualizarSerie(){
            Console.WriteLine("Segue a lista de séries disponíves:");
            ListarSeries();
            Console.WriteLine("Por favor, digite o número da série que deseja atualizar!");
            int numSerie = int.Parse(Console.ReadLine()); 
            repositorio.Atualiza( numSerie,gerenciarEntrada(numSerie));
            Console.WriteLine();
        }

        private static void ExcluirSerie(){
            Console.WriteLine("Digite o número da serie que será excluída, conforme lista a seguir: ");
            ListarSeries();
            int numSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(numSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Digite o número da série que gostaria de ver as informações, conforme a lista a seguir");
            ListarSeries();
            int numSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(numSerie);
            Console.WriteLine(serie);
        }


    }
}
