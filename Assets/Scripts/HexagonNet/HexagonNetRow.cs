using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Represents one row in HexagonNet.
/// </summary>
/// <typeparam name="T"></typeparam>
public class HexagonNetRow<T> : IEnumerable<IHexagonNetNode<T>> where T : class
{
    public bool Shifted { get; set; }
    public IHexagonNetNode<T>[] Nodes { get; private set; } = new IHexagonNetNode<T>[6];
    public int Index { get; set; }

    public HexagonNetRow(bool shifted, IHexagonNetNode<T>[] nodes)
    {
        Shifted = shifted;

        for (int i = 0; i < 6; i++)
        {
           Nodes[i] = nodes[i];
        }
    }

    public HexagonNetRow(IHexagonNetNode<T>[] nodes) : this(false, nodes) { }

    public IEnumerator<IHexagonNetNode<T>> GetEnumerator()
    {
        foreach (var node in Nodes)
        {
            yield return node;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
