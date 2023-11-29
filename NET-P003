using System;
using System.Collections.Generic;
using System.Linq;

public class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string mensagem) : base(mensagem)
    {
    }
}

public class CodigoProdutoInvalidoException : Exception
{
    public CodigoProdutoInvalidoException(string mensagem) : base(mensagem)
    {
    }
}

class Program
{
    static void Main()
    {
        Estoque estoque = new Estoque();
        int opcao;

        do
        {
            Console.WriteLine("1 - Cadastrar um produto");
            Console.WriteLine("2 - Consultar um produto");
            Console.WriteLine("3 - Atualizar o estoque");
            Console.WriteLine("4 - Relatórios");
            Console.WriteLine("5 - Sair");
            
            opcao = int.Parse(Console.ReadLine());
            
            if(opcao == 1){
                
                AdicionarNovoProduto(estoque);
                
            }else if(opcao == 2){
                
                ConsultarProduto(estoque);
                
            }else if(opcao == 3){
                
                AtualizarEstoque(estoque);
                
            }else if(opcao == 4){
                
                GerarRelatorios(estoque);
                
            }else if(opcao == 5){
                
                Console.WriteLine("Programa Encerrado!");
            }

        } while (opcao != 5);
    }

    static void AdicionarNovoProduto(Estoque estoque)
    {
        try
        {
            Console.WriteLine("\nAdicionar Novo Produto:");

            Console.Write("Código do Produto: ");
            int codigo = LerCodigoProduto();

            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade em Estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço Unitário: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            estoque.CadastrarProduto(codigo, nome, quantidade, preco);
        }
        catch (CodigoProdutoInvalidoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }

    static void ConsultarProduto(Estoque estoque)
    {
        try
        {
            Console.Write("\nDigite o código do produto a ser consultado: ");
            int codigoConsulta = LerCodigoProduto();

            var produtoConsultado = estoque.ConsultarProduto(codigoConsulta);
            var precoUnitario = produtoConsultado.Item4;
            var valorTotalEstoque = produtoConsultado.Item3 * precoUnitario;

            Console.WriteLine($"\nProduto Consultado:");
            Console.WriteLine($"Código: {produtoConsultado.Item1}");
            Console.WriteLine($"Nome: {produtoConsultado.Item2}");
            Console.WriteLine($"Preço Unitário: {precoUnitario:C2}");
            Console.WriteLine($"Quantidade em Estoque: {produtoConsultado.Item3}");
            Console.WriteLine($"Valor Total do Estoque: {valorTotalEstoque:C2}");
        }
        catch (CodigoProdutoInvalidoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }

    static int LerCodigoProduto()
    {
        if (int.TryParse(Console.ReadLine(), out int codigo))
        {
            return codigo;
        }
        else
        {
            throw new CodigoProdutoInvalidoException("Código do produto inválido. Insira um valor numérico válido.");
        }
    }
    static void AtualizarEstoque(Estoque estoque)
    {
        Console.Write("\nDigite o código do produto para atualizar o estoque: ");
        int codigoAtualizacao = int.Parse(Console.ReadLine());

        Console.Write("Digite a quantidade a ser adicionada ou removida: ");
        int quantidadeAtualizacao = int.Parse(Console.ReadLine());

        Console.Write("Deseja adicionar (A) ou remover (R) a quantidade informada? ");
        char operacao = char.ToUpper(Console.ReadLine()[0]);

        try
        {
            estoque.AtualizarEstoque(codigoAtualizacao, quantidadeAtualizacao, operacao == 'A');
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void GerarRelatorios(Estoque estoque)
    {
        Console.WriteLine("\nRelatórios Gerados:");

        Console.Write("1 - Lista de produtos com quantidade em estoque abaixo de um limite: ");
        int limiteQuantidade = int.Parse(Console.ReadLine());
        var relatorio1 = estoque.ListarProdutosAbaixoLimite(limiteQuantidade);
        Console.WriteLine($"\nProdutos com quantidade abaixo de {limiteQuantidade}:");
        foreach (var produto in relatorio1)
        {
            Console.WriteLine($"Código: {produto.Item1}, Nome: {produto.Item2}, Quantidade: {produto.Item3}");
        }

        Console.Write("\n2 - Lista de produtos com valor entre um mínimo e um máximo: ");
        Console.Write("\nDigite o valor mínimo: ");
        decimal minimo = decimal.Parse(Console.ReadLine());
        Console.Write("Digite o valor máximo: ");
        decimal maximo = decimal.Parse(Console.ReadLine());
        var relatorio2 = estoque.ListarProdutosEntreValores(minimo, maximo);
        Console.WriteLine($"\nProdutos com valor entre {minimo} e {maximo}:");
        foreach (var produto in relatorio2)
        {
            Console.WriteLine($"Código: {produto.Item1}, Nome: {produto.Item2}, Valor: {produto.Item3}");
        }

        var relatorio3 = estoque.CalcularValoresTotais();
        Console.WriteLine($"\n3 - Valor total do estoque: {relatorio3.Item1}");
        Console.WriteLine("Valor total de cada produto de acordo com seu estoque:");
        foreach (var produto in relatorio3.Item2)
        {
            Console.WriteLine($"Código: {produto.Item1}, Nome: {produto.Item2}, Valor Total: {produto.Item3}");
        }
    }
}

class Estoque
{
    private List<(int, string, int, decimal)> produtos = new List<(int, string, int, decimal)>();

    public void CadastrarProduto(int codigo, string nome, int quantidade, decimal preco)
    {
        produtos.Add((codigo, nome, quantidade, preco));
        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    public (int, string, int, decimal) ConsultarProduto(int codigo)
    {
        var produto = produtos.FirstOrDefault(p => p.Item1 == codigo);

        if (produto.Equals((0, null, 0, 0m)))
            throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");

        return produto;
    }

    public void AtualizarEstoque(int codigo, int quantidade, bool adicionar)
    {
        var produto = produtos.FirstOrDefault(p => p.Item1 == codigo);

        if (produto.Equals((0, null, 0, 0m)))
            throw new Exception("Produto não encontrado.");

        int novoEstoque = adicionar ? produto.Item3 + quantidade : produto.Item3 - quantidade;

        if (novoEstoque >= 0)
        {
            produtos.Remove(produto);
            produtos.Add((codigo, produto.Item2, novoEstoque, produto.Item4));
            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        else
        {
            throw new Exception("Quantidade indisponível em estoque.");
        }
    }

    public List<(int, string, int)> ListarProdutosAbaixoLimite(int limite)
    {
        return produtos.Where(p => p.Item3 < limite).Select(p => (p.Item1, p.Item2, p.Item3)).ToList();
    }

    public List<(int, string, decimal)> ListarProdutosEntreValores(decimal minimo, decimal maximo)
    {
        return produtos.Where(p => p.Item4 >= minimo && p.Item4 <= maximo)
                       .Select(p => (p.Item1, p.Item2, p.Item4))
                       .ToList();
    }

    public (decimal, List<(int, string, decimal)>) CalcularValoresTotais()
    {
        decimal valorTotalEstoque = 0;
        List<(int, string, decimal)> valoresTotaisPorProduto = new List<(int, string, decimal)>();

        foreach (var produto in produtos)
        {
            decimal valorTotalProduto = produto.Item3 * produto.Item4;
            valorTotalEstoque += valorTotalProduto;
            valoresTotaisPorProduto.Add((produto.Item1, produto.Item2, valorTotalProduto));
        }

        return (valorTotalEstoque, valoresTotaisPorProduto);
    }
}
