using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Declaring fields
    public int lives;
    public List<GameObject> playerItems;
    // Start is called before the first frame update
    void Start()
    {
        this.lives = 3;
        playerItems = new List<GameObject>();
    }
    // Have player take damage
    public void DecrementHealth()
    {
        this.lives = this.lives - 1;
    }

    // Add item to players list of items
    public void AddItem(GameObject item)
    {
        this.playerItems.Add(item);
    }
}
