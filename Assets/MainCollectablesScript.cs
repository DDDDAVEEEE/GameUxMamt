using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class MainCollectablesScript : MonoBehaviour
{
    public Button esci;
    public KeyCode up;
    public KeyCode down;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            esci.onClick.Invoke();
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
