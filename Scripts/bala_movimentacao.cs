using UnityEngine;

public class bala_movimentacao : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 2f;
    public int dano = 1;

    void Start()
    {
        // destruir a bala depois de X segundos
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // movimento da bala (para a frente)
        transform.position += transform.up * velocidade * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // colisão com paredes
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
            return;
        }

        // colisão com jogadores
        if (other.CompareTag("Player"))
        {
            // tentar jogador 1
            vida_jogador1 vida1 = other.GetComponent<vida_jogador1>();
            if (vida1 != null)
            {
                vida1.LevarDano(dano);
            }

            // tentar jogador 2
            vida_jogador2 vida2 = other.GetComponent<vida_jogador2>();
            if (vida2 != null)
            {
                vida2.LevarDano(dano);
            }

            Destroy(gameObject);
        }
    }
}