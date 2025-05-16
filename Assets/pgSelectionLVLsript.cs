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
            selezioneLVLScript.instance.cambioSelezione("lvl1");
            // Debug.Log("Bottone attivato!");
        }
        if (collision.gameObject.tag == "cast2")
        {
            Debug.Log("if!");
            PlayLVL1.SetActive(false);
            PlayLVL2.SetActive(true);
            PlayLVL3.SetActive(false);
            Debug.Log("Bottone2 attivato!");
            selezioneLVLScript.instance.cambioSelezione("lvl2");
        }
        if (collision.gameObject.tag == "cast3")
        {
            PlayLVL1.SetActive(false);
            PlayLVL2.SetActive(false);
            PlayLVL3.SetActive(true);
            Debug.Log("Bottone 3 attivato!");
            selezioneLVLScript.instance.cambioSelezione("lvl3");
        } 
    }
    
}
