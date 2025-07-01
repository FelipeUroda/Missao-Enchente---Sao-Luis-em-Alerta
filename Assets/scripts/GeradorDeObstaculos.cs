using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float TempoParaGerar;
    [SerializeField]
    private GameObject ManualDeInstrucoes;
    private float cronometro;

    private void Awake()
    {
        this.cronometro = this.TempoParaGerar;
    }

    void Update()
    {
        this.cronometro -= Time.deltaTime;
        if (this.cronometro < 0)
        {
            GameObject.Instantiate(this.ManualDeInstrucoes, this.transform.position, Quaternion.identity);
            this.cronometro = this.TempoParaGerar;
        }
    }
}
