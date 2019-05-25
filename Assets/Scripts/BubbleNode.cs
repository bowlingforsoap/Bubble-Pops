using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleNode : IHexagonNetNode<Bubble>
{
    public Vector2Int? Position
    {
        get;
        set;
    }

    public IHexagonNetNode<Bubble>[] Neighbours { get; } = new IHexagonNetNode<Bubble>[6];

    public object HexagonNet { get; set; }
    public Bubble Value
    {
        get;
        set;
    }

    /// <summary>
    /// Creates a BubbleNode for the given Bubble.
    /// </summary>
    /// <param name="b"></param>
    public BubbleNode(Bubble b)
    {
        Value = b;
    }

    /// <summary>
    /// Creates a BubbleNode for a Bubble that is requested from BubblePool with the given exponent.
    /// </summary>
    /// <param name="exponent"></param>
    public BubbleNode(int exponent)
    {
        Value = BubblePool.Instance.Get(exponent);
    }

    /// <summary>
    /// Convenience method for setting the HexagonNet when initializing bubbles.
    /// </summary>
    /// <param name="exponent"></param>
    /// <returns></returns>
    public BubbleNode SetHexagonNet(object hexagonNet)
    {
        HexagonNet = hexagonNet;
        return this;
    }

    /// <summary>
    /// Sets the specified neigbour as the neighbourNode, and tries to update the corresponding OppositeNeighbourNode to this.
    /// </summary>
    /// <param name="neighbourNode"></param>
    /// <param name="neighbour"></param>
    public void SetNeighbour(IHexagonNetNode<Bubble> neighbourNode, HexagonNetEnums.Neighbours neighbour)
    {
        Neighbours[(int)neighbour] = neighbourNode;
        if (neighbourNode != null)
        {
            neighbourNode.Neighbours[(int)HexagonNetEnums.GetOppositeNeighbourNode(neighbour)] = this;
        }
    }
}
