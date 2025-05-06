using UnityEngine;
using UnityEngine.SceneManagement;
public class MainScript2 : MonoBehaviour
{
    public void ConfirmCustomPG()
    {
        SceneManager.LoadSceneAsync(4);//Selezione livello
    }
    public void ReturnToMenuCustom()
    {
        SceneManager.LoadSceneAsync(0);//Personalizzazione pg
    }
}
