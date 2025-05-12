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
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime * speed;
        }
        else if (Input.GetKey(sinistra))
        {
            speed += 1;
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime * speed;
        }

        if (Input.GetKeyDown(destra))
        {
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime * speed;
        }
        else if (Input.GetKey(destra))
        {
            speed -= 1;
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime * speed;

        }

        if (!(Input.GetKey(sinistra) || Input.GetKey(destra)))
        {
            if (speed < -1|| speed > 1)
            {
                speed = speed - speed / attrito;
            }
            else if (speed < 1||speed > -1)
            {
                speed = 0;
            }
            transform.eulerAngles += new Vector3(0, 0, rotazione) * Time.deltaTime * speed;
        }
    }
}
