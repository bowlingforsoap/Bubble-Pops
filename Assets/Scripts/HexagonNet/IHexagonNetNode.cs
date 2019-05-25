using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHexagonNetNode<T>
{
    T Value { get; set; }
    Vector2Int? Position { get; set; }
    IHexagonNetNode<T>[] Neighbours { get; }
    object HexagonNet { get; }
    /// <summary>
    /// Convenience method to set the neighbours.
    /// </summary>
    /// <param name="neighbourNode"></param>
    /// <param name="neighbour"></param>
    void SetNeighbour(IHexagonNetNode<T> neighbourNode, HexagonNetEnums.Neighbours neighbour);
}
