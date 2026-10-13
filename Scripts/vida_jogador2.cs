using UnityEngine;
using System.Collections;

public class vida_jogador2 : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaAtual;

    public AudioSource audioHit;
    public AudioSource audioMorte;

    private Animator animator;
    private movimentacao_jogador2 movimento;
    private animacao_jogador2 animacao;

    void Start()
    {
        vidaAtual = vidaMaxima;
        animator = GetComponent<Animator>();
        movimento = GetComponent<movimentacao_jogador2>();
        animacao = GetComponent<animacao_jogador2>();
    }

    public void LevarDano(int dano)
    {
        if (vidaAtual <= 0) return;

        vidaAtual -= dano;

        if (audioHit != null && audioHit.clip != null)
        {
            audioHit.Stop();
            audioHit.PlayOneShot(audioHit.clip);
        }

        if (vidaAtual < 0)
        {
            vidaAtual = 0;
        }

        Debug.Log(gameObject.name + " levou dano. Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        StartCoroutine(MorrerCoroutine());
    }

    private IEnumerator MorrerCoroutine()
    {
        if (movimento != null)
            movimento.enabled = false;

        if (animacao != null)
            animacao.morto = true;

        Vector2 direcao = movimento.ObterDirecao();

        if (animator != null)
        {
            if (direcao == Vector2.up)
                animator.Play("death_north_2", 0, 0f);
            else if (direcao == Vector2.down)
                animator.Play("death_back_2", 0, 0f);
            else if (direcao == Vector2.left)
                animator.Play("death_left_2", 0, 0f);
            else if (direcao == Vector2.right)
                animator.Play("death_right_2", 0, 0f);
        }

        yield return new WaitForSeconds(0.45f);

        if (audioMorte != null && audioMorte.clip != null)
        {
            audioMorte.Stop();
            audioMorte.PlayOneShot(audioMorte.clip);
        }

        FindObjectOfType<fim_do_jogo>().Jogador1Venceu(); 

        yield return new WaitForSeconds(audioMorte.clip.length);

        gameObject.SetActive(false);
    }

    void Desativar()
    {
        gameObject.SetActive(false);
    }

    public int ObterVidaAtual()
    {
        return vidaAtual;
    }
}