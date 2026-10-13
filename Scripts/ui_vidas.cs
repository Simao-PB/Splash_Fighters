using UnityEngine;
using TMPro;

public class ui_vidas : MonoBehaviour
{
    public vida_jogador1 jogador1;
    public vida_jogador2 jogador2;

    public TextMeshProUGUI textoJogador1;
    public TextMeshProUGUI textoJogador2;

    void Update()
    {
        if (jogador1 != null)
        {
            textoJogador1.text = "Jogador 1: " + jogador1.ObterVidaAtual(); 
        }

        if (jogador2 != null)
        {
            textoJogador2.text = "Jogador 2: " + jogador2.ObterVidaAtual();
        }
    }
}