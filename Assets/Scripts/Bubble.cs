﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : IHexagonNetNode
{
    public Vector2Int? Position
    {
        get;
        set;
    }

    public IHexagonNetNode[] Neighbours { get; } = new IHexagonNetNode[6];

    public object HexagonNet { get; set; }
    public int Exponent { get; set; }
    public int Value
    {
        get => (int)Mathf.Pow(2, Exponent);
    }

    public override string ToString()
    {
        return Exponent.ToString();
    }

    /// <summary>
    /// Convenience method for setting the exponent when initializing bubbles.
    /// </summary>
    /// <param name="exponent"></param>
    /// <returns></returns>
    public Bubble SetExponent(int exponent)
    {
        Exponent = exponent;
        return this;
    }

    /// <summary>
    /// Convenience method for setting the HexagonNet when initializing bubbles.
    /// </summary>
    /// <param name="exponent"></param>
    /// <returns></returns>
    public Bubble SetHexagonNet(object hexagonNet)
    {
        HexagonNet = hexagonNet;
        return this;
    }
}
