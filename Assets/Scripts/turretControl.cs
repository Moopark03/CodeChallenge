using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretControl : MonoBehaviour
{
    public float movementSpeed;

    void Start()
    {
        movementSpeed = 800f;
    }


    void Update()
    {
        if (transform.position.y > 1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime, transform.position.z);
        }
        else if(transform.position.y <= 1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }

}
