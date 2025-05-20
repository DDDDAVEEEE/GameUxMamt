using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class GameOverScript : MonoBehaviour
{
    public static GameOverScript instance;
    public static int lvl;
    void Start()
    {
        instance = this;
        lvl = StaticScript.livello;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void livello(int idk)
    {
        lvl = idk;
    }
    public void Riprova()
    {
        SceneManager.LoadSceneAsync(lvl);
    }
    public void tornaAllaHome()
    {
        SceneManager.LoadSceneAsync(0);
    } 
}
