using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
public class SkinSelector : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public GameObject lucchetto;
    public string[] skinNames;
    public TMP_Text nameText;
    private int currentIndex = 0;
    private bool blocked = false;
    void Start()
    {
        lucchetto.SetActive(false);
        UpdateSkinDisplay();
    }

    public void Next()
    {
        currentIndex = (currentIndex + 1) % skins.Count;
        if (currentIndex == 4) currentIndex = 0;
        UpdateSkinDisplay();
    }

    public void Previous()
    {
        currentIndex = (currentIndex - 1 + skins.Count) % skins.Count;
        if (currentIndex == 4) currentIndex = 3;
        UpdateSkinDisplay();
    }

    public void ConfirmAndPlay()
    {
        if (!blocked)
        {
            PlayerPrefs.SetInt("SelectedSkin", currentIndex);
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync(4);//Selezione livello
        }
    }
    public void ReturnToMenuCustom()
    {
        SceneManager.LoadSceneAsync(0);//Personalizzazione pg
    }

    private void UpdateSkinDisplay()
    {
        switch (currentIndex)
        {
            case 0:
                sr.sprite = skins[currentIndex];
                nameText.text = skinNames[currentIndex];
                blocked = false;
                break;
            case 1:
                if (PlayerPrefs.GetInt("skin1") != 1)
                {
                    sr.sprite = skins[4];
                    nameText.text = skinNames[4];
                    blocked = true;
                }
                else
                {
                    sr.sprite = skins[currentIndex];
                    nameText.text = skinNames[currentIndex];
                    blocked = false;
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("skin2") != 1)
                {
                    sr.sprite = skins[4];
                    nameText.text = skinNames[4];
                    blocked = true;
                }
                else
                {
                    sr.sprite = skins[currentIndex];
                    nameText.text = skinNames[currentIndex];
                    blocked = false;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("skin3") != 1)
                {
                    sr.sprite = skins[4];
                    nameText.text = skinNames[4];
                    blocked = true;
                }
                else
                {
                    sr.sprite = skins[currentIndex];
                    nameText.text = skinNames[currentIndex];
                    blocked = false;
                }
                break;
        }
        if(blocked) lucchetto.SetActive(true);
        else lucchetto.SetActive(false);
        Debug.Log("Skin Index: " + currentIndex);
        Debug.Log("Nome sprite: " + skins[currentIndex]?.name);
    }
}