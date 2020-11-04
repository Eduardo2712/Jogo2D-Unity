using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int direcao;
    public float vida;
    public float velocidade;
    public int dano;
    public Vector3 posicao = new Vector3();
    public GameObject fumaca;

    protected bool estaNaDireita = true;

    private void Morre()
    {
        if (vida <= 0)
        {
            gameObject.SetActive(false);
            GameObject fumacaAux = Instantiate(fumaca, transform.position, transform.rotation);
            Destroy(fumacaAux, 0.5f);
        }
    }

    protected void Flip()
    {
        estaNaDireita = !estaNaDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    protected void Direcao()
    {
        if (estaNaDireita == true)
        {
            direcao = 1;
        }
        else
        {
            direcao = -1;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Tiro") == true)
        {
            vida -= GetComponent<Tiro>().dano;
            Destroy(other);
        }
    }

    protected IEnumerator Dano()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Start()
    {

    }

    protected virtual void Update()
    {
        Direcao();
        Morre();
    }
}
