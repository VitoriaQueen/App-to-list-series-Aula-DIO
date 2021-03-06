using System;


namespace DIO.Series
{
    class Program
    {   
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
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
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            
            }
            
            Console.WriteLine("Obrigada por utilizar nossos servicos.!");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            repositorio.Exclui(indiceSerie);
        }
        
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            
            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.Write("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie,atualizaSerie);  
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
       
       private static void InserirSerie()
       {
           Console.WriteLine("Inserir nova serie");
           foreach (int i in Enum.GetValues(typeof(Genero)))
           {
               Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
           }
           Console.WriteLine("Digite o genero entre as opcoes acima: ");
           int entradaGenero = int.Parse(Console.ReadLine());
           
           Console.WriteLine("Digite o titulo da serie: ");
           string entradaTitulo = Console.ReadLine();
           
           Console.WriteLine("Digite o ano de inicio da serie: ");
           int entradaAno = int.Parse(Console.ReadLine());
           
           Console.WriteLine("Digite a descricao da serie: ");
           string entradaDescricao = Console.ReadLine();

           Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);
            repositorio.Insere(novaSerie);                         

      
       }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" Dio Series ao seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            
            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario; 
        }
    
    }
}
