using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class selezioneLVLScript : MonoBehaviour
{
    
    public GameObject PlayLVL1;
    public GameObject PlayLVL2;
    public GameObject PlayLVL3;
    
   public void Start()
    {
        PlayLVL1.SetActive(false); // Nasconde il pulsante all'inizio
        PlayLVL2.SetActive(false); 
        PlayLVL3.SetActive(false); 
        Debug.Log("Bottone disattivato!");
        
    }
    void Update()
{
   Debug.Log("Posizione attuale: " + transform.position);

}


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collisione con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("playerr"))
        {
            Debug.Log("Collisione con: " + collision.gameObject.name);

            PlayLVL1.SetActive(true);
            Debug.Log("Bottone attivato!");
        }
        
    }

    private void OnTriggerExit2DLVL1(Collider2D collider)
    {
        if (collider.CompareTag("Player")) // Quando il player esce, nasconde il bottone
        {
            PlayLVL1.SetActive(false);
        }
    }
     public void OnTriggerEnter2DLVL2(Collider2D collision2)
    {
        Debug.Log("Collisione con: " + collision2.gameObject.name);
        if (collision2.CompareTag("Player"))
        {
            PlayLVL2.SetActive(true);
            Debug.Log("Bottone attivato!");
        }
        
    }
    private void OnTriggerExit2DLVL2(Collider2D collider2)
    {
        if (collider2.CompareTag("Player")) // Quando il player esce, nasconde il bottone
        {
            PlayLVL2.SetActive(false);
        }
    }

    public void OnTriggerEnter2DLVL3(Collider2D collision3)
    {
        Debug.Log("Collisione con: " + collision3.gameObject.name);
        if (collision3.CompareTag("Player"))
        {
            PlayLVL3.SetActive(true);
            Debug.Log("Bottone attivato!");
        }
        
    }
    private void OnTriggerExit2DLVL3(Collider2D collider3)
    {
        if (collider3.CompareTag("Player")) // Quando il player esce, nasconde il bottone
        {
            PlayLVL3.SetActive(false);
        }
    }
    public void GoToLvl1()
    {
        SceneManager.LoadSceneAsync(1);//Option Game
    }
    public void GoToLvl2()
    {
        SceneManager.LoadSceneAsync(1);
    }
        public void GoToLvl3()
    {
        SceneManager.LoadSceneAsync(1);
    }
    

}
