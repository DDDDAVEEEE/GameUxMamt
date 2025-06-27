using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainScript2 : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public Button esci;
    public Button start;
    public Button Arrowleft;
    public Button Arrowright;
    void Update()
    {
        if (Input.GetKeyDown(down))
        {
            start.onClick.Invoke();
        }
        if (Input.GetKeyDown(up))
        {
            esci.onClick.Invoke();
        }
        if (Input.GetKeyDown(right))
        {
            Arrowright.onClick.Invoke();
        }
        if (Input.GetKeyDown(left))
        {
             Arrowleft.onClick.Invoke();
        }
        
    }
    public void ConfirmCustomPG()
    {
        SceneManager.LoadSceneAsync(4);//Selezione livello
    }
    public void ReturnToMenuCustom()
    {
        SceneManager.LoadSceneAsync(0);//Personalizzazione pg
    }
}
