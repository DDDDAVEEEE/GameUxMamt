using UnityEngine;

public class ScrollPavimentoScript : MonoBehaviour
{

    private float scrollSpeed=-1f;
    public float depthFactor = 0.5f;
    void Start()
    {
        depthFactor = 3;
    }

    // Update is called once per frame
    void Update()
    {
    transform.position += new Vector3(scrollSpeed * depthFactor * Time.deltaTime, 0, 0);
    }

}
