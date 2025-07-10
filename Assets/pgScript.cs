using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.SceneManagement;
using Unity.Collections;
using UnityEditor.Animations;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;

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
    public BoxCollider2D coll;
    public List<AnimatorController> skins = new List<AnimatorController>();

    //--------------------------------------------------------------------------------------------
    private bool isJumping = false;
    private bool canSlide = true;
    private bool canAttacco = true;
    private bool canShild = true;
    private bool pgIsAlive = false;
    private bool imm=false;
    public bool canMove=true;
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
  // public Animator animCestino;
    public int hp = 3;
    //--------------------------------------------------------------------------------------------
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = skins[PlayerPrefs.GetInt("SelectedSkin")];
        coll = GameObject.FindGameObjectWithTag("col").GetComponent<BoxCollider2D>();
        switch (PlayerPrefs.GetInt("Lvl"))
        {
            case 1:
                if (PlayerPrefs.GetInt("col1") == 1) { Destroy(GameObject.FindGameObjectWithTag("col")); }
                break;
            case 2:
                if (PlayerPrefs.GetInt("col2") == 1) { Destroy(GameObject.FindGameObjectWithTag("col")); }
                break;
            case 3:
                if (PlayerPrefs.GetInt("col3") == 1) { Destroy(GameObject.FindGameObjectWithTag("col")); }
                break;
        }
        hitboxA.gameObject.SetActive(false);
        hitboxS.gameObject.SetActive(false);
        coll.gameObject.SetActive(true); // serve per farlo riapparire, DA CAMBIARE!
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
            if (Input.GetKeyDown(salta) && !isJumping)//jump
            {
                anim.SetBool("IsJumping", true);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);

                isJumping = true;
                StartCoroutine(Jump());
            }
            //-------------------------------------------------------------------------------------------------------------------
            if (Input.GetKeyDown(abbassa) && canSlide && !isJumping) // Attiva la scivolata premendo Shift
            {

                StartCoroutine(Slide());


            }
            //-------------------------------------------------------------------------------------------------------------------   
            if (Input.GetKeyDown(colpisci) && canAttacco) // Attiva la 
            {
                //canShild = false;
                //canAttacco = true;


                StartCoroutine(Attacco());

                //canAttacco = false;
                //canShild = true;        
            }
            //-------------------------------------------------------------------------------------------------------------------   
            if (Input.GetKeyDown(para) && canShild) // Attiva la 
            {
                //canAttacco = false;
                //canShild = true;


                StartCoroutine(Shild());

                //canAttacco = true;
                //canShild = false;

            }

            
            if (!canShild && !canAttacco && !canSlide)
            {
                anim.SetBool("IsRunning", true);
                /* anim.SetBool("IsShield", false);
                 anim.SetBool("IsAttacco", false);
                 anim.SetBool("IsSlide", false);
                 anim.SetBool("IsJumping", false);*/

            }
            else
            {
                anim.SetBool("IsRunning", false);

            }
            transform.position += new Vector3(movimento * depthFactor * Time.deltaTime, 0, 0);
        }


        /*if (!canMove) return;
         */
    

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

    }
    /* void FixedUpdate()
     { 
         rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
     }*/

        /*public void SetCanMove(bool value)
            {
                canMove = value;
            }*/

    IEnumerator TempoIniziale()
    {
        anim.SetBool("IsStart", true);
        tre.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        tre.gameObject.SetActive(false);
        due.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        due.gameObject.SetActive(false);
        uno.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        anim.SetBool("IsStart", false);
        uno.gameObject.SetActive(false);
        go.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        go.gameObject.SetActive(false);
        pgIsAlive = true;
    }

    IEnumerator Jump()
    {
        anim.SetBool("IsJumping", true);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        isJumping = true;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("IsJumping", false);
    }
    
    IEnumerator Shild()
    {
        anim.SetBool("IsShield", true);
        hitboxS.gameObject.SetActive(true);
        canShild = false;
        canAttacco = false;
        yield return new WaitForSeconds(2f); // Aspetta il tempo di ricarica
        anim.SetBool("IsShield", false);
        hitboxS.gameObject.SetActive(false);
        canAttacco = true;
        canShild = true;
    }
    //------------------------------------------------------------------------------------------------------------------------

    IEnumerator Attacco()
    {
        anim.SetBool("IsAttacco", true);
        canAttacco = false;
        canShild = false;
        hitboxA.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f); // Aspetta il tempo di ricarica
        anim.SetBool("IsAttacco", false);
        hitboxA.gameObject.SetActive(false);
        canAttacco = true;
        canShild = true;
    }
    IEnumerator Slide()
    {
        // Disabilita l'abilità temporaneamente
        /*float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // Disattiva la gravità per un effetto più fluido

        Vector2 slideDirection = new Vector2(transform.localScale.x, 0).normalized; // Direzione dello scivolamento
        
        rb.linearVelocity = slideDirection * slideSpeed; */
        anim.SetBool("IsSlide", true);

        bc.size += new Vector2(1.2f, -1);
        bc.offset += new Vector2(0, -0.5f);
        canSlide = false;
        yield return new WaitForSeconds(slideDuration); // Aspetta la durata dello 
        anim.SetBool("IsSlide", false);
        GetComponent<RectTransform>().position += new Vector3(0, 0.5f, 0);
        bc.size -= new Vector2(1.2f, -1);
        bc.offset -= new Vector2(0, -0.5f);
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
        if (collision.gameObject.tag == "DannoGr" && !imm)
        {

            StartCoroutine(Damage());
        }
        if (collision.gameObject.tag == "mob" && !imm)
        {
            if (anim.GetBool("IsAttacco"))
                Debug.Log("STA ATTACCANDO NON SUBISCE DANNO!");
            else
            {
                StartCoroutine(Damage());
            }
        }
        if (collision.gameObject.tag == "Proie" && !imm)
        {
            if (anim.GetBool("IsShield"))
            {
                Debug.Log("parata successo");
                anim.SetBool("IsShield", false);
                anim.Play("ScudoOff");
                hitboxS.gameObject.SetActive(false);
                canAttacco = true;
                canShild = true;
            }
            else
            {
                Debug.Log("colpito da proiettile");
                StartCoroutine(Damage());
            }
        }
        if(collision.gameObject.tag == "Proie" && imm) Debug.Log("ktm");
        
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "GameOver")
        {
            GameOver();
        }
        if ((collider.gameObject.tag == "DannoGr") && !imm)
        {
            StartCoroutine(Damage());
        }
        if (collider.gameObject.tag == "CestinoDopo")
        {
            // Debug.Log("CambioAnimazione");
           // animCestino.SetBool("IsNormal", false);
//animCestino.SetBool("IsCestinoDopo", true); 
        }
        if (collider.gameObject.tag == "col")
        {
            switch (PlayerPrefs.GetInt("Lvl"))
            {
                case 1:
                    PlayerPrefs.SetInt("col1", 1);
                    break;
                case 2:
                    PlayerPrefs.SetInt("col2", 1);
                    break;
                case 3:
                    PlayerPrefs.SetInt("col3", 1);
                    break;
            }
            coll.gameObject.SetActive(false);
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
        switch (PlayerPrefs.GetInt("Lvl"))
            {
                case 1:
                    PlayerPrefs.SetInt("skin1", 1);
                    break;
                case 2:
                    PlayerPrefs.SetInt("skin2", 1);
                    break;
                case 3:
                    PlayerPrefs.SetInt("skin3", 1);
                    break;
            }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(9);
        //ANIMAZIONE VITTORIA / IDLE
    }
    IEnumerator Damage()
    {
        if (!imm) {
            hp--;
            switch (hp)
            {
                case 0:
                    GameOver();
                    break;
                case 1:
                StartCoroutine(Immortalita());
                    life2.GetComponent<Animator>().Play("VitaVuota");
                    yield return new WaitForSeconds(0.1f); // Aspetta il tempo di ricarica
                    Destroy(life2);
                    break;
                case 2:
                StartCoroutine(Immortalita());
                    life3.GetComponent<Animator>().Play("VitaVuota");
                    yield return new WaitForSeconds(0.1f); // Aspetta il tempo di ricarica 
                   Destroy(life3);
                    break;
            }
        }
    }
    public void GameOver()
    {
        hp = 3;
        SceneManager.LoadSceneAsync(8);//game over
    }
    IEnumerator Immortalita()
    {
        imm = true;
        //GetComponent<Animator>().Play("imm");//animazione immortalita
        yield return new WaitForSeconds(2f); // tempo di immortalita    

        imm = false;
        //GetComponent<Animator>().("normal");//animazione immortalita
    }
}
