using System.Collections.Generic;
using UnityEngine;

public class EnemigoAtaque : MonoBehaviour
{
    private Transform Objetivo;
    private TropaMovimiento tm;
    public Vector3? ObjetivoAnterior;
    public float Daño;
    private float IntervaloDaño;
    public bool atacando = false;
    public float Intervalo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tm = GetComponent<TropaMovimiento>();
        Daño *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Objetivo == null)
        {
            atacando = false;
            EncontrarObjetivo();
        }
        else
        {

            if (!Objetivo.gameObject.activeInHierarchy)
            {
                Objetivo = null;
                atacando = false;
            }
        }

        

        IrHaciaObjetivo();

        //tm.agent.isStopped = atacando;

    }

    private void EncontrarObjetivo()
    {
        string[] tags = { "TropaEspadachin", "TropaArquero", "TropaRecolector", "TropaTanque" };
        List<GameObject> objetivosPosibles = new List<GameObject>();

        foreach (string tag in tags)
        {
            GameObject[] encontrados = GameObject.FindGameObjectsWithTag(tag);
            objetivosPosibles.AddRange(encontrados);
        }

        foreach (GameObject Obj in objetivosPosibles)
        {
            float distancia = Vector3.Distance(Obj.transform.position, transform.position);
            if (distancia < 25)
            {
                Objetivo = Obj.transform;
            }
        }
    }

    private void IrHaciaObjetivo()
    {
        if (Objetivo != null)
        {
            tm.target = Objetivo;
        }
        else if (ObjetivoAnterior.HasValue)
        {
            tm.agent.SetDestination(ObjetivoAnterior.Value);

            if (Vector3.Distance(transform.position, ObjetivoAnterior.Value) < 0.8)
            {
                ObjetivoAnterior = null;
            }

        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("TropaEspadachin") || collision.gameObject.CompareTag("TropaArquero")|| collision.gameObject.CompareTag("TropaTanque"))
        {
            atacando = true;
            
            Tropa tp = collision.gameObject.GetComponent<Tropa>();

            if (IntervaloDaño < Intervalo)
            {
                IntervaloDaño += Time.deltaTime;
            }
            else
            {
                
                tp.CambiarVida(Daño);
                IntervaloDaño = 0f;
            }
        }
        

        if (collision.gameObject.CompareTag("BaseAliada"))
        {
            atacando = true;
            Base bs = collision.gameObject.GetComponent<Base>();
            if (IntervaloDaño < 1f)
            {
                IntervaloDaño += Time.deltaTime;
            }
            else
            {
                
                bs.CambioVida(Daño);
                IntervaloDaño = 0f;
            }
        }
        
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("TropaEspadachin") || collision.gameObject.CompareTag("TropaArquero") || collision.gameObject.CompareTag("BaseAliada"))
        {
            atacando = false;
            
        }
    }
}

