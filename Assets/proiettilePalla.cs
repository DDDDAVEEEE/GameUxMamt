using UnityEngine;

public class proiettilePalla : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float predict;
    private float timer;
    public float TTL = 5;
    public bool drittaX = false;
    public bool drittaY = false;
    public bool fragile = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        if (direction.x > 0) predict = -predict;
        if (drittaX) rb.linearVelocity = new Vector2(direction.x, 0).normalized * force;
        else if(drittaY)    rb.linearVelocity = Vector2.down.normalized * force;
        else rb.linearVelocity = new Vector2(direction.x, direction.y * predict).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > TTL)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (fragile && collider2D.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
        /*if (collision.gameObject.CompareTag("Shild"))
        {
            Destroy(gameObject);
        }*/
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (fragile && !collision2D.gameObject.CompareTag("mob"))
        {
            Destroy(gameObject);
        }
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
 