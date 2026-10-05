namespace Tarefa_TAD
{
    class Produto
    {
        public int Index { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }

        public override string ToString()
        {
            return $"[{Index}] {Titulo} | Categoria: {Categoria} | Preço: R$ {Preco:F2}";
        }
    }
}