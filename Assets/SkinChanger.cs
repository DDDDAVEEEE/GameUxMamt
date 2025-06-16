using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Animations;
using System.Collections.Generic;
public class SkinSelector : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    
    public string[] skinNames;
    public TMP_Text nameText;
    private int currentIndex = 0;

    void Start()
    {
        UpdateSkinDisplay();
    }

    public void Next()
    {
        currentIndex = (currentIndex + 1) % skins.Count;
        UpdateSkinDisplay();
    }

    public void Previous()
    {
        currentIndex = (currentIndex - 1 + skins.Count) % skins.Count   ;
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
        sr.sprite = skins[currentIndex];
        nameText.text = skinNames[currentIndex];
        Debug.Log("Skin Index: " + currentIndex);
        Debug.Log("Nome sprite: " + skins[currentIndex]?.name);
    }
}
