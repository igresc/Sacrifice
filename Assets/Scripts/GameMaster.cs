using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public float numOfBirdos;
    public bool hasBirdos = true;
    void Start()
    {
        hasBirdos = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfBirdos == 0) 
        {
            hasBirdos = false;
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
