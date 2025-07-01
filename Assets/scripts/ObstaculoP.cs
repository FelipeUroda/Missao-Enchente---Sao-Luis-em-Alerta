using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoP : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    private void Update()
    {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        this.Destruir();
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
