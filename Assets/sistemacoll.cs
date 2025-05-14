using TMPro;
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
        if(col1==false){
            col1 = false;
            anim1.Play("vuoto");
            tit1.text = "???";
            text1.text = "???";
        }else{
            anim1.Play("cuffie");
            tit1.text = "Cuffie da gaming";
            text1.text = "Trovare da scrivere";
        }
        if(!col2){
            col2 = false;
            anim2.Play("vuoto");
            tit2.text = "???";
            text2.text = "???";
        }else{
            anim1.Play("microfono");
            tit2.text = "Mic da registrazione";
            text2.text = "Trovare da scrivere";
        }
        if(!col3){
            col3 = false;
            anim3.Play("vuoto");
            tit3.text = "???";
            text3.text = "???";
        }else{
            anim3.Play("cassetta");
            tit3.text = "Mix-Tape";
            text3.text = "Trovare da scrivere";
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
    void Update()
    {
        if(col1==false){
            col1 = false;
            anim1.Play("vuoto");
            tit1.text = "???";
            text1.text = "???";
        }else{
            anim1.Play("cuffie");
            tit1.text = "Cuffie da gaming";
            text1.text = "Trovare da scrivere";
        }
        if(!col2){
            col2 = false;
            anim2.Play("vuoto");
            tit2.text = "???";
            text2.text = "???";
        }else{
            anim1.Play("microfono");
            tit2.text = "Mic da registrazione";
            text2.text = "Trovare da scrivere";
        }
        if(!col3){
            col3 = false;
            anim3.Play("vuoto");
            tit3.text = "???";
            text3.text = "???";
        }else{
            anim3.Play("cassetta");
            tit3.text = "Mix-Tape";
            text3.text = "Trovare da scrivere";
        }
    }
}
