using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class sistemacoll : MonoBehaviour
{
    public bool col1, col2, col3;
    public Animator anim1, anim2, anim3;
    public TextMeshProUGUI tit1, tit2, tit3, text1, text2, text3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col1 = PlayerPrefs.GetInt("col1")==1;
        col2 = PlayerPrefs.GetInt("col2")==1;
        col3 = PlayerPrefs.GetInt("col3")==1;
        
        if (!col1)
        {
            anim1.SetBool("Nascoste",true);
            tit1.text = "???";
            text1.text = "???";
        }
        else
        {
            anim1.SetBool("Nascoste",false);
            tit1.text = "Cuffie da gaming";
            text1.text = "Cuffie che usava da piccola quando giocava con suo fratello, le manca perdere contro di lui.";
        }
        if(!col2){
            anim2.SetBool("Nascoste",true);
            tit2.text = "???";
            text2.text = "???";
        }else{
            anim2.SetBool("Nascoste",false);
            tit2.text = "Mic da registrazione";
            text2.text = "Il primo microfono che ha usato per registrare le sue canzoni, un regalo di sua madre.";
        }
        if(!col3){
            anim3.SetBool("Nascoste",true);
            tit3.text = "???";
            text3.text = "???";
        }else{
            anim3.SetBool("Nascoste",false);
            tit3.text = "Mix-Tape";
            text3.text = "Dono di compleanno da una sua amica, contiene una canzone per ogni stagione passate insieme";
        }
    }

    public void scoperto(int codice){
        switch(codice)
        {
            case 1: col1 = true;
            break;
            case 2: col2 = true;
            break;
            case 3: col3 = true;
            break;
        }
    }
    // Update is called once per frame
}
