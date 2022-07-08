using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeath : MonoBehaviour
{
	public GameObject birdDeath;
	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemies"))
		{
			Vector3 PuntoDeMuerte = new Vector3(transform.position.x - 1f, transform.position.y);
			Instantiate(birdDeath, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
