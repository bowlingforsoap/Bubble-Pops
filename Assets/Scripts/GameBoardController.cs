using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{

    /// <summary>
    /// Used to generate random exponents for the Bubbles.
    /// </summary>
    private System.Random bubbleExponentRandomizer = new System.Random();
    public GameBoard GameBoard { get; private set; } = new GameBoard();

    private void Start()
    {
        SetupInitialBoard();
    }

    private void SetupInitialBoard()
    {
        HexagonNet<Bubble> bubbleNet = new HexagonNet<Bubble>();
        var rows = GenerateNRowsOfRandomBubbles(4);
        var nullRow = GenerateNullRow();
        foreach (var row in rows)
        {
            bubbleNet.AddBottomRow(row);
        }
        bubbleNet.AddBottomRow(nullRow);

        GameBoard.Net = bubbleNet;
    }

    private HexagonNetRow<Bubble>[] GenerateNRowsOfRandomBubbles(int n)
    {
        HexagonNetRow<Bubble>[] rows = new HexagonNetRow<Bubble>[n];

        for (int i = 0; i < n; i++)
        {
            rows[i] = GenerateRowOfRandomBubbles();
        }

        return rows;
    }

    private HexagonNetRow<Bubble> GenerateRowOfRandomBubbles()
    {
        HexagonNetRow<Bubble> row = new HexagonNetRow<Bubble>(new BubbleNode[]
        {
            new BubbleNode(bubbleExponentRandomizer.Next(9) + 1),
            new BubbleNode(bubbleExponentRandomizer.Next(9) + 1),
            new BubbleNode(bubbleExponentRandomizer.Next(9) + 1),
            new BubbleNode(bubbleExponentRandomizer.Next(9) + 1),
            new BubbleNode(bubbleExponentRandomizer.Next(9) + 1),
            new BubbleNode(bubbleExponentRandomizer.Next(9) + 1),
        });

        return row;
    }

    private HexagonNetRow<Bubble> GenerateNullRow()
    {
        HexagonNetRow<Bubble> row = new HexagonNetRow<Bubble>(new BubbleNode[]
        {
            new BubbleNode(null),
            new BubbleNode(null),
            new BubbleNode(null),
            new BubbleNode(null),
            new BubbleNode(null),
            new BubbleNode(null),
        });

        return row;
    }
}
