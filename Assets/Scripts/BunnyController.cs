using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyController : MonoBehaviour
{

    public GameObject bunnyDeath;
    GameObject door;
    GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key");
        door = GameObject.FindGameObjectWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetButtonDown("Fire3"))
		{
            Instantiate(bunnyDeath, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies")) 
        {
            Instantiate(bunnyDeath, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Key")) 
        {
            key.GetComponent<KeyLogic>().hasKey = true;
            door.GetComponent<Animator>().SetBool("isOpen", true);
        }
        if (collision.CompareTag("Door") && key.GetComponent<KeyLogic>().hasKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
