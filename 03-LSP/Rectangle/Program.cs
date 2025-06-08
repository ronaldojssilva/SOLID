// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Função que espera um Rectangle
void ResizeRectangle(Rectangle.ComViolacao.Rectangle rectangle)
{
    rectangle.SetDimensions(4, 5);
    Console.WriteLine($"Área do retângulo: {rectangle.GetArea()}");
}

var rectangle = new Rectangle.ComViolacao.Rectangle(2, 3);
var square = new Rectangle.ComViolacao.Square(4);

// Funciona para Rectangle
ResizeRectangle(rectangle); // Área ajustada: 20

// Falha para Rectangle.(Quebra do LSP)
ResizeRectangle(square); // Lança ArgumentException: "Para um quadrado, a largura e a altura devem ser iguais."