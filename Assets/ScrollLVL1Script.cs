using UnityEngine;

public class BackGoundScrollScrript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BoxCollider2D colliderSfondo;
    public Rigidbody2D rbSfondo;
    private float width;
    private float scrollSpeed=-1f;
    void Start()
    {
        colliderSfondo = GetComponent<BoxCollider2D>();
        rbSfondo = GetComponent<Rigidbody2D>();

        width = colliderSfondo.size.x;
        colliderSfondo.enabled = false;

        rbSfondo.linearVelocity = new Vector2(scrollSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}