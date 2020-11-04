using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoEvolui : Inimigo
{
    private bool evolui = false;
    private float vidaTotal;

    private void InimigoEvo()
    {
        if (vidaTotal - vida >= 3.0)
        {
            evolui = true;
        }
        else
        {
            evolui = false;
        }
    }

    private void Animacao()
    {
        GetComponent<Animator>().SetBool("evoluido", evolui);
    }

    void Start()
    {
        vidaTotal = vida;
    }

    protected override void Update()
    {
        base.Update();
        InimigoEvo();
        Animacao();
    }
}
