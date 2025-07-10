using UnityEngine;
using UnityEngine.UI;

public class SkinReceiver : MonoBehaviour
{
    public Sprite[] availableSkins;
    public Image imageUI;

    void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedSkin", 0);
        if (index >= 0 && index <= availableSkins.Length)
        {
            imageUI.sprite = availableSkins[index];
        }
        else
        {
            Debug.LogWarning("Indice skin fuori dai limiti.");
        }
    }
}