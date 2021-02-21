using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //keeps track of the two scores and the playerfor collisions 
    public int happyScore;
    public int surviveScore;
    public SpriteRenderer playerSprite;
    void Update()
    {
        //moves the item based off of pixels 
        GameObject tempObj = new GameObject();
        tempObj.transform.position = new Vector2(transform.position.x - .2f, transform.position.y);
        transform.position = tempObj.transform.position;
        Destroy(tempObj);
    }
}
