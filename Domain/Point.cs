using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }

    internal System.Drawing.Point ToSystemDrawingPoint()
    {
        return new System.Drawing.Point(X, Y);
    }
}
