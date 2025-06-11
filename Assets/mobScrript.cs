using System.Collections;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class mobScrript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;
    public BoxCollider2D bc;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
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
        bc.size += new Vector2(0, -4);
        anim.SetBool("Hurt", true);
        GetComponent<Collider2D>().enabled = false;
        
        yield return new WaitForSeconds(0);
        
    }
}
