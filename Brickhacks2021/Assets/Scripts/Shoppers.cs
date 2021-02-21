using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoppers : MonoBehaviour
{
    int randomInt; 
    public SpriteRenderer playerSprite;
    public BoxCollider2D shopperItem;
    private void Start()
    {
        randomInt = Random.Range(0, 4);
        switch (randomInt)
        {
            case (0):
                shopperItem.transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize - shopperItem.size.y);
                break;
            case (1):
                shopperItem.transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, shopperItem.size.y);
                break;
            case (2):
                shopperItem.transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, - shopperItem.size.y);
                break;
            case (3):
                shopperItem.transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, -Camera.main.orthographicSize - shopperItem.size.y);
                break;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        GameObject tempObj = new GameObject();
        tempObj.transform.position = new Vector2(shopperItem.transform.position.x - .5f, shopperItem.transform.position.y);
        shopperItem.transform.position = tempObj.transform.position;
        Destroy(tempObj);
    }
}
