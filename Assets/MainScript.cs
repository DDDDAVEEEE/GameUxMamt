using UnityEngine;
using UnityEngine.SceneManagement;
public class MainScript : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);//Personalizzazione pg
    }
    public void CollectiblesGame()
    {
        SceneManager.LoadSceneAsync(3);//Collezionabili 
    }
    public void OptionsGame()
    {
        SceneManager.LoadSceneAsync(2);//Option Game
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
