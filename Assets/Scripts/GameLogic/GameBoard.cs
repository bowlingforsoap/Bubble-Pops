using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HexagonNetEnums;

public class GameBoard
{
    protected HexagonNet<Bubble> net;

    public HexagonNet<Bubble> Net
    {
        get => net;
        set
        {
            if (net == null)
            {
                net = value;

                if (BubblesAddedEvent != null)
                {
                    BubbleEventArgs bubbleEventArgs = new BubbleEventArgs().SetBubbleNodes(net);
                    BubblesAddedEvent(this, bubbleEventArgs);
                }
            }
        }
    }

    public event EventHandler<BubbleEventArgs> BubblesAddedEvent;

    public GameBoard(HexagonNet<Bubble> net)
    {
        Net = net;
    }

    public GameBoard() { }

    /// <summary>
    /// Merges the bubbles with the same exponent into one.
    /// </summary>
    /// <param name="startBubble"></param>
    public void MergeBubbles(IHexagonNetNode<Bubble> startBubble)
    {
        var similarConnected = FindSimilarConnected(startBubble);

        var bubbleToMergeInto = FindBubbleToMergeInto(similarConnected);

        similarConnected.Remove(bubbleToMergeInto);
        bubbleToMergeInto.Value.MergeWith(similarConnected.Count);
        
        ReturnBubblesToPool(similarConnected.ToArray());
    }


    /// <summary>
    /// Rerturns the bubbles to the pool.
    /// </summary>
    /// <param name="bubble"></param>
    private void ReturnBubblesToPool(params IHexagonNetNode<Bubble>[] bubbleNodes)
    {
        foreach (var node in bubbleNodes)
        {
            BubblePool.Instance.ReturnToPool(node.Value);
            node.Value = null;
        }
    }

    private IHexagonNetNode<Bubble> FindBubbleToMergeInto(List<IHexagonNetNode<Bubble>> similarConnected)
    {
        Debug.Assert(similarConnected != null);
        Debug.Assert(similarConnected.Count > 0);

        // TODO: add more logics
        return similarConnected[0];
    }

    private List<IHexagonNetNode<Bubble>> FindSimilarConnected(IHexagonNetNode<Bubble> startBubble)
    {
        List<IHexagonNetNode<Bubble>> bubblesFound = new List<IHexagonNetNode<Bubble>>();
        bubblesFound.Add(startBubble);

        foreach(var neighbourNode in startBubble.Neighbours)
        {
            FindSimilarConnectedRecuresively(startBubble, ref bubblesFound, neighbourNode);
        }

        return bubblesFound;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="senderNode">The node, which calls this method</param>
    /// <param name="bubblesFound"></param>
    /// <param name="receiverNode"></param>
    private void FindSimilarConnectedRecuresively(IHexagonNetNode<Bubble> senderNode, ref List<IHexagonNetNode<Bubble>> bubblesFound, IHexagonNetNode<Bubble> receiverNode)
    {
        bool continueRecursion = true;

        if (receiverNode == null || receiverNode.Value == null) // Stop if the node is null, meaning we are at the edge of the net
        {
            continueRecursion = false;
        }

        if (bubblesFound.Contains(receiverNode)) // Stop if this node was already checked
        {
            continueRecursion = false;
        }         

        if (receiverNode != null && receiverNode.Value != null && receiverNode.Value.Exponent != senderNode.Value.Exponent)
        {
            continueRecursion = false; // Stop if the Bubble.Exponent of this node is not what we are looking for
        }


        if (continueRecursion)
        {
            bubblesFound.Add(receiverNode);
            foreach (var neighbourNode in receiverNode.Neighbours)
            {
                FindSimilarConnectedRecuresively(senderNode: receiverNode, ref bubblesFound, neighbourNode);
            }
        }
    }
}
