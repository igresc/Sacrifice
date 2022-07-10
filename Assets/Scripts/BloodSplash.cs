using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplash : MonoBehaviour
{
	[SerializeField] private GameObject bloodSplash;

	public void SplashBlood(Transform transform, Collider2D collision)
	{

		Vector2 newPos = transform.position;
		Vector2 relativePoint = GetRelativePosition(transform, collision.bounds.center);
		Debug.Log(relativePoint);
		if(Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
		{
			if(relativePoint.x < 0)
			{
				//Debug.Log("Right");
				newPos.x = newPos.x + relativePoint.x;
			}
			else
			{
				//Debug.Log("Left");
				newPos.x = newPos.x + relativePoint.x;
			}
		}
		else
		{
			if(relativePoint.y < 0)
			{
				//Debug.Log("Top");
				newPos.y = newPos.y + relativePoint.y;
			}
			else
			{
				//Debug.Log("Bottom");
				newPos.y = newPos.y + relativePoint.y;
			}
		}
		Instantiate(bloodSplash, newPos, transform.rotation);
	}

	public static Vector3 GetRelativePosition(Transform origin, Vector3 position)
	{
		Vector3 distance = position - origin.position;
		Vector3 relativePosition = Vector3.zero;
		relativePosition.x = Vector3.Dot(distance, origin.right.normalized);
		relativePosition.y = Vector3.Dot(distance, origin.up.normalized);
		relativePosition.z = Vector3.Dot(distance, origin.forward.normalized);

		return relativePosition;
	}
}
