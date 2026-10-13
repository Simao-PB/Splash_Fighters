using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fim_do_jogo : MonoBehaviour
{
    public Image resultadoImagem;
    public Sprite imagemVitoriaP1;
    public Sprite imagemVitoriaP2;
    public GameObject botaoRejogar;

    public GameObject vidasJogador1;
    public GameObject vidasJogador2;

    public movimentacao_jogador jogador1Mov;
    public movimentacao_jogador2 jogador2Mov;

    public animacao_jogador jogador1Anim;
    public animacao_jogador2 jogador2Anim;

    public Animator animatorJogador1;
    public Animator animatorJogador2;

    private bool jogoTerminou = false;

    void Update()
    {
        if (jogoTerminou && Input.GetKeyDown(KeyCode.F))
        {
            JogarNovamente();
        }
    }

    public void Jogador1Venceu()
    {
        jogoTerminou = true;

        jogador1Mov.enabled = false;
        jogador2Mov.enabled = false;

        jogador1Anim.morto = true;
        jogador2Anim.morto = true;

        vidasJogador1.SetActive(false);
        vidasJogador2.SetActive(false);

        animatorJogador1.Play("victory_p1", 0, 0f);

        resultadoImagem.gameObject.SetActive(true);
        resultadoImagem.sprite = imagemVitoriaP1;

        botaoRejogar.SetActive(true);
    }

    public void Jogador2Venceu()
    {
        jogoTerminou = true;

        jogador1Mov.enabled = false;
        jogador2Mov.enabled = false;

        jogador1Anim.morto = true;
        jogador2Anim.morto = true;

        vidasJogador1.SetActive(false);
        vidasJogador2.SetActive(false);

        animatorJogador2.Play("victory_p2", 0, 0f);

        resultadoImagem.gameObject.SetActive(true);
        resultadoImagem.sprite = imagemVitoriaP2;

        botaoRejogar.SetActive(true);
    }

    public void JogarNovamente()
    {
        Debug.Log("Botão clicado");
        SceneManager.LoadScene("selecionar_mapa");
    }
}