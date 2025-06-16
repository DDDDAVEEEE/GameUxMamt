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
