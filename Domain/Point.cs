using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
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

    public Point(Point point)
    {
        X = point.X;
        Y = point.Y;
    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Point)) 
            return false;
        var p = (Point)obj;

        return p.X == this.X && p.Y == this.Y;
    }

    public System.Drawing.Point ToSystemDrawingPoint()
    {
        return new System.Drawing.Point(X, Y);
    }
}
