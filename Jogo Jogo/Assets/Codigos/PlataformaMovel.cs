using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public Transform pos1, pos2;
    public float velocidade;
    public Transform pontoInicial;

    private Vector3 proxPosicao;

    // Start is called before the first frame update
    void Start()
    {
        proxPosicao = pontoInicial.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position == pos1.position)
        {
            proxPosicao = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            proxPosicao = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, proxPosicao, velocidade * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
