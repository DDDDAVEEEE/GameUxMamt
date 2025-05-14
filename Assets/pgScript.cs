using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;

public class pgScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 8f;
    public float jump= 16f;
    public Rigidbody2D myRigidbody;
    private Transform groundCheck;
    private float horizontal;
    private bool isJumping = false;
    public bool pgIsAlive = true;
    public LogicScript logic;
    void Start()
    {
      // logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        if(pgIsAlive == true)
        {
             
           if(Input.GetButtonDown("Jump") && !isJumping)
           {
                myRigidbody.linearVelocity=new Vector2(myRigidbody.linearVelocity.x, jump);
                isJumping = true;
           }
        }
    }
   /* private void FixedUpdate()
    {
        myRigidbody.linearVelocity=new Vector2(horizontal*speed,myRigidbody.linearVelocity.y );
    } */
    private void OnCollisionEnter2D()
    {
        isJumping = false;
    }
}
