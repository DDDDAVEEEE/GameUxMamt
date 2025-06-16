using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;

public class SparatoreDritto : MonoBehaviour
{
    private Animator anim;
    private bool dead;
    public GameObject Proiettile;
    public Transform pos;
    private float timer;
    public float frequenza;
    public BoxCollider2D bc;
    public BoxCollider2D player;
    private bool turned = false;
    public bool fisso;
    public float speed = 0;
    public float raggio = 10;

    private void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        pos = GetComponent<Transform>();
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = bc.Distance(player).distance;
        if (distance < raggio &&!dead && !(fisso&&transform.position.x - player.transform.position.x < 0))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            timer += Time.deltaTime;
            if (timer > frequenza)
            {
                
                timer = 0;
                shoot();
            }
        }
        if (transform.position.x - player.transform.position.x < 0 && !fisso && !turned)
        {
            quaternion rot = pos.rotation;
            GetComponent<SpriteRenderer>().flipX = true;
            pos.SetPositionAndRotation(new Vector3(-pos.position.x, pos.position.y, pos.position.z), rot);
            turned = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Attacco")
        {
            //inserire animazione
            anim.SetBool("isDead", true);
            dead = true; 
            //StartCoroutine(Morte());
        }

    }

    void shoot()
    {
        Instantiate(Proiettile, pos.position, Quaternion.identity);
    }
}
