using UnityEngine;

public class animacao_jogador : MonoBehaviour
{
    private Animator animator;
    private movimentacao_jogador movimento;
    public bool morto = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        movimento = GetComponent<movimentacao_jogador>();
    }

    void Update()
    {
        if(morto) return;

        bool aMexer =
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D);

        Vector2 direcao = movimento.ObterDirecao();

        if (aMexer)
        {
            if (direcao == Vector2.up)
                animator.Play("run_front");
            else if (direcao == Vector2.down)
                animator.Play("run_back");
            else if (direcao == Vector2.left)
                animator.Play("run_left");
            else if (direcao == Vector2.right)
                animator.Play("run_right");
        }
        else
        {
            if (direcao == Vector2.up)
                animator.Play("idle_front");
            else if (direcao == Vector2.down)
                animator.Play("idle_back");
            else if (direcao == Vector2.left)
                animator.Play("idle_left");
            else if (direcao == Vector2.right)
                animator.Play("idle_right");
        }
    }
}