using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)Nodes).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
