using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushi : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    [SerializeField] private ParticleSystem deadParticles;
    [SerializeField] private Animator anim;
    bool isTouched = false;
    float timeBeforeDie = 3;

    void Start()
    {
        //rb = amaru.GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        if (isTouched) 
        {
            if (timeBeforeDie <= 0)
            {
                Death();
            }
            else 
            {
                anim.SetBool("IsDying", true);
                timeBeforeDie -= Time.deltaTime; 
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.velocity = new Vector2(-1, jumpForce);
            isTouched = true;
        }

    }
    void Death() 
    {
        Instantiate(deadParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
