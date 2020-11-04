using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Painel painel;
    public Sons sons;
    public List<Tiro> tiros = new List<Tiro>();
    public Transform localtiro;
    public ParametrosJogador parametrosJogador;

    private Transform verificaChao;
    private Vector3 ultimaPosicao = new Vector3();
    private bool abaixado;
    private float tempoPulo;
    private const float TEMPOMAXPULO = 0.3f;
    public static bool estaNoChao;
    private bool pulo = false;
    private bool pulandoAnimacao = false;
    private bool estaNaDireita = true;
    private bool puloDuplo = false;
    private bool impulso = false;
    private const float TEMPOENTREIMPULSOS = 0.5f;
    private float tempoProxImpulso = 0f;
    private bool voar = false;
    private bool invencivel = false;

    private void Animacoes()
    {
        GetComponent<Animator>().SetFloat("velocidade", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        GetComponent<Animator>().SetBool("abaixado", abaixado);
        GetComponent<Animator>().SetBool("pulo", pulandoAnimacao);
        GetComponent<Animator>().SetBool("impulso", impulso);
        GetComponent<Animator>().SetBool("voar", voar);
        voar = false;
    }

    private void Pular()
    {
        if (pulo == true)
        {
            if (Input.GetButton("Jump") == false)
            {
                tempoPulo = 0.0f;
                pulo = false;
                if (parametrosJogador.segundoPulo == true && estaNoChao == false)
                {
                    puloDuplo = true;
                    tempoPulo = Time.timeSinceLevelLoad + TEMPOMAXPULO;
                }
            }
            else if (Input.GetButton("Jump") == true && tempoPulo > Time.timeSinceLevelLoad)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, parametrosJogador.forcaPulo), ForceMode2D.Impulse);
            }
        }
        else if (puloDuplo == true)
        {
            if (Input.GetButton("Jump") == true && tempoPulo > Time.timeSinceLevelLoad && estaNoChao == false)
            {
                voar = true;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, 1.3f), ForceMode2D.Impulse);
            }
            else if (estaNoChao == true)
            {
                puloDuplo = false;
                tempoPulo = 0.0f;
            }
        }
        if (estaNoChao == true)
        {
            pulandoAnimacao = false;
        }
        else if (estaNoChao == false)
        {
            pulandoAnimacao = true;
        }
    }

    private void Botoes()
    {
        if (estaNoChao == true && Input.GetButtonDown("Jump") == true && puloDuplo == false)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, 6), ForceMode2D.Impulse);
            tempoPulo = Time.timeSinceLevelLoad + TEMPOMAXPULO;
            pulo = true;
        }
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 0 && (Input.GetKey(KeyCode.S) == true || Input.GetKey("down") == true))
        {
            abaixado = true;
        }
        else if (Input.GetKey(KeyCode.S) == false && Input.GetKey("down") == false)
        {
            abaixado = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) == true && parametrosJogador.impulso == true && tempoProxImpulso < Time.timeSinceLevelLoad)
        {
            impulso = true;
            tempoProxImpulso = TEMPOENTREIMPULSOS + Time.timeSinceLevelLoad;
        }
        if(Input.GetButtonDown("Fire1") == true)
        {

        }
    }

    private void Impulsao()
    {
        if (impulso == true)
        {
            StartCoroutine(AtivaImpulso());
        }
    }

    private void Flip()
    {
        estaNaDireita = !estaNaDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void Andar()
    {
        if (abaixado == false)
        {
            float direcao = Input.GetAxisRaw("Horizontal");
            if (tempoProxImpulso < Time.timeSinceLevelLoad)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(direcao * parametrosJogador.velocidade, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                if (estaNaDireita == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * parametrosJogador.velocidadeImpulso, GetComponent<Rigidbody2D>().velocity.y), ForceMode2D.Force);
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * parametrosJogador.velocidadeImpulso, GetComponent<Rigidbody2D>().velocity.y), ForceMode2D.Force);
                }
            }
            if (direcao > 0 && estaNaDireita == false)
            {
                Flip();
            }
            else if (direcao < 0 && estaNaDireita == true)
            {
                Flip();
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void VerificaChao()
    {
        estaNoChao = Physics2D.Linecast(transform.position, verificaChao.position, 1 << LayerMask.NameToLayer("Chao"));
    }

    private IEnumerator Dano()
    {
        invencivel = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        invencivel = false;
    }

    private IEnumerator AtivaImpulso()
    {
        yield return new WaitForSeconds(0.4f);
        impulso = false;
    }

    private void MoedasVida()
    {
        if (parametrosJogador.moedas >= 100)
        {
            parametrosJogador.tentativas += 1;
            parametrosJogador.moedas = parametrosJogador.moedas - 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vida") == true && parametrosJogador.vidas < parametrosJogador.nVidaTotal)
        {
            parametrosJogador.vidas += 1;
            sons.TocarVida();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Moeda") == true)
        {
            parametrosJogador.moedas += 1;
            sons.TocarMoeda();
            Destroy(other.gameObject);
            MoedasVida();
        }
        if (other.CompareTag("MoedaDourada") == true)
        {
            parametrosJogador.moedas += 5;
            sons.TocarMoeda();
            Destroy(other.gameObject);
            MoedasVida();
        }
        if(other.CompareTag("CristalVermelho"))
        {
            painel.cristalVermelho.GetComponent<Image>().color = Color.white;
            painel.nCristais += 1;
            sons.TocarEsmeralda();
            Destroy(other.gameObject);
            StartCoroutine(painel.MostraCristais());
        }
        if(other.CompareTag("CristalAzul"))
        {
            painel.cristalAzul.GetComponent<Image>().color = Color.white;
            painel.nCristais += 1;
            sons.TocarEsmeralda();
            Destroy(other.gameObject);
            StartCoroutine(painel.MostraCristais());
        }
        if(other.CompareTag("CristalRoxo"))
        {
            painel.cristalRoxo.GetComponent<Image>().color = Color.white;
            painel.nCristais += 1;
            sons.TocarEsmeralda();
            Destroy(other.gameObject);
            StartCoroutine(painel.MostraCristais());
        }
        if(other.CompareTag("CristalBranco"))
        {
            painel.cristalBranco.GetComponent<Image>().color = Color.white;
            painel.nCristais += 1;
            sons.TocarEsmeralda();
            Destroy(other.gameObject);
            StartCoroutine(painel.MostraCristais());
        }
        if(other.CompareTag("CristalVerde"))
        {
            painel.cristalVerde.GetComponent<Image>().color = Color.white;
            painel.nCristais += 1;
            sons.TocarEsmeralda();
            Destroy(other.gameObject);
            StartCoroutine(painel.MostraCristais());
        }
    }

    private void VerificaCristais()
    {
        if(painel.nCristais >= 5)
        {
            parametrosJogador.tentativas += 1;
            painel.nCristais = 0;
            StartCoroutine(painel.PiscaCristais());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Inimigo") == true && invencivel == false)
        {
            StartCoroutine(Dano());
            parametrosJogador.vidas -= other.gameObject.GetComponent<Inimigo>().dano;
            if (estaNaDireita == true)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000, 0), ForceMode2D.Force);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(2000, 0), ForceMode2D.Force);
            }
        }
    }

    void Start()
    {
        verificaChao = gameObject.transform.Find("VerificaChao");
        ultimaPosicao = transform.position;
    }

    void Update()
    {
        Botoes();
        VerificaChao();
        Animacoes();
        VerificaCristais();
    }

    private void FixedUpdate()
    {
        Impulsao();
        Andar();
        Pular();
    }
}
