using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class HexagonNetEnums
{
    public enum NeighbourNode
    {
        UpperLeft,
        UpperRight,
        Left,
        Right,
        LowerLeft,
        LowerRight
    }

    public enum OppositeNeighbourNode
    {
        LowerRight,
        LowerLeft,
        Right,
        Left,
        UpperRight,
        UpperLeft
    }

    public static OppositeNeighbourNode GetOppositeNeighbourNode(NeighbourNode node)
    {
        OppositeNeighbourNode opposite = (OppositeNeighbourNode)(int)node;
        return opposite;
    }
    public static NeighbourNode GetOppositeNeighbourNode(OppositeNeighbourNode node)
    {
        NeighbourNode opposite = (NeighbourNode)(int)node;
        return opposite;
    }
}



