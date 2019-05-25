using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        return new Bubble(exponent);
    }
}
