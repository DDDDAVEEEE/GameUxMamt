using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class pgSelectionLVLsript : MonoBehaviour
{
    
    public Vector2[] positions = new Vector2[3]; // Tre posizioni predefinite
    private int currentIndex = -3; // Indice della posizione attuale

    public GameObject selezioneLVLScript;
    public GameObject PlayLVL1;
    public GameObject PlayLVL2;
    public GameObject PlayLVL3;
    public Rigidbody2D mamt;
    
   public void Start()
    {
        PlayLVL1.SetActive(false); // Nasconde il pulsante all'inizio
        PlayLVL2.SetActive(false); 
        PlayLVL3.SetActive(false); 
        selezioneLVLScript = GameObject.FindGameObjectWithTag("idk").GetComponent<GameObject>();
        Debug.Log("Bottone disattivato!");
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentIndex = Mathf.Clamp(currentIndex + 1, 0, positions.Length - 1); // Avanza
            transform.position = positions[currentIndex];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentIndex = Mathf.Clamp(currentIndex - 1, 0, positions.Length - 1); // Torna indietro
            transform.position = positions[currentIndex];
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       Debug.Log("Collisione con: " + collision.gameObject.name);
        if (collision.gameObject.tag == "cast1")
        {
            //  Debug.Log("Collisione con: " + collision.gameObject.name);
            
            PlayLVL1.SetActive(true);
            PlayLVL2.SetActive(false);
            PlayLVL3.SetActive(false);
            Debug.Log("Bottone 1 attivato!");
           // Debug.Log("Bottone attivato!");
        }
        
    }

   /* private void OnTriggerExit2DLVL1(Collider2D collider)
    {
        if (collider.gameObject.tag == "cast1") // Quando il player esce, nasconde il bottone
        {
            PlayLVL1.SetActive(false);
            Debug.Log("Bottone 1 disattivo!");
        }
    }*/
     public void OnTriggerEnter2DLVL2(Collider2D collision)
    {
        Debug.Log("Collisione con: " + collision.gameObject.name);
        if (collision.gameObject.tag == "cast2")
        {
            PlayLVL1.SetActive(false);
            PlayLVL2.SetActive(true);
            PlayLVL3.SetActive(false);
            Debug.Log("Bottone2 attivato!");
        }
        
    }
   /* private void OnTriggerExit2DLVL2(Collider2D collider2)
    {
        if (collider2.gameObject.tag == "cast2") // Quando il player esce, nasconde il bottone
        {
            PlayLVL2.SetActive(false);
            Debug.Log("Bottone 2 disattivo!");
        }
    }*/

    public void OnTriggerEnter2DLVL3(Collider2D collision)
    {    
        if (collision.gameObject.tag == "cast3")
        {
            PlayLVL1.SetActive(false);
            PlayLVL2.SetActive(false);
            PlayLVL3.SetActive(true);
            Debug.Log("Bottone 3 attivato!");
        }    
    }
    /*private void OnTriggerExit2DLVL3(Collider2D collider3)
    {
        if (collider3.gameObject.tag == "cast3") // Quando il player esce, nasconde il bottone
        {
            PlayLVL3.SetActive(false);
            Debug.Log("Bottone 3 disattivo!");  
        }
    }*/
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
}
