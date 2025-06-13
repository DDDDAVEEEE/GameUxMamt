using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;

public class SparatoreDritto : MonoBehaviour
{
    public GameObject Proiettile;
    public Transform pos;
    private float timer;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pos = GetComponent<Transform>();
    }

    private void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 20)
        {
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                timer = 0;
                shoot();
            }
        }
        
    }

    void shoot()
    {
        Instantiate(Proiettile, pos.position, Quaternion.identity);
    }
}
