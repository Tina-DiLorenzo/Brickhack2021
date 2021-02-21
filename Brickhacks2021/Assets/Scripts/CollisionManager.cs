using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Declaring fields
    public List<GameObject> items;
    public GameObject player;
    public List<GameObject> shoppers;

    // Update is called once per frame
    void Update()
    {
        // Check for collisions of player between shoppers and items, add items if they collide with player
        // or take damage if they collide with shoopper
        for (int i = 0; i < shoppers.Count; i++)
        {
            if (Collision(player, shoppers[i]))
            {
                // Decrease life of player
                if (player.GetComponent<Player>() != null)
                {
                    player.GetComponent<Player>().DecrementHealth();
                }
                // Destroy GameObject and remove it from shoppers array
                Destroy(shoppers[i]);
                shoppers.RemoveAt(i);
                i--;
            }
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (Collision(player, items[i]))
            {
                if (player.GetComponent<Player>() != null)
                {
                    player.GetComponent<Player>().AddItem(items[i]);
                }
                items.RemoveAt(i);
                i--;
            }
        }
        
    }

    // Method to determine collision (AABB method)
    public bool Collision(GameObject a, GameObject b)
    {
        // initialize bool to be returned to false
        bool collide = false;

        // 4 conditionals check for collision
        if (b.GetComponent<SpriteRenderer>().bounds.min.x < a.GetComponent<SpriteRenderer>().bounds.max.x && b.GetComponent<SpriteRenderer>().bounds.max.x > a.GetComponent<SpriteRenderer>().bounds.min.x && b.GetComponent<SpriteRenderer>().bounds.max.y > a.GetComponent<SpriteRenderer>().bounds.min.y && b.GetComponent<SpriteRenderer>().bounds.min.y < a.GetComponent<SpriteRenderer>().bounds.max.y)
        {
            // set bool to true if collision detected
            collide = true;
        }

        // return bool
        return collide;
    }
}
