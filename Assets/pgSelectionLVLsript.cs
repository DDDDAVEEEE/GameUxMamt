using UnityEngine;

public class pgSelectionLVLsript : MonoBehaviour
{
    
    public Vector2[] positions = new Vector2[3]; // Tre posizioni predefinite
    private int currentIndex = -3; // Indice della posizione attuale

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentIndex = Mathf.Clamp(currentIndex + 1, 0, positions.Length - 1); // Avanza
            transform.position = positions[currentIndex];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentIndex = Mathf.Clamp(currentIndex - 1, 0, positions.Length - 1); // Torna indietro
            transform.position = positions[currentIndex];
        }
    }


}
