using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{

    public GameObject bunnyDeath;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
