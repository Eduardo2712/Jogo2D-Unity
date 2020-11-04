using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Painel : MonoBehaviour
{
    public Text textoPausa;
    public List<Image> listaVida = new List<Image>();
    public List<Image> listaEnergia = new List<Image>();
    public Text nMoedas;
    public GameObject painelCristais;
    public GameObject cristalVermelho, cristalRoxo, cristalBranco, cristalVerde, cristalAzul;
    public ParametrosJogador parametrosJogador;
    public int nCristais = 0;

    private void VerificaVidas()
    {
        int i = 0;
        while (i < listaVida.Count)
        {
            if (i < parametrosJogador.vidas)
            {
                listaVida[i].enabled = true;
                listaVida[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                listaVida[i].enabled = true;
                listaVida[i].GetComponent<Image>().color = Color.black;
                if (i >= parametrosJogador.nVidaTotal)
                {
                    listaVida[i].enabled = false;
                }
            }
            i++;
        }
        i = 0;
    }

    private void VerificaEnergia()
    {
        int i = 0;
        while (i < listaEnergia.Count)
        {
            if (i < parametrosJogador.energia)
            {
                listaEnergia[i].enabled = true;
                listaEnergia[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                listaEnergia[i].enabled = true;
                listaEnergia[i].GetComponent<Image>().color = Color.black;
                if (i >= parametrosJogador.nEnergiaTotal)
                {
                    listaEnergia[i].enabled = false;
                }
            }
            i++;
        }
        i = 0;
    }

    private void VerificaMoedas()
    {
        nMoedas.text = "X" + parametrosJogador.moedas;
    }
    private void CristaisDesativa()
    {
        cristalAzul.GetComponent<Image>().color = Color.black;
        cristalBranco.GetComponent<Image>().color = Color.black;
        cristalRoxo.GetComponent<Image>().color = Color.black;
        cristalVerde.GetComponent<Image>().color = Color.black;
        cristalVermelho.GetComponent<Image>().color = Color.black;
    }

    public IEnumerator PiscaCristais()
    {
        painelCristais.SetActive(true);
        cristalAzul.GetComponent<Image>().color = Color.black;
        cristalBranco.GetComponent<Image>().color = Color.black;
        cristalRoxo.GetComponent<Image>().color = Color.black;
        cristalVerde.GetComponent<Image>().color = Color.black;
        cristalVermelho.GetComponent<Image>().color = Color.black;
        yield return new WaitForSeconds(0.2f);
        cristalAzul.GetComponent<Image>().color = Color.white;
        cristalBranco.GetComponent<Image>().color = Color.white;
        cristalRoxo.GetComponent<Image>().color = Color.white;
        cristalVerde.GetComponent<Image>().color = Color.white;
        cristalVermelho.GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        cristalAzul.GetComponent<Image>().color = Color.black;
        cristalBranco.GetComponent<Image>().color = Color.black;
        cristalRoxo.GetComponent<Image>().color = Color.black;
        cristalVerde.GetComponent<Image>().color = Color.black;
        cristalVermelho.GetComponent<Image>().color = Color.black;
        yield return new WaitForSeconds(0.2f);
        cristalAzul.GetComponent<Image>().color = Color.white;
        cristalBranco.GetComponent<Image>().color = Color.white;
        cristalRoxo.GetComponent<Image>().color = Color.white;
        cristalVerde.GetComponent<Image>().color = Color.white;
        cristalVermelho.GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        cristalAzul.GetComponent<Image>().color = Color.black;
        cristalBranco.GetComponent<Image>().color = Color.black;
        cristalRoxo.GetComponent<Image>().color = Color.black;
        cristalVerde.GetComponent<Image>().color = Color.black;
        cristalVermelho.GetComponent<Image>().color = Color.black;
        yield return new WaitForSeconds(0.2f);
        cristalAzul.GetComponent<Image>().color = Color.white;
        cristalBranco.GetComponent<Image>().color = Color.white;
        cristalRoxo.GetComponent<Image>().color = Color.white;
        cristalVerde.GetComponent<Image>().color = Color.white;
        cristalVermelho.GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        cristalAzul.GetComponent<Image>().color = Color.black;
        cristalBranco.GetComponent<Image>().color = Color.black;
        cristalRoxo.GetComponent<Image>().color = Color.black;
        cristalVerde.GetComponent<Image>().color = Color.black;
        cristalVermelho.GetComponent<Image>().color = Color.black;
        yield return new WaitForSeconds(0.2f);
        cristalAzul.GetComponent<Image>().color = Color.white;
        cristalBranco.GetComponent<Image>().color = Color.white;
        cristalRoxo.GetComponent<Image>().color = Color.white;
        cristalVerde.GetComponent<Image>().color = Color.white;
        cristalVermelho.GetComponent<Image>().color = Color.white;
        painelCristais.SetActive(false);
    }

    public IEnumerator MostraCristais()
    {
        painelCristais.SetActive(true);
        yield return new WaitForSeconds(2f);
        painelCristais.SetActive(false);
    }

    void Start()
    {
        parametrosJogador.nVidaTotal = parametrosJogador.vidas;
        parametrosJogador.nEnergiaTotal = parametrosJogador.energia;
        VerificaVidas();
        VerificaEnergia();
        CristaisDesativa();
        painelCristais.SetActive(false);
    }

    void Update()
    {
        VerificaVidas();
        VerificaEnergia();
        VerificaMoedas();
    }
}
