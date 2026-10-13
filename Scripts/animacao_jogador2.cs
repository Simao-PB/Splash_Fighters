using UnityEngine;

public class animacao_jogador2 : MonoBehaviour
{
    private Animator animator;
    private movimentacao_jogador2 movimento;
    public bool morto = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        movimento = GetComponent<movimentacao_jogador2>();
    }

    void Update()
    {
        if(morto) return;

        bool aMexer =
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow);

        Vector2 direcao = movimento.ObterDirecao();

        if (aMexer)
        {
            if (direcao == Vector2.up)
                animator.Play("run_front_p2");
            else if (direcao == Vector2.down)
                animator.Play("run_back_p2");
            else if (direcao == Vector2.left)
                animator.Play("run_left_p2");
            else if (direcao == Vector2.right)
                animator.Play("run_right_p2");
        }
        else
        {
            if (direcao == Vector2.up)
                animator.Play("idle_front_p2");
            else if (direcao == Vector2.down)
                animator.Play("idle_back_p2");
            else if (direcao == Vector2.left)
                animator.Play("idle_left_p2");
            else if (direcao == Vector2.right)
                animator.Play("idle_right_p2");
        }
    }
}