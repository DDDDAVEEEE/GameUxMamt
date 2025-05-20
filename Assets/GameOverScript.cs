using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Riprova()
    {
        SceneManager.LoadSceneAsync(5);
    } 
    public void tornaAllaHome()
    {
        SceneManager.LoadSceneAsync(0);
    }   
}
