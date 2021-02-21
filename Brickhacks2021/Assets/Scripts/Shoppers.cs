﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoppers : MonoBehaviour
{
    // needs player sprite for collisions not sure but there for convienece
    public SpriteRenderer playerSprite;

    // Update is called once per frame
    void Update()
    {
        // moves the object by changing how many pixels it moves to the left
        GameObject tempObj = new GameObject();
        tempObj.transform.position = new Vector2(transform.position.x - .2f, transform.position.y);
        transform.position = tempObj.transform.position;
        Destroy(tempObj);
    }
}
