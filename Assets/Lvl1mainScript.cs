using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Lvl1mainScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "GameOver")
        {
            //int lvl = 5;
            StaticScript.livello = 5;
            SceneManager.LoadSceneAsync(8);
        } 
    }
    void Update()
    { 
       // if()
        //pausa menu 
    }
}
