using System;
using System.Globalization;
using System.IO;

namespace Tarefa_TAD
{
    class Cadastro
    {
        private Produto[] cadProdutos;
        private int tamanho;

        public Cadastro(int capacidadeInicial = 100)
        {
            cadProdutos = new Produto[capacidadeInicial];
            tamanho = 0;
        }

        public int Quantidade => tamanho;

        private void RedimensionarSeNecessario()
        {
            if (tamanho == cadProdutos.Length)
            {
                Produto[] novoVetor = new Produto[cadProdutos.Length * 2];
                Array.Copy(cadProdutos, novoVetor, cadProdutos.Length);
                cadProdutos = novoVetor;
            }
        }

        public void Inserir(Produto x)
        {
            RedimensionarSeNecessario();
            cadProdutos[tamanho] = x;
            tamanho++;
        }

        public void LêArquivo(string NomeArquivo)
        {
            if (File.Exists(NomeArquivo))
            {
                using (Stream Entrada = File.Open(NomeArquivo, FileMode.Open))
                using (StreamReader Leitor = new StreamReader(Entrada))
                {
                    string Linha = Leitor.ReadLine();

                    Console.WriteLine("\nAguarde... Lendo o Arquivo de Produtos...");

                    Linha = Leitor.ReadLine();

                    while (Linha != null)
                    {
                        if (!string.IsNullOrWhiteSpace(Linha))
                        {
                            string[] LinhaProduto = Linha.Split(',');
                            if (LinhaProduto.Length >= 5)
                            {
                                Produto P = CriaProduto(LinhaProduto);
                                Inserir(P);
                            }
                        }
                        Linha = Leitor.ReadLine();
                    }
                }
                Console.WriteLine($"Sucesso! {tamanho} produtos carregados.");
            }
            else
            {
                Console.WriteLine($"\nERRO: Arquivo '{NomeArquivo}' não existe!!");
            }
        }

        private Produto CriaProduto(string[] LinhaProduto)
        {
            Produto P = new Produto();

            P.Index = int.TryParse(LinhaProduto[0], out int idx) ? idx : 0;
            P.Titulo = LinhaProduto[1].Trim('"');
            P.Descricao= LinhaProduto[2].Trim('"');
            P.Categoria = LinhaProduto[3].Trim('"');
            
            double.TryParse(LinhaProduto[4], NumberStyles.Any, CultureInfo.InvariantCulture, out double preco);
            P.Preco = preco;

            return P;
        }

        public void MostrarCadastro()
        {
            Console.Clear();
            Console.WriteLine($"--- PRODUTOS CADASTRADOS ({tamanho}) ---\n");

            for (int i = 0; i < tamanho; i++)
            {
                Console.WriteLine(cadProdutos[i].ToString());
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void PesquisarPorNome(string termo)
        {
            Console.Clear();
            Console.WriteLine($"--- BUSCA POR PRODUTO: '{termo}' ---\n");
            bool encontrado = false;

            for (int i = 0; i < tamanho; i++)
            {
                Produto P = cadProdutos[i];

                if (P.Titulo.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    P.Categoria.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(P.ToString());
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Nenhum produto encontrado com esse nome ou categoria.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}