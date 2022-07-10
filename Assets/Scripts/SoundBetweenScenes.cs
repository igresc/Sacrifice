using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBetweenScenes : MonoBehaviour
{
	private SoundBetweenScenes intance;
	public SoundBetweenScenes Instance
	{
		get
		{
			return intance;
		}
	}

	private void Awake()
	{
		if(FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}

		//Debug.Log(transform.childCount);

		if(intance != null && intance != this)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			intance = this;
		}

		DontDestroyOnLoad(gameObject);
	}
}
