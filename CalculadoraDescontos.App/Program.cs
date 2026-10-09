using CalculadoraDescontos.App;

var service = new DescontoService();

Console.WriteLine($"Categoria (7 compras): {service.ObterCategoriaCliente(7)}");
Console.WriteLine($"Valor final (100 com 10%): {service.CalcularDescontoPorPercentual(100, 10)}");
Console.WriteLine($"Cupom valido (17 anos, nao primeira compra): {service.EValidoParaCupom(17, false)}");
