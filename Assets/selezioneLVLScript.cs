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
    public int skin;
    public KeyCode down;

    public static selezioneLVLScript instance;
    void Start()
    {
        skin = PlayerPrefs.GetInt("SelectedSkin");
        Debug.Log(skin);
        instance = this;
        esci = GameObject.FindGameObjectWithTag("exit").GetComponent<Button>();
    }

    public void cambioSelezione (string nuovo){
        if (nuovo == "lvl1") PlayerPrefs.SetInt("Lvl", 1);
        else if (nuovo == "lvl2") PlayerPrefs.SetInt("Lvl", 2);
        else if (nuovo == "lvl3") PlayerPrefs.SetInt("Lvl", 3);
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


   


