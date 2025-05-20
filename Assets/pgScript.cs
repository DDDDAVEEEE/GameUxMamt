using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;

public class pgScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 8f;
    public float jump = 16f;
    private Transform groundCheck;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    private float horizontal;
    private bool isJumping = false;
    private bool canSlide = true;
    public float slideSpeed = 5f; // Velocità dello scivolamento
    public float slideDuration = 0.5f; // Durata dello scivolamento
    public int cooldownTime = 2; // Tempo di ricarica

    private bool pgIsAlive = true;
   // public LogicScript logic;
    public KeyCode salta;
    public KeyCode abbassa;
    public KeyCode para;
    public KeyCode colpisci;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        if (pgIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)//jump
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
                isJumping = true;
            }
            if (Input.GetKeyDown(KeyCode.S) && canSlide) // Attiva la scivolata premendo Shift
            {
                Debug.Log("Scivolata avviata!");
                if (canSlide)
                {
                    StartCoroutine(Slide());
                }
            }

        }
        
    }
    IEnumerator Slide()
    {
        // Disabilita l'abilità temporaneamente
        /*float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // Disattiva la gravità per un effetto più fluido

        Vector2 slideDirection = new Vector2(transform.localScale.x, 0).normalized; // Direzione dello scivolamento
        
        rb.linearVelocity = slideDirection * slideSpeed; */
        bc.size += new Vector2(0, -0.4f);
        canSlide = false;
        Debug.Log("Inizio scivolata per "+slideDuration+" secondi");
        yield return new WaitForSeconds(slideDuration); // Aspetta la durata dello scivolamento
        Debug.Log("Fine scivolata");
        GetComponent<RectTransform>().position += new Vector3(0,1,0);
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
    }
}
