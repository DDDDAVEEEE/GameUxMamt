using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SkinSelector : MonoBehaviour
{
    public Sprite[] skins;
    public string[] skinNames;
    public Image imageUI;

    public TMP_Text nameText;
    private int currentIndex = 0;

    void Start()
    {
        UpdateSkinDisplay();
    }

    public void Next()
    {
        currentIndex = (currentIndex + 1) % skins.Length;
        UpdateSkinDisplay();
    }

    public void Previous()
    {
        currentIndex = (currentIndex - 1 + skins.Length) % skins.Length;
        UpdateSkinDisplay();
    }

    public void ConfirmAndPlay()
    {
        PlayerPrefs.SetInt("SelectedSkin", currentIndex);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(4);//Selezione livello
    }
    public void ReturnToMenuCustom()
    {
        SceneManager.LoadSceneAsync(0);//Personalizzazione pg
    }

    private void UpdateSkinDisplay()
    {
        imageUI.sprite = skins[currentIndex];

        nameText.text = skinNames[currentIndex];
        Debug.Log("Skin Index: " + currentIndex);
        Debug.Log("Nome sprite: " + skins[currentIndex]?.name);
    }
}
