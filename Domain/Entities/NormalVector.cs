using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class NormalVector
{
    #region Ctors
    public NormalVector() { }

    public NormalVector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    #endregion

    #region Props
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);
    #endregion

    public override string ToString()
    {
        return $"({X:0.##}, {Y:0.##}, {Z:0.##})";
    }

    public NormalVector Normalize()
    {
        var length = Length;
        if (length == 0) throw new InvalidOperationException("Cannot normalize zero vector.");
        return new NormalVector(X / length, Y / length, Z / length);
    }
}