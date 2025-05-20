using UnityEngine;

public class ScrollSfondoScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public float scrollSpeed=-1f;
    public float depthFactor = 3;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(scrollSpeed * depthFactor * Time.deltaTime, 0, 0);
    }
}
