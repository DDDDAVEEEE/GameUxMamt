 using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    public static GameOverScript instance;
    public static int lvl;
    public KeyCode right;
    public KeyCode left;
    public Button esci;
    public Button riprova;
    
    void Update()
    {
        if (Input.GetKeyDown(right))
        {
            riprova.onClick.Invoke();
        }
        if (Input.GetKeyDown(left))
        {
            esci.onClick.Invoke();
        }
    }

    void Start()
    {
        instance = this;
        lvl = PlayerPrefs.GetInt("Lvl")+4;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Riprova()
    {
        SceneManager.LoadSceneAsync(lvl);
    }
    public void tornaAllaHome()
    {
        SceneManager.LoadSceneAsync(0);
    } 
}
