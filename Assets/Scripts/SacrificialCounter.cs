using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SacrificialCounter : MonoBehaviour
{
    public static int bunniesSacrified;
    public static int birdosSacrified;
    public static int mushisSacrified;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        //Debug.Log(bunniesSacrified);
        //Debug.Log(birdosSacrified);
        //Debug.Log(mushisSacrified);
        if (SceneManager.GetActiveScene().buildIndex == 0) 
        {
            bunniesSacrified = 0;
            birdosSacrified = 0;
            mushisSacrified = 0;
        }
    }
}
