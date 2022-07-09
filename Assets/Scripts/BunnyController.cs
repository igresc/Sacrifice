using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public GameObject Bunny;
    public GameObject bunnyDeath;
    private Projectile birdo;
    GameObject door;
    GameObject key;
    GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key");
        door = GameObject.FindGameObjectWithTag("Door");
        GM = GameObject.FindGameObjectWithTag("GM");
    }

    void Update()
    {
		if(Input.GetButtonDown("Fire3"))
		{
            Die();
		}
        birdo = GetComponent<BunnyShoot>().projectile;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag("Enemies")) 
        {
            Die();
        }
        if (collision.CompareTag("Key")) 
        {
            key.GetComponent<KeyLogic>().hasKey = true;
            GM.GetComponent<GameMaster>().hasKey = true;
            door.GetComponent<Animator>().SetBool("isOpen", true);
        }
        if(collision.CompareTag("Door") && GM.GetComponent<GameMaster>().hasKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator RespawnBunny()
    {
        Instantiate(Bunny, birdo.transform.position, Quaternion.identity);
        birdo.Die();
		Destroy(this.gameObject);
        yield return null;
    }

    void Die()
	{
        Instantiate(bunnyDeath, transform.position, transform.rotation);
        StartCoroutine(RespawnBunny());
	}
}
