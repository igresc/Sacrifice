using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BunnyShoot : MonoBehaviour
{
	public Projectile projectilePrefab;
	[HideInInspector] public Projectile projectile;

	private bool isAiming = false;
	private Vector2 dir;
	private LineRenderer lineRenderer;
	GameObject GM;
	private void Awake()
	{
		GM = GameObject.FindGameObjectWithTag("GM");
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.enabled = false;
	}

	void Update()
	{
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		worldPosition.z = 0;
		if(GM.GetComponent<GameMaster>().hasBirdos)
		{
			if(Input.GetButtonDown("Fire1") && !projectile)
			{
				lineRenderer.enabled = true;
				isAiming = true;
			}

			if(isAiming)
			{
				dir = worldPosition - gameObject.transform.position;
				dir = dir * 1.5f;
				//float distance = dir.magnitude;
				PlotTrajectory(gameObject.transform.position, dir, .1f, 1.2f);
				lineRenderer.SetPosition(0, transform.position);
			}

			if(Input.GetButtonUp("Fire1") && isAiming)
			{
				projectile = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y), transform.rotation);
				projectile.Throw(dir);
				isAiming = false;
				lineRenderer.enabled = false;
				GM.GetComponent<GameMaster>().numOfBirdos--;
			}
		}

		if(Input.GetButtonDown("Fire2") && projectile)
		{
			projectile.Die();
		}
	}
	public Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, float time)
	{
		return start + startVelocity * time + Physics.gravity * time * time * 0.5f;
	}

	public void PlotTrajectory(Vector3 start, Vector3 startVelocity, float timestep, float maxTime)
	{
		Vector3 prev = start;
		for(int i = 1; ; i++)
		{
			float t = timestep*i;
			if(t > maxTime) break;
			Vector3 pos = PlotTrajectoryAtTime (start, startVelocity, t);
			if(Physics.Linecast(prev, pos)) break;
			//Debug.DrawLine(prev, pos, Color.red);
			lineRenderer.SetPosition(i, pos);
			prev = pos;
		}

	}
}
