using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To be Bubble- or BubbleNode pool. 
/// </summary>
public class BubblePool
{
    private static BubblePool instance;
    public static BubblePool Instance
    {
        get => instance == null ? new BubblePool() : instance;
        private set => instance = value;
    }

    private BubblePool()
    {
        Instance = this;
    }

    public Bubble Get(int exponent)
    {
        // TODO: get from pool
        return new Bubble(exponent);
    }

    public void ReturnToPool(Bubble bubble)
    {
        // TODO: return to pool
    }
}
