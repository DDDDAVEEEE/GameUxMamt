using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public KeyCode yomama;
    public Button idk;
    void Start()
    {
        idk = GetComponent<Button>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(yomama))
        {
            idk.onClick.Invoke();
        }
     }
}
