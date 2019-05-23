using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorTest : MonoBehaviour
{
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = new Color(Mathf.Sin(Time.time), Mathf.Cos(Time.time), Mathf.Tan(Time.time));
    }
}
