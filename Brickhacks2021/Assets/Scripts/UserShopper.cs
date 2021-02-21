using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserShopper : MonoBehaviour
{
    public float speed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 previousPosition = transform.position;
        Vector3 updatePosition = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            updatePosition.y += speed; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            updatePosition.y -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            updatePosition.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            updatePosition.x += speed;
        }
        previousPosition.x += updatePosition.x;
        previousPosition.y += updatePosition.y;
        transform.position = previousPosition;
    }
}
