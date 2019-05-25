using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bubble
{
    public int Exponent { get; set; }
    public int Value
    {
        get => (int)Mathf.Pow(2, Exponent);
    }

    public override string ToString()
    {
        return Exponent.ToString();
    }

    public Bubble(int exponent)
    {
        Exponent = exponent;
    }

    internal void MergeWith(int v)
    {
        for (int i = 0; i < v; i++)
        {
            Exponent++;
        }
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
}
