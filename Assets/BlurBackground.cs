using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlurBackground : MonoBehaviour
{
    public RawImage blurImage;
    public Material blurMaterial;

    public void ShowBlur()
    {
        StartCoroutine(CaptureAndBlur());
    }

    IEnumerator CaptureAndBlur()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenTex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenTex.Apply();

        blurImage.texture = screenTex;
        blurImage.material = blurMaterial;
        blurImage.gameObject.SetActive(true);
    }

    public void HideBlur()
    {
        blurImage.gameObject.SetActive(false);
    }
}
