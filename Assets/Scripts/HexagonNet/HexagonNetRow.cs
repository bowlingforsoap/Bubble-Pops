using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Represents one row in HexagonNet.
/// </summary>
/// <typeparam name="T"></typeparam>
public class HexagonNetRow<T> : IEnumerable<T> where T : class, IHexagonNetNode
{
    public bool Shifted { get; set; }
    public T[] Nodes { get; private set; } = new T[6];
    public int Index { get; set; }

    public HexagonNetRow(bool shifted, T[] nodes)
    {
        Shifted = shifted;

        for (int i = 0; i < 6; i++)
        {
           Nodes[i] = nodes[i];
        }
    }

    public HexagonNetRow(T[] nodes) : this(false, nodes) { }

    /// <summary>
    /// Used to set the position of each node, when the row is fully setup (has an Index).
    /// </summary>
    public void PositionNodesWithinNet()
    {
        for (int i = 0; i < 6; i++)
        {
            Nodes[i].Position = new Vector2Int(Index, i);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)Nodes).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
