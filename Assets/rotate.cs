using UnityEngine;

public class rotate : MonoBehaviour
{
    public KeyCode sinistra;
    public KeyCode destra;
    public float rotazione = 5f;
    public float speed = 0;
    public float attrito = 50;

    void Update()
    {
        if (Input.GetKeyDown(sinistra))
        {
            speed +=10;
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime * speed;
        }

        if (Input.GetKeyDown(destra))
        {
            speed -=10;
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime *speed;
        }

        if (!(Input.GetKey(sinistra) || Input.GetKey(destra)))
        {
            if (speed < -0.1|| speed > 0.1)
            {
                speed *= attrito;
            }
            else if (speed < 0.1||speed > - 0.1)
            {
                speed = 0;
            }
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime * speed;
        }
    }
}
