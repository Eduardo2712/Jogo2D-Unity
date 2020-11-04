using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSimples : Inimigo
{
    public GameObject pos1, pos2;
    public bool parado;

    private void Andar()
    {
        if (parado == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(direcao * velocidade, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void FixedUpdate()
    {
        Andar();
    }

    private void OnDrawGizmos()
    {
        if (parado == false)
        {
            Gizmos.DrawLine(pos1.transform.position, pos2.transform.position);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Limite") == true)
        {
            Flip();
        }
    }

    void Start()
    {
        direcao = 1;
    }

    protected override void Update()
    {
        base.Update();
    }
}
