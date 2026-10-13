using UnityEngine;
using UnityEngine.UI;

public class ui_coracoes : MonoBehaviour
{
    public vida_jogador1 jogador1;
    public vida_jogador2 jogador2;

    public Image[] coracoesJogador1;
    public Image[] coracoesJogador2;

    public Color corNormal = Color.white;
    public Color corPerdida = new Color(0.4f, 0.4f, 0.4f, 1f);

    void Update()
    {
        AtualizarCoracoes(coracoesJogador1, jogador1.ObterVidaAtual());
        AtualizarCoracoes(coracoesJogador2, jogador2.ObterVidaAtual());
    }

    void AtualizarCoracoes(Image[] coracoes, int vidaAtual)
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            if (i < vidaAtual)
                coracoes[i].color = corNormal;
            else
                coracoes[i].color = corPerdida;
        }
    }
}