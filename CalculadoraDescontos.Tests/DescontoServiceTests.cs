using CalculadoraDescontos.App;

namespace CalculadoraDescontos.Tests;

public class DescontoServiceTests
{
    private readonly DescontoService _service = new DescontoService();

    [Theory]
    [InlineData(2, "BRONZE")]
    [InlineData(7, "PRATA")]
    [InlineData(15, "OURO")]
    public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string esperado)
    {
        var resultado = _service.ObterCategoriaCliente(totalCompras);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(100, 10, 90)]
    [InlineData(200, 20, 160)]
    [InlineData(50, 0, 50)]
    public void CalcularDescontoPorPercentual_DeveRetornarValorComDesconto(int valorOriginal, int percentualDesconto, int esperado)
    {
        var resultado = _service.CalcularDescontoPorPercentual(valorOriginal, percentualDesconto);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(20, false, true)]
    [InlineData(16, true, true)]
    [InlineData(17, false, false)]
    public void EValidoParaCupom_DeveValidarElegibilidade(int idade, bool primeiraCompra, bool esperado)
    {
        var resultado = _service.EValidoParaCupom(idade, primeiraCompra);

        Assert.Equal(esperado, resultado);
    }
}
