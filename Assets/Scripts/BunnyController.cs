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
    GameMaster GM;
    [SerializeField] private AudioSource keySound;
    //public GameObject popUp;

    void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key");
        door = GameObject.FindGameObjectWithTag("Door");
        GM = GameMaster.Instance;

		Physics2D.IgnoreLayerCollision(8,9);
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
        //Debug.Log(collision.name);
        if (collision.CompareTag("Enemies")) 
        {
            Die();
        }
        if (collision.CompareTag("Key")) 
        {
            key.GetComponent<KeyLogic>().hasKey = true;
            GM.GetComponent<GameMaster>().hasKey = true;
            door.GetComponent<Animator>().SetBool("isOpen", true);
            keySound.Play();
        }
        if(collision.CompareTag("Door") && GM.GetComponent<GameMaster>().hasKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator RespawnBunny()
    {
        Vector3 newPos = new Vector3(birdo.transform.position.x, birdo.transform.position.y + .5f); 
        Instantiate(Bunny, newPos, Quaternion.identity);
        birdo.Die();
		Destroy(this.gameObject);
        yield return null;
    }

    void Die()
	{
        SacrificialCounter.bunniesSacrified++;
        Instantiate(bunnyDeath, transform.position, transform.rotation);
        //popUp.transform.position = new Vector2(transform.position.x, transform.position.y);
        //Instantiate(popUp, popUp.transform.position, transform.rotation);
        if (birdo == null)
		{
            Destroy(gameObject);
			GM.Invoke("Restart", 2.0f);
		}
		else {
            Debug.Log(birdo);
            StartCoroutine(RespawnBunny());
        }
	}
}
