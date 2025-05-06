using UnityEngine;
using UnityEngine.SceneManagement;

public class MainOptionScript : MonoBehaviour
{
    public void ReturnToMenuCustom()
    {
        SceneManager.LoadSceneAsync(0);//Personalizzazione pg
    }
}
