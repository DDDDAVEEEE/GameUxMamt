using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1mainScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("idk entra funzione con" + collider.gameObject.tag);
        if (collider.gameObject.tag == "GameOver")
        {
            SceneManager.LoadSceneAsync(8);
        }
    }
    void Update()
    { 
       // if()
        //pausa menu 
    }
}
