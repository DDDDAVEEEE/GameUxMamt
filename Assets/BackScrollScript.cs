using UnityEngine;

public class BackGoundScrollScrript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    private float scrollSpeed=-1f;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collider.size.x;
        collider.enabled = false;

        rb.linearVelocity = new Vector2(scrollSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}