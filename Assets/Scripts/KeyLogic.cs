using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogic : MonoBehaviour
{
	public bool hasKey = false;
	void Update()
	{
		if(hasKey)
		{
			Destroy(this.gameObject);
		}
	}
}
