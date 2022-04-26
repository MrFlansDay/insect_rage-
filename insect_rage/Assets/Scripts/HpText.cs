using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour
{

    public Text HPtext;


    void Update()
    {
        HPtext.text = "HP: " + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().Health;
    }
}
