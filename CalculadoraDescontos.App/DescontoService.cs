namespace CalculadoraDescontos.App;

/// <summary>
/// Regras de desconto: categoria do cliente, desconto percentual e
/// elegibilidade a cupom.
/// </summary>
public class DescontoService
{
    private const int IdadeMinimaCupom = 18;

    /// <summary>
    /// "BRONZE" para menos de 5 compras, "PRATA" para 5 a 10 (inclusive)
    /// e "OURO" para mais de 10 compras.
    /// </summary>
    public string ObterCategoriaCliente(int totalCompras)
    {
        if (totalCompras < 5)
        {
            return "BRONZE";
        }

        if (totalCompras <= 10)
        {
            return "PRATA";
        }

        return "OURO";
    }

    /// <summary>
    /// Retorna o valor final com o desconto aplicado.
    /// Ex.: (100, 10) => 90.
    /// </summary>
    public int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
    {
        return valorOriginal - (valorOriginal * percentualDesconto / 100);
    }

    /// <summary>
    /// Válido se o cliente tiver 18 anos ou mais OU se for a primeira compra.
    /// </summary>
    public bool EValidoParaCupom(int idade, bool primeiraCompra)
    {
        return idade >= IdadeMinimaCupom || primeiraCompra;
    }
}
