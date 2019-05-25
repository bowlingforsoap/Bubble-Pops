using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Graphical representation of a Bubble.
/// </summary>
public class BubbleGraphics : MonoBehaviour
{
    public SpriteRenderer bubbleCenterRenderer;
    public Text bubbleValueText;

    public Bubble Bubble { get; set; }

    public Color[] exponentColors;

    private void Start()
    {
    }

    public void SyncGraphicsWithBubble()
    {
        bubbleCenterRenderer.color = exponentColors[Bubble.Exponent];
        bubbleValueText.text = Bubble.Value.ToString();
    }
}
