using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class victoryscript : MonoBehaviour
{
    public static GameOverScript instance;
    public static int lvl;
    public KeyCode down;
    public KeyCode up;
    public Button esci;
    public Button riprova;

    void Update()
    {
        if (Input.GetKeyDown(down))
        {
            riprova.onClick.Invoke();
        }
        if (Input.GetKeyDown(up))
        {
            esci.onClick.Invoke();
        }
    }

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void sellvl()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void tornaAllaHome()
    {
        SceneManager.LoadSceneAsync(0);
    }
}

