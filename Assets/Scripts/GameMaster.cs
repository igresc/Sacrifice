using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	public static GameMaster Instance;

	public float numOfBirdos;
	public bool hasBirdos = true;

	public bool hasKey = false;

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		hasBirdos = true;
	}

	void Update()
	{
		if(numOfBirdos == 0)
		{
			hasBirdos = false;
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			Restart();
		}
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
