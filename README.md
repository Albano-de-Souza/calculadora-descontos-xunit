# calculadora-descontos-xunit

Solução .NET 10 com testes parametrizados em xUnit para uma calculadora de descontos. Atividade da disciplina Gestão e Qualidade de Software.

## Estrutura

- `CalculadoraDescontos.App`: código de produção (classe `DescontoService`)
- `CalculadoraDescontos.Tests`: testes unitários (classe `DescontoServiceTests`)

## Diferença entre [Fact] e [Theory]

| Atributo | O que é | Quando usar |
|---|---|---|
| `[Fact]` | Teste único, sem parâmetros. Executa uma vez e verifica um cenário fixo. | Quando existe um só cenário a validar. |
| `[Theory]` | Teste parametrizado. O método recebe parâmetros e executa uma vez para cada `[InlineData]`. | Quando a mesma lógica precisa ser validada com vários conjuntos de dados. |

Com `[Fact]`, cada cenário exige um método de teste próprio, o que duplica código. Com `[Theory]`, um único método cobre todos os cenários, e cada `[InlineData]` aparece no resultado como um teste individual. Neste projeto, 3 métodos de teste geram 9 execuções.

## Métodos

| Método | Retorno | Regra |
|---|---|---|
| `ObterCategoriaCliente(int totalCompras)` | `string` | `"BRONZE"` para menos de 5 compras, `"PRATA"` de 5 a 10 (inclusive), `"OURO"` para mais de 10 |
| `CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)` | `int` | Valor final com o desconto aplicado. Ex.: `100` com `10` retorna `90` |
| `EValidoParaCupom(int idade, bool primeiraCompra)` | `bool` | `true` se o cliente tiver 18 anos ou mais ou se for a primeira compra |

## Cenários testados

| Teste | Dados de entrada | Resultado esperado |
|---|---|---|
| `ObterCategoriaCliente` | `2` | `"BRONZE"` |
| `ObterCategoriaCliente` | `7` | `"PRATA"` |
| `ObterCategoriaCliente` | `15` | `"OURO"` |
| `CalcularDescontoPorPercentual` | `100`, `10` | `90` |
| `CalcularDescontoPorPercentual` | `200`, `20` | `160` |
| `CalcularDescontoPorPercentual` | `50`, `0` | `50` |
| `EValidoParaCupom` | `20`, `false` | `true` |
| `EValidoParaCupom` | `16`, `true` | `true` |
| `EValidoParaCupom` | `17`, `false` | `false` |

## Como executar

Requisito: .NET 10 SDK.

```bash
git clone https://github.com/Albano-de-Souza/calculadora-descontos-xunit.git
cd calculadora-descontos-xunit
dotnet test
```

## Licença

MIT
