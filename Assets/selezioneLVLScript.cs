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
    public KeyCode up;
    public KeyCode down;

    public static selezioneLVLScript instance;
    void Start()
    {
        instance = this;
        esci = GetComponent<Button>();
    }

    public void cambioSelezione (string nuovo){
        start = GameObject.FindGameObjectWithTag(nuovo).GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(down))
        {
            start.onClick.Invoke();
        }
        if (Input.GetKeyDown(up))
        {
            esci.onClick.Invoke();
        }
     }
}


   


