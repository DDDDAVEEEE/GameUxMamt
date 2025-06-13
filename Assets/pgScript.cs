using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.SceneManagement;
using UnityEditor.Tilemaps;

public class pgScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //--------------------------------------------------------------------------------------------
    public float speed = 8f;
    public float jump = 16f;
    private float horizontal;
    public float slideSpeed = 5f; // Velocità dello scivolamento
    public float slideDuration = 2f; // Durata dello scivolamento
    public int cooldownTime = 2; // Tempo di ricarica
    private float movimento = 1f; //movimento x
    public float depthFactor = 3;

    //--------------------------------------------------------------------------------------------
    private Transform groundCheck;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public BoxCollider2D hitboxA;
    public CircleCollider2D hitboxS;
    public BoxCollider2D Cuffie;

    //--------------------------------------------------------------------------------------------
    private bool isJumping = false;
    private bool canSlide = true;
    private bool canAttacco = true;
    private bool canShild = true;
    private bool pgIsAlive = false;
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
    public GameObject  tre;
    public GameObject due;
    public GameObject uno;
    public GameObject go;
   
    public Animator anim;
   public Animator animCestino;
    public int hp = 3;
    //--------------------------------------------------------------------------------------------
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        hitboxA.gameObject.SetActive(false);
        hitboxS.gameObject.SetActive(false);
        Cuffie.gameObject.SetActive(true); // serve per farlo riapparire, DA CAMBIARE!
        tre.gameObject.SetActive(false);
        due.gameObject.SetActive(false);
        uno.gameObject.SetActive(false);
        go.gameObject.SetActive(false);

        StartCoroutine(TempoIniziale());
        
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
                isJumping = true;
                anim.SetBool("IsJumping", isJumping);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);


            }
            //-------------------------------------------------------------------------------------------------------------------
            if (Input.GetKeyDown(KeyCode.S) && canSlide && !isJumping) // Attiva la scivolata premendo Shift
            {
                Debug.Log("Scivolata avviata!");

                StartCoroutine(Slide());


            }
            //-------------------------------------------------------------------------------------------------------------------   
            if (Input.GetKeyDown(KeyCode.A) && canAttacco) // Attiva la 
            {
                Debug.Log("Attacco avviato!");
                StartCoroutine(Attacco());
            }
            //-------------------------------------------------------------------------------------------------------------------   
            if (Input.GetKeyDown(KeyCode.D) && canShild) // Attiva la 
            {
                Debug.Log("Scudo avviato!");
                StartCoroutine(Shild());
            }

            if (!canShild && !canAttacco && !canSlide)
            {
                /* anim.SetBool("IsShield", false);
                 anim.SetBool("IsAttacco", false);
                 anim.SetBool("IsSlide", false);
                 anim.SetBool("IsJumping", false);*/

            }


        }
    }

    private void FixedUpdate()
    {
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        if(pgIsAlive) transform.position += new Vector3(movimento * depthFactor * Time.deltaTime, 0, 0);
    }
        /*else
        {
            //animazione vittoria/idle
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsRunning", false);
        }*/
        //-------------------------------------------------------------------------------------------------------------------
        //movimento player
        //rb.linearVelocityX = (speed * Time.deltaTime);
        //rb.AddForceX(speed);  
        //rb.AddForce(transform.right*speed);

            //-------------------------------------------------------------------------------------------------------------------

    /* void FixedUpdate()
     { 
         rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
     }*/
    IEnumerator TempoIniziale()
    {
        anim.SetBool("IsIdle", true);
        tre.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        tre.gameObject.SetActive(false);
        due.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        due.gameObject.SetActive(false);
        uno.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        uno.gameObject.SetActive(false);
        go.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        anim.SetBool("IsIdle", false);
        go.gameObject.SetActive(false);
        pgIsAlive = true;
    }
    
    IEnumerator Shild()
    {
        Debug.Log("funziona!");
        anim.SetBool("IsShield", canShild);
        canShild = false;
        canAttacco = false;
        canSlide = false;
        hitboxS.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); // Aspetta il tempo di ricarica
        anim.SetBool("IsShield", false);
        yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
        hitboxS.gameObject.SetActive(false);
        canAttacco = true;
        canShild = true;
        canSlide = true;
    }
    IEnumerator Pop()
    {
        anim.SetBool("IsShield", false);
        yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
        hitboxS.gameObject.SetActive(false);
        canAttacco = true;
        canShild = true;
        canSlide = true;
    }
    //------------------------------------------------------------------------------------------------------------------------

    IEnumerator Attacco()
    {
        Debug.Log("funziona attacco!");
        anim.SetBool("IsAttacco", canAttacco);
        canAttacco = false;
        canShild = false;
        canSlide = false;
        hitboxA.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
        anim.SetBool("IsAttacco", false);
        hitboxA.gameObject.SetActive(false);
        canAttacco = true;
        canShild = true;
        canSlide=true;
    }
    IEnumerator Slide()
    {
        // Disabilita l'abilità temporaneamente
        /*float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // Disattiva la gravità per un effetto più fluido

        Vector2 slideDirection = new Vector2(transform.localScale.x, 0).normalized; // Direzione dello scivolamento
        
        rb.linearVelocity = slideDirection * slideSpeed; */
        anim.SetBool("IsSlide", true);
        bc.size += new Vector2(+2f, -2f);
        canSlide = false;
        canShild = false;
        canAttacco = false;
        Debug.Log("Inizio scivolata per " + slideDuration + " secondi");
        yield return new WaitForSeconds(slideDuration); // Aspetta la durata dello 
        anim.SetBool("IsSlide", false);
        Debug.Log("Fine scivolata");
        GetComponent<RectTransform>().position += new Vector3(0, 1, 0);
        bc.size += new Vector2(-2f, 2f);
        /* rb.linearVelocity = Vector2.zero; // Ferma il movimento
        rb.gravityScale = originalGravity; // Ripristina la gravità */

        yield return new WaitForSeconds(cooldownTime); // Aspetta il tempo di ricarica
        Debug.Log("Fine cooldown");
        canSlide = true; // Permette di scivolare di nuovo
        canAttacco=true;
        canShild=true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;
            anim.SetBool("IsJumping", isJumping);
        }
        if (collision.gameObject.tag == "DannoGr" && !imm)
        {
            Debug.Log("prende danno!");
            StartCoroutine(Damage());
        }
        if (collision.gameObject.tag == "mob" && !imm)
        {
            Debug.Log("prende danno!");
            if (canAttacco)
                StartCoroutine(Damage());
        }
        if (collision.gameObject.tag == "Proie" && !imm)
        {
            if (canShild)
                StartCoroutine(Damage());
            else
                Pop();
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("idk entra funzione con" + collider.gameObject.tag);
        if (collider.gameObject.tag == "GameOver")
        {
            GameOver();
        }
        if ((collider.gameObject.tag == "DannoGr" || collider.gameObject.tag == "Proie") && !imm)
        {
            Debug.Log("prende danno!");
            StartCoroutine(Damage());
        }
        if (collider.gameObject.tag == "CestinoDopo")
        {
            // Debug.Log("CambioAnimazione");
            animCestino.SetBool("IsNormal", false);
            animCestino.SetBool("IsCestinoDopo", true); 
        }
        if (collider.gameObject.tag == "col")
        {
            Debug.Log("DDistruzione");
            Cuffie.gameObject.SetActive(false);
            //StaticScript. = 5;
        }
        if (collider.gameObject.tag == "Bandiera")
        {
            StartCoroutine(Vittoria());
        }
    }

    IEnumerator Vittoria()
    {
        yield return new WaitForSeconds(1f);
        pgIsAlive = false;
        //ANIMAZIONE VITTORIA / IDLE
    }
    IEnumerator Damage()
    {
        
        Debug.Log("decrementa hp!");
        if (!imm) {
            imm = true;
            anim.SetBool("IsDamage",true);
            hp--;
            switch (hp)
            {
                case 0:
                    life1.GetComponent<Animator>().Play("life1");
                    yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
                    GameOver();
                    break;
                case 1:
                    life2.GetComponent<Animator>().Play("VitaVuota");
                    yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
                    anim.SetBool("IsDamage",false);
                    Destroy(life2);
                    break;
                case 2:
                    Debug.Log("leva la terza vita!");
                    life3.GetComponent<Animator>().Play("life1");
                    yield return new WaitForSeconds(0.5f); // Aspetta il tempo di ricarica
                    anim.SetBool("IsDamage",false);
                    Destroy(life3);
                    break;
            }
            new WaitForSeconds(1f);
            imm = false;
        }
    }
    public void GameOver()
    {
        hp = 3;
        StaticScript.livello = 5;
        SceneManager.LoadSceneAsync(8);//game over
    }
}