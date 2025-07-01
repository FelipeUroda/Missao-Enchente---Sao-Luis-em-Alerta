using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    [SerializeField]
    public Text textoPontuacao;
    public float pontos = 0;
    public float velocidadeDePontos = 1f;
    public bool jogadorVivo = true;

    public void zerarPontuacao()
    {
        pontos = 0;
        textoPontuacao.text = 0.ToString();
        jogadorVivo = true;
    }

    void Update()
    {
        if (jogadorVivo)
        {
            pontos += velocidadeDePontos * Time.deltaTime;
            textoPontuacao.text = Mathf.FloorToInt(pontos).ToString();
        }
    }

    public void JogadorMorreu()
    {
        jogadorVivo = false;
    }
}
