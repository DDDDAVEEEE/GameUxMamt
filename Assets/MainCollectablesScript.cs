using UnityEngine;
using UnityEngine.SceneManagement;
public class MainCollectablesScript : MonoBehaviour
{
   public void ReturnToMenuCustom()
    {
        SceneManager.LoadSceneAsync(0);//Home
    }
}
