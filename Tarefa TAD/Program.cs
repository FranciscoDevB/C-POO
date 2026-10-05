using System;

namespace Tarefa_TAD
{
    class Program
    {
        static void Main(string[] Args)
        {
            Cadastro MeuCadastro = new Cadastro();

            // Nome da pasta instalada.
            string caminhoArquivo = "products-100.csv"; 

            MeuCadastro.LêArquivo(caminhoArquivo);

            int opcao = -1;
            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("================ CADASTRO DE PRODUTOS ================");
                Console.WriteLine("1. Mostrar Todos os Produtos");
                Console.WriteLine("2. Pesquisar Produto por Nome ou Categoria");
                Console.WriteLine("3. Inserir Novo Produto Manualmente");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao)) continue;

                switch (opcao)
                {
                    case 1:
                        MeuCadastro.MostrarCadastro();
                        break;
                    case 2:
                        Console.Write("\nDigite o nome ou categoria para buscar: ");
                        string termo = Console.ReadLine();
                        MeuCadastro.PesquisarPorNome(termo);
                        break;
                    case 3:
                        InserirNovoProduto(MeuCadastro);
                        break;
                    case 0:
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                }
            }
        }

        static void InserirNovoProduto(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("--- INCLUSÃO DE NOVO PRODUTO ---\n");

            Produto p = new Produto();
            p.Index = cadastro.Quantidade + 1;

            Console.Write("Título do Produto: ");
            p.Titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            p.Descricao = Console.ReadLine();

            Console.Write("Categoria: ");
            p.Categoria = Console.ReadLine();

            Console.Write("Preço (ex: 49.90): ");
            double.TryParse(Console.ReadLine(), out double preco);
            p.Preco = preco;

            cadastro.Inserir(p);

            Console.WriteLine("\nProduto cadastrado com sucesso!");
            Console.ReadKey();
        }
    }
}
