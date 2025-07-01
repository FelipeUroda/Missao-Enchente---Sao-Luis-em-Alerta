using UnityEngine;

public class Piso : MonoBehaviour
{
    [SerializeField] private float velocidade = 1.5f; 
    private Vector3 posicaoInicial;
    private float larguraRealDoSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        posicaoInicial = transform.position;

        // Calcula a largura total do sprite (considerando a escala).
        larguraRealDoSprite = spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        // Movimenta o chão infinitamente (usando Mathf.Repeat para loop suave).
        float deslocamento = Mathf.Repeat(Time.time * velocidade, larguraRealDoSprite);
        transform.position = posicaoInicial + Vector3.left * deslocamento;
    }
}
