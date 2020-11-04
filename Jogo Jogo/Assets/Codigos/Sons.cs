using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons : MonoBehaviour
{
    public AudioClip somVida, somMoeda, somEsmeralda, somDano;

    public void TocarVida()
    {
        GetComponent<AudioSource>().clip = somVida;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }

     public void TocarMoeda()
    {
        GetComponent<AudioSource>().clip = somMoeda;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }

     public void TocarEsmeralda()
    {
        GetComponent<AudioSource>().clip = somEsmeralda;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }

     public void TocarDano()
    {
        GetComponent<AudioSource>().clip = somDano;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }
}
