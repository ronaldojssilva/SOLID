using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle.ComViolacao;

internal class Rectangle
{
    int width, height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    internal void SetDimensions(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    internal int GetArea()
    {
        return width * height;
    }
}

class Square : Rectangle
{
    public Square(int side) : base(side, side)
    {
    }

    // Violação do Princípio de Substituição de Liskov (LSP)
    internal void SetDimensions(int width, int height)
    {
        if (width != height)
        {
            throw new ArgumentException("Para um quadrado, a largura e a altura devem ser iguais.");
        }
        base.SetDimensions(width, height);
    }
}
