using System.Collections;
using UnityEngine;
using UnityEngine.LowLevelPhysics;
using UnityEngine.Rendering.Universal;

public class ScriptMelee : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;
    public BoxCollider2D bc;
    private BoxCollider2D pg;
    public bool isDam = false;
    public bool isAtt = false;

    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        pg = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        anim = this.GetComponent<Animator>();
    }
    private void Update()
    {
        if (bc.Distance(pg).distance < 5f && !isDam && !isAtt)
        {
            Debug.Log(bc.Distance(pg).distance);
            StartCoroutine(Attacco());
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Attacco")
        {
            //inserire animazione
            bc.enabled = false;
            anim.SetBool("isDam", true);
            isDam = true;
            //StartCoroutine(Morte());
        }

    }
    IEnumerator Attacco()
    {
        //inserire animazione
        isAtt = true;
        anim.SetBool("Att", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Att", false);
        isAtt = false;
    }

    /*IEnumerator Morte()
    {
        //inserire animazione
        anim.SetBool("isDam", true);
        yield return new WaitForSeconds(0.2f);
    }*/ 
}
