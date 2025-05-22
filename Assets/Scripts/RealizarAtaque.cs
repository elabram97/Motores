using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RealizarAtaque : MonoBehaviour
{
    private float IntervaloAtaque;
    private Transform BaseAliada;
    void Start()
    {
        IntervaloAtaque = 60f;
        BaseAliada = GameObject.FindGameObjectWithTag("BaseAliada").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(IntervaloAtaque > 0)
        {
            IntervaloAtaque -= Time.deltaTime;
        }
        else
        {
            IntervaloAtaque = 60f;
            RealizarAtaqueContraBase();
        }
    }

    private void RealizarAtaqueContraBase()
    {
        AtaqueArqueroEnemigo[] TropasEnemigas = FindObjectsByType<AtaqueArqueroEnemigo>(FindObjectsSortMode.None);
        EnemigoAtaque[] TropasEnemigasEspada = FindObjectsByType<EnemigoAtaque>(FindObjectsSortMode.None);

        List<TropaMovimiento> TodasLasTropas = new List<TropaMovimiento>();

        foreach (var Tropas in TropasEnemigas)
        {
            TodasLasTropas.Add(Tropas.GetComponent<TropaMovimiento>());
        }

        foreach (var Tropas in TropasEnemigasEspada)
        {
            TodasLasTropas.Add(Tropas.GetComponent<TropaMovimiento>());
        }

        if(TodasLasTropas.Count > 0)
        {
            foreach (var tlt in TodasLasTropas)
            {
                tlt.target = BaseAliada;
            }
        }
        else
        {
            Debug.Log("No existen tropas actualmente");
        }

    }
}
