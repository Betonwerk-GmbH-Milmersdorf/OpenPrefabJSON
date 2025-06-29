using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Edge(string id, string start, string end)
{
    public string ID { get; set; } = id;
    public string Start { get; set; } = start;
    public string End { get; set; } = end;
}
