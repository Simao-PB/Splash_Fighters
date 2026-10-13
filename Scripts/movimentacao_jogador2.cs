using UnityEngine;

public class movimentacao_jogador2 : MonoBehaviour
{
    public float velocidade = 5f;
    public GameObject balaPrefab;
    public Transform tiro;

    private Vector2 direcao = Vector2.down;
    private Rigidbody2D rb;
    private Vector2 movimento;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movimento = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movimento = Vector2.up;
            direcao = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movimento = Vector2.down;
            direcao = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimento = Vector2.left;
            direcao = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movimento = Vector2.right;
            direcao = Vector2.right;
        }

        AtualizarPosicaoDoTiro();

        if (Input.GetMouseButtonDown(1))
        {
            Disparar();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movimento * velocidade;
    }

    void AtualizarPosicaoDoTiro()
    {
        if (direcao == Vector2.up)
        {
            tiro.localPosition = new Vector3(0f, 0.3f, 0f);
            tiro.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (direcao == Vector2.down)
        {
            tiro.localPosition = new Vector3(0f, -0.3f, 0f);
            tiro.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (direcao == Vector2.left)
        {
            tiro.localPosition = new Vector3(-0.3f, 0f, 0f);
            tiro.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (direcao == Vector2.right)
        {
            tiro.localPosition = new Vector3(0.3f, 0f, 0f);
            tiro.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
    }

    void Disparar()
    {
        Instantiate(balaPrefab, tiro.position, tiro.rotation);

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    public Vector2 ObterDirecao()
    {
        return direcao;
    }
}