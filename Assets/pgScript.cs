using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.SceneManagement;

public class pgScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //--------------------------------------------------------------------------------------------
    public float speed = 8f;
    public float jump = 16f;
    private float horizontal;
    public float slideSpeed = 5f; // Velocità dello scivolamento
    public float slideDuration = 0.5f; // Durata dello scivolamento
    public int cooldownTime = 2; // Tempo di ricarica
    private float movimento = 1f; //movimento x
    public float depthFactor = 3;

    //--------------------------------------------------------------------------------------------
    private Transform groundCheck;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    //--------------------------------------------------------------------------------------------
    private bool isJumping = false;
    private bool canSlide = true;
    private bool pgIsAlive = true;
    private bool imm=false;
    //--------------------------------------------------------------------------------------------
    public KeyCode salta;
    public KeyCode abbassa;
    public KeyCode para;
    public KeyCode colpisci;
    //--------------------------------------------------------------------------------------------
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public int hp = 3;
    //--------------------------------------------------------------------------------------------
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------------------------------------------------------------------------
        //horizontal = Input.GetAxisRaw("Horizontal");
        if (pgIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)//jump
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
                isJumping = true;
            }
            //-------------------------------------------------------------------------------------------------------------------
            if (Input.GetKeyDown(KeyCode.S) && canSlide) // Attiva la scivolata premendo Shift
            {
                Debug.Log("Scivolata avviata!");
                if (canSlide)
                {
                    StartCoroutine(Slide());
                }
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        transform.position += new Vector3(movimento * depthFactor * Time.deltaTime, 0, 0);//movimento player
        //rb.linearVelocityX = (speed * Time.deltaTime);
        //rb.AddForceX(speed);  
        //rb.AddForce(transform.right*speed);
        
        //-------------------------------------------------------------------------------------------------------------------

    }
   /* void FixedUpdate()
    { 
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }*/

    IEnumerator Slide()
    {
        // Disabilita l'abilità temporaneamente
        /*float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // Disattiva la gravità per un effetto più fluido

        Vector2 slideDirection = new Vector2(transform.localScale.x, 0).normalized; // Direzione dello scivolamento
        
        rb.linearVelocity = slideDirection * slideSpeed; */
        bc.size += new Vector2(0, -0.4f);
        canSlide = false;
        Debug.Log("Inizio scivolata per " + slideDuration + " secondi");
        yield return new WaitForSeconds(slideDuration); // Aspetta la durata dello scivolamento
        Debug.Log("Fine scivolata");
        GetComponent<RectTransform>().position += new Vector3(0, 1, 0);
        bc.size += new Vector2(0, 0.4f);
        /* rb.linearVelocity = Vector2.zero; // Ferma il movimento
        rb.gravityScale = originalGravity; // Ripristina la gravità */

        yield return new WaitForSeconds(cooldownTime); // Aspetta il tempo di ricarica
        Debug.Log("Fine cooldown");
        canSlide = true; // Permette di scivolare di nuovo
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;
        }
        if (collision.gameObject.tag == "dannoGr" && !imm)
        {
            Damage();
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("idk entra funzione con" + collider.gameObject.tag);
        if (collider.gameObject.tag == "GameOver")
        {
            GameOver();
        }
    }
    IEnumerator Damage()
    {
        Immortalita();
        hp--;
        switch (hp)
        {
            case 0:
                life1.GetComponent<Animator>().Play("danno");
                yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
                GameOver();
                break;
            case 1:
                life2.GetComponent<Animator>().Play("danno");
                yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
                Destroy(life2);
                break;
            case 2:
                life3.GetComponent<Animator>().Play("danno");
                yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
                Destroy(life3);
                break;
        }

    }
    public void GameOver()
    {
        StaticScript.livello = 5;
        SceneManager.LoadSceneAsync(8);//game over
    }
    IEnumerator Immortalita()
    {
        imm = true;
        GetComponent<Animator>().Play("imm");//animazione immortalita
        yield return new WaitForSeconds(1f); // tempo di immortalita
        //GetComponent<Animator>().("normal");//animazione immortalita
    }
}
