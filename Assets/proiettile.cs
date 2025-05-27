using UnityEngine;

public class proiettile : MonoBehaviour
{
    private Vector3 direzione;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direzione = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.01f;
        transform.position -= direzione * Time.deltaTime * speed;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Parry" + collider.gameObject.tag);
        if (collider.gameObject.tag == "Shild")
        {
            Destroy(gameObject);
        }
    }
}
