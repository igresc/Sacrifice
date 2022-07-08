using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NOBController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public float numOfBirdos = 0;

    GameObject gameMaster;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM");
    }
    void Update()
    {
        numOfBirdos = gameMaster.GetComponent<GameMaster>().numOfBirdos;
        BirdoSetter();
    }
    void BirdoSetter() 
    {
        text.SetText(numOfBirdos.ToString());
    }
}
