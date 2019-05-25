﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using static HexagonNetEnums;

/// <summary>
/// The data structure, which consists of rows of 6 hexagons each. Every odd row is shifted by one postion to the right:
/// * * * * * *    - row 0
///  * * * * * *   - row 1 (shifted by 1 to the right)
/// * * * * * *    - row 2 (not shifted)
///  * * * * * *   - row 3
///  ... and so on ...
/// </summary>
/// <typeparam name="T"></typeparam>
public class HexagonNet<T> : IEnumerable<IHexagonNetNode<T>> where T : class
{
    private SortedDictionary<int, HexagonNetRow<T>> net = new SortedDictionary<int, HexagonNetRow<T>>();
    public HexagonNetRow<T> TopRow { get; protected set; }
    public HexagonNetRow<T> BottomRow { get; protected set; }

    public HexagonNet()
    {

    }

    private void InitializeNet(HexagonNetRow<T> firstRow)
    {
        firstRow.Shifted = false;
        firstRow.Index = 0;
        SetCompleteRow(firstRow);
        TopRow = firstRow;
        BottomRow = firstRow;
    }

    /// <summary>
    /// Replaces the TopRow with the newTopRow.
    /// </summary>
    /// <param name="newTopRow"></param>
    public void AddTopRow(HexagonNetRow<T> newTopRow)
    {
        if (TopRow == null)
        {
            InitializeNet(newTopRow);
            return;
        }

        newTopRow.Shifted = !TopRow.Shifted;
        newTopRow.Index = TopRow.Index - 1;
        SetCompleteRow(newTopRow);
        TopRow = newTopRow;
    }

    /// <summary>
    /// Replaces the BottomRow with the newBottomRow.
    /// </summary>
    /// <param name="newBottomRow"></param>
    public void AddBottomRow(HexagonNetRow<T> newBottomRow)
    {
        if (BottomRow == null)
        {
            InitializeNet(newBottomRow);
            return;
        }

        newBottomRow.Shifted = !BottomRow.Shifted;
        newBottomRow.Index = BottomRow.Index + 1;
        SetCompleteRow(newBottomRow);
        BottomRow = newBottomRow;
    }

    public void RemoveTopRow()
    {

    }

    public void RemoveBottomRow()
    {

    }

    /// <summary>
    /// Retrieves the specified neighbour of this node.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="neighbour"></param>
    /// <returns>The neighbour or null, if no neighbour is found.</returns>
    public IHexagonNetNode<T> GetNeighbourFor(IHexagonNetNode<T> node, HexagonNetEnums.Neighbours neighbour)
    {
        if (node == null) throw new ArgumentException("Cannot find the neigbour for the node that is null!");
        if (node.Position == null) throw new ArgumentException("The node has to be positioned within the HexagonNet!");

        IHexagonNetNode<T> neighbourNode = null;

        try
        {
            var row = net[node.Position.Value.x];
            if (row.Shifted)
            {
                neighbourNode = GetNeighbourForShiftedRowNode(node, neighbour);
            }
            else
            {
                neighbourNode = GetNeighbourForNotShiftedRowNode(node, neighbour);
            }
        }
        catch (Exception ex)
        {
            Type exType = ex.GetType();
            if (exType == typeof(IndexOutOfRangeException) || exType == typeof(KeyNotFoundException))
            {
                // Means we are at the border or the row above/below is not yet added
                // Simply leave the neighbourNode == null;
            }
            else
            {
                throw;
            }
        }

        return neighbourNode;
    }

    private IHexagonNetNode<T> GetNeighbourForShiftedRowNode(IHexagonNetNode<T> node, HexagonNetEnums.Neighbours neighbour)
    {
        IHexagonNetNode<T> neighbourNode = null;

        var nodePosition = node.Position.Value;
        switch (neighbour)
        {
            case HexagonNetEnums.Neighbours.UpperLeft:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y];
                break;
            case HexagonNetEnums.Neighbours.UpperRight:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y + 1];
                break;
            case HexagonNetEnums.Neighbours.Left:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.Right:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y + 1];
                break;
            case HexagonNetEnums.Neighbours.LowerLeft:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y];
                break;
            case HexagonNetEnums.Neighbours.LowerRight:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y + 1];
                break;
        }

        return neighbourNode;
    }

    private IHexagonNetNode<T> GetNeighbourForNotShiftedRowNode(IHexagonNetNode<T> node, HexagonNetEnums.Neighbours neighbour)
    {
        IHexagonNetNode<T> neighbourNode = null;
        var nodePosition = node.Position.Value;

        switch (neighbour)
        {
            case HexagonNetEnums.Neighbours.UpperLeft:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.UpperRight:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y];
                break;
            case HexagonNetEnums.Neighbours.Left:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.Right:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y + 1];
                break;
            case HexagonNetEnums.Neighbours.LowerLeft:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.LowerRight:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y];
                break;
        }     

        return neighbourNode;
    }


/// <summary>
/// Set a completely setup row at its Index.
/// </summary>
/// <param name="row"></param>
private void SetCompleteRow(HexagonNetRow<T> row)
{
    row.PositionNodesWithinNet();

    foreach (var node in row)
    {
        UpdateNeighboursFor(node);
    }

    net.Add(row.Index, row);
}

/// <summary>
/// Binds the neighbouring nodes together withing and in-between the HexagonRows.
/// </summary>
/// <param name="node"></param>
private void UpdateNeighboursFor(IHexagonNetNode<T> node)
{
    UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.Left);
    UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.LowerLeft);
    UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.LowerRight);
    UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.Right);
    UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.UpperLeft);
    UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.UpperRight);
}

private void UpdateNeighbourFor(IHexagonNetNode<T> node, Neighbours neighbour)
{
        IHexagonNetNode<T> neighbourNode = null;
        GetNeighbourFor(node, neighbour);

    //if (node != null)
    //{
    //    node.SetNeighbour(neighbourNode, neighbour);
    //} else if (neighbourNode != null)
    //{
    //    // Find which neighbour from Neighbours is this node for the neighbourNode
    //    var oppositeNeighbour = GetOppositeNeighbourNode(neighbour);
    //    Neighbours neighbourForOppositeNode;
    //    Enum.TryParse(oppositeNeighbour.ToString(), out neighbourForOppositeNode);
       
    //    neighbourNode.SetNeighbour(node, neighbourForOppositeNode);
    //}
}

IEnumerator IEnumerable.GetEnumerator()
{
    return GetEnumerator();
}

public IEnumerator<IHexagonNetNode<T>> GetEnumerator()
{
    foreach (var row in net.Values)
    {
        foreach (var node in row)
        {
            yield return node;
        }
    }
}

public override string ToString()
{
    StringBuilder netAsString = new StringBuilder();

    int i = 0;
    foreach (var node in this)
    {
        netAsString.Append(" ");
        if (node == null)
        {
            netAsString.Append("null");
        }
        else
        {
            netAsString.Append(node);
        }

        i++;
        if (i == 6)
        {
            netAsString.Append(Environment.NewLine);
            i = 0;
        }
    }

    return netAsString.ToString();
}
}
