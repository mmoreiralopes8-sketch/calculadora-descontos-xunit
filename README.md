# CalculadoraDescontos

Solução .NET 10 com regras de desconto (categoria do cliente, desconto percentual e elegibilidade a cupom), testadas com **testes parametrizados** do xUnit (`[Theory]` + `[InlineData]`).

Atividade da disciplina **Garantia da Qualidade de Software** (Lista 23).

## Estrutura

```
CalculadoraDescontos.slnx
├── CalculadoraDescontos.App/      # código de produção (DescontoService)
└── CalculadoraDescontos.Tests/    # testes parametrizados (DescontoServiceTests)
```

## Métodos criados (`DescontoService`)

| Método | Retorno | Regra |
|--------|---------|-------|
| `ObterCategoriaCliente(int totalCompras)` | `string` | `"BRONZE"` (< 5), `"PRATA"` (5 a 10 inclusive), `"OURO"` (> 10) |
| `CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)` | `int` | Valor final com desconto. `(100, 10)` → `90` |
| `EValidoParaCupom(int idade, bool primeiraCompra)` | `bool` | `true` se idade ≥ 18 **ou** primeira compra |

## [Fact] vs [Theory]

- `[Fact]`: teste único, sem parâmetros.
- `[Theory]`: teste parametrizado, executado uma vez para cada `[InlineData]`. Em vez de duplicar métodos de teste, cada cenário é uma linha de dados.

## Cobertura dos testes (`DescontoServiceTests`)

| Teste | Cenários (`InlineData`) |
|-------|-------------------------|
| `ObterCategoriaCliente_DeveRetornarCategoriaEsperada` | `(2, "BRONZE")`, `(7, "PRATA")`, `(15, "OURO")` |
| `CalcularDescontoPorPercentual_DeveRetornarValorFinal` | `(100, 10, 90)`, `(200, 20, 160)`, `(50, 0, 50)` |
| `EValidoParaCupom_DeveValidarElegibilidade` | `(20, false, true)`, `(16, true, true)`, `(17, false, false)` |

Total: 3 métodos `[Theory]` que geram 9 execuções de teste.

## Como executar

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/mmoreiralopes8-sketch/calculadora-descontos-xunit.git
cd calculadora-descontos-xunit
dotnet test
```

Cada `[InlineData]` aparece como um teste individual na saída do `dotnet test`.

## Licença

Distribuído sob a licença MIT. Veja o arquivo [LICENSE](LICENSE).
