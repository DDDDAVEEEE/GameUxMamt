using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class selezioneLVLScript : MonoBehaviour
{
    
    public Button esci;
    public Button start;
    public 
    void Start()
    {
        esci = GetComponent<Button>();   
    }

    public void cambioSelezione (string nuovo){
        start = GameObject.FindGameObjectWithTag(nuovo).GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            start.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            esci.onClick.Invoke();
        }
     }
}


   


