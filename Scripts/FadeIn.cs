using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEntrada : MonoBehaviour
{
    public Image fadeImage;
    public float duracaoFade = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float tempo = 0f;

        while (tempo < duracaoFade)
        {
            tempo += Time.deltaTime;
            float alpha = 1f - (tempo / duracaoFade);

            fadeImage.color = new Color(0, 0, 0, alpha);

            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }
}