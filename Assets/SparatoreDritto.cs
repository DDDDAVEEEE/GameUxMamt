using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;

public class SparatoreDritto : MonoBehaviour
{
    public GameObject Proiettile;

    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Nemico Individuato" + collider.gameObject.tag);
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(Proiettile, GetComponent<RectTransform>().position, GetComponent<RectTransform>().localRotation);
        }
    }
}
