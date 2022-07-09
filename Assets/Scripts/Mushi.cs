using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushi : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject bunny;
    public float jumpForce;
    [SerializeField] private ParticleSystem deadParticles;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource jumpi;
    bool isTouched = false;
    float timeBeforeDie = 3;
    public GameObject MushiDeath;

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
                SacrificialCounter.mushisSacrified++;
                anim.SetBool("IsDying", true);
                timeBeforeDie -= Time.deltaTime; 
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bunny = GameObject.FindGameObjectWithTag("Player");
            rb = bunny.GetComponent<Rigidbody2D>(); 
            rb.velocity = new Vector2(-1, jumpForce);
            isTouched = true;
            jumpi.Play();
        }

    }
    void Death() 
    {
        Instantiate( MushiDeath, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
