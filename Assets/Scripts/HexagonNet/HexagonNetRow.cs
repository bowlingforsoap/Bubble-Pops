using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonNetRow
{
    public bool Shifted { get; protected set; }
    public IHexagonNetNode[] Nodes;

    public HexagonNetRow(params IHexagonNetNode[] nodes)
    {
        Nodes = nodes;
    }
}
