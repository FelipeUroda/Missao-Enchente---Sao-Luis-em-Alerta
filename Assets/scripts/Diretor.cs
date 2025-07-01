using UnityEngine;

public class Diretor : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemGameOver;
    [SerializeField]
    private GameObject imagemInicio;
    private PlayerMovement playerMovement;
    private Pontuacao pontuacao;

    private void Awake()
    {
        this.imagemInicio.SetActive(true);
        Time.timeScale = 0;
    }

    private void Start()
    {
        this.playerMovement = GameObject.FindFirstObjectByType<PlayerMovement>();
        this.pontuacao = GameObject.FindFirstObjectByType<Pontuacao>();
    }
    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.imagemGameOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        this.imagemGameOver.SetActive(false);
        Time.timeScale = 1;
        this.pontuacao.zerarPontuacao();
        this.playerMovement.Reiniciar();
        this.DestruirObstaculos();
        
    }

    public void DestruirObstaculos()
    {
        GameObject.FindAnyObjectByType<ObstaculoP>().Destruir();
        GameObject.FindAnyObjectByType<ObstaculoC>().Destruir();
    }

    public void IniciarJogo()
    {
        Time.timeScale = 1;
        this.imagemInicio.SetActive(false);
    }
}
