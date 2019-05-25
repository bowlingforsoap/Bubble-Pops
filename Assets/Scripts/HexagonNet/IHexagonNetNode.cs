using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HexagonNetEnums;

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
    void SetNeighbour(IHexagonNetNode<T> neighbourNode, Neighbours neighbour);

    /// <summary>
    /// Convenience method to get a neighbour from Neighbours array based on relation.
    /// </summary>
    /// <param name="neighbour"></param>
    /// <returns></returns>
    IHexagonNetNode<T> GetNeighbour(Neighbours neighbour);
}
