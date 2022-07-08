using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushi : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;

    void Start()
    {
        //rb = amaru.GetComponent<Rigidbody2D>(); 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.velocity = new Vector2(-1, jumpForce);
        }

    }
}
