using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;
public class LvlSelectionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoToLvl1()
    {
        SceneManager.LoadSceneAsync(5);//Option Game
    }
    public void GoToLvl2()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void GoToLvl3()
    {
        SceneManager.LoadSceneAsync(7);
    }
    public void GoToCharterSelection()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
