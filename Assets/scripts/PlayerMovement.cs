using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 30f;
    private Diretor diretor;
    private Vector3 posicaoInicial;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int jumpCount = 0;
    public int maxJumps = 2;

    // Controles para toque (celular)
    private float moveDirection = 0f;
    private bool jumpPressed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.diretor = GameObject.FindFirstObjectByType<Diretor>();
        this.posicaoInicial = this.transform.position;
    }

    void Update()
    {
        // Movimento lateral
        float input = Input.GetAxisRaw("Horizontal"); // teclado
        float totalMove = input + moveDirection;      // soma com toque
        totalMove = Mathf.Clamp(totalMove, -1f, 1f);   // evita ultrapassar -1 ou 1
        rb.linearVelocity = new Vector2(totalMove * speed, rb.linearVelocity.y);

        // Pulo teclado ou toque
        if ((Input.GetKeyDown(KeyCode.Space) || jumpPressed) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
            jumpPressed = false; // resetar ap�s pulo
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obs"))
        {
            this.rb.simulated = false;
            this.diretor.FinalizarJogo();
            GameObject.FindFirstObjectByType<Pontuacao>().JogadorMorreu();
        }
    }

    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.rb.simulated = true;
    }

    // ?? M�TODOS PARA BOT�ES DE TOQUE

    public void MoverEsquerda(bool pressionado)
    {
        moveDirection = pressionado ? -1f : 0f;
    }

    public void MoverDireita(bool pressionado)
    {
        moveDirection = pressionado ? 1f : 0f;
    }

    public void Pular()
    {
        jumpPressed = true;
    }
}
