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
			projectile = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 1), transform.rotation);
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			Vector3 dir = worldPosition - gameObject.transform.position;
			float distance = dir.magnitude;
			Debug.Log(distance);
			projectile.Throw(new Vector2(dir.x, dir.y) * 1.5f);
		}


		if(Input.GetButtonDown("Fire2") && projectile)
		{
			projectile.Destroy();
		}
	}
}
