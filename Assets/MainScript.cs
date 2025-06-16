using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class MainScript : MonoBehaviour
{
    public Button esci;
    public Button start;
    public Button colle;
    public Button opzio;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public static selezioneLVLScript instance;

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
        if (Input.GetKeyDown(right))
        {
            colle.onClick.Invoke();
        }
        if (Input.GetKeyDown(left))
        {
            opzio.onClick.Invoke();
        }
     }
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);//Personalizzazione pg
    }
    public void CollectiblesGame()
    {
        SceneManager.LoadSceneAsync(3);//Collezionabili 
    }
    public void OptionsGame()
    {
        SceneManager.LoadSceneAsync(2);//Option Game
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
