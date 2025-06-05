using System.Collections;
using UnityEngine;

public class mobScrript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Attacco")
        {
            StartCoroutine(Morte());
        }

    }
    IEnumerator Morte()
    {
        //inserire animazione
        yield return new WaitForSeconds(0);
        gameObject.SetActive(false);
    }
}
