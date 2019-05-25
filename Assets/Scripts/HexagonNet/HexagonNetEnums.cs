using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class HexagonNetEnums
{
    public enum Neighbours
    {
        UpperLeft,
        UpperRight,
        Left,
        Right,
        LowerLeft,
        LowerRight
    }

    public enum OppositeNeighbours
    {
        LowerRight,
        LowerLeft,
        Right,
        Left,
        UpperRight,
        UpperLeft
    }

    public static OppositeNeighbours GetOppositeNeighbourNode(Neighbours node)
    {
        OppositeNeighbours opposite = (OppositeNeighbours)node;
        return opposite;
    }
    public static Neighbours GetOppositeNeighbourNode(OppositeNeighbours node)
    {
        Neighbours opposite = (Neighbours)node;
        return opposite;
    }

    public static Neighbours GetNeighbourWithSameNameAsOpposite(OppositeNeighbours oppositeNeighbour)
    {
        Neighbours neighbour;
        Enum.TryParse(oppositeNeighbour.ToString(), out neighbour);
        return neighbour;
    }
}



