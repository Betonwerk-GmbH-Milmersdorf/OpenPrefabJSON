using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ElementType
{
    protected ElementType() { }

    public ElementType(string main, string subtype)
    {
        Main = main;
        Subtype = subtype;
    }

    public string Main { get; protected set; }
    public string Subtype { get; protected set; }    
}