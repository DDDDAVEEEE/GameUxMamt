using UnityEngine;

public class HoverOption : MonoBehaviour
{
    public GameObject pulsante;
    public GameObject collisione;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pulsante.GetComponent<Animator>();
        collisione.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
