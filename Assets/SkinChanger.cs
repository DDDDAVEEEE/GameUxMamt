using UnityEngine;
using UnityEngine.UI;

public class SkinChangerUI : MonoBehaviour
{
    public Sprite[] skins;           // Le skin da usare
    //public string[] skinNames; 
    public Image imageComponent;     // Il componente Image UI
    //dpublic Text labelText;
    private int currentIndex = 0;

    void Start()
    {
        ChangeSkin(0);
    }

    public void ChangeSkin(int index)
    {
        if (index >= 0 && index < skins.Length)
        {
            imageComponent.sprite = skins[index];
            //labelText.text = skinNames[index];
            currentIndex = index;
        }
    }

    public void NextSkin()
    {
        int nextIndex = (currentIndex + 1) % skins.Length;
        ChangeSkin(nextIndex);
    }

    public void PreviousSkin()
    {
        int prevIndex = (currentIndex - 1 + skins.Length) % skins.Length;
        ChangeSkin(prevIndex);
    }
}
