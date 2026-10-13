using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{
    public Image fadeImage;
    public float duracaoFade = 1f;
    public AudioSource audioSource;

    private bool emTransicao = false;

    void Start()
    {
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.transform.SetAsLastSibling(); // mete o fade à frente de tudo
            fadeImage.color = new Color(0, 0, 0, 0);
        }
    }

    public void Jogar()
    {
        if (!emTransicao)
            StartCoroutine(FazerFadeEAcao("selecionar_mapa", false));
    }

    public void SairDoJogo()
    {
        if (!emTransicao)
            StartCoroutine(FazerFadeEAcao("", true));
    }

    IEnumerator FazerFadeEAcao(string nomeCena, bool sair)
    {
        emTransicao = true;

        Debug.Log("Começou fade. sair = " + sair);

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.transform.SetAsLastSibling();

            float tempo = 0f;

            while (tempo < duracaoFade)
            {
                tempo += Time.deltaTime;
                float alpha = Mathf.Clamp01(tempo / duracaoFade);
                fadeImage.color = new Color(0, 0, 0, alpha);
                yield return null;
            }
        }

        Debug.Log("Fade terminou. sair = " + sair);

        if (sair)
        {
#if UNITY_EDITOR
            Debug.Log("A sair do jogo no editor");
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}