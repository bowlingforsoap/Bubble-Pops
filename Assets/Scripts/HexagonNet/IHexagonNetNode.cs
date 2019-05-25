using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHexagonNetNode
{
    Vector2Int? Position { get; set; }
    IHexagonNetNode[] Neighbours { get; }
    object HexagonNet { get; }
    /// <summary>
    /// Convenience method to set the neighbours.
    /// </summary>
    /// <param name="neighbourNode"></param>
    /// <param name="neighbour"></param>
    void SetNeighbour(IHexagonNetNode neighbourNode, HexagonNetEnums.Neighbours neighbour);
}
