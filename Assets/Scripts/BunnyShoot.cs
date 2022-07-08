using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyShoot : MonoBehaviour
{
	public Projectile projectilePrefab;
	[HideInInspector] public Projectile projectile;
	void Update()
	{
		if(Input.GetButtonDown("Fire1") && !projectile)
		{
			projectile = Instantiate(projectilePrefab, new Vector3((transform.position.x + .5f), transform.position.y), transform.rotation);
			//projectile.ActivateRb();
			projectile.Throw(new Vector2(5, 0));
		}

		if(Input.GetButtonDown("Fire2") && projectile)
		{
			projectile.Destroy();
		}
	}
}
