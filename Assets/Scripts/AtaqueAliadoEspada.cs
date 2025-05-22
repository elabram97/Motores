using System.Collections.Generic;
using UnityEngine;


public class AtaqueAliadoEspada : MonoBehaviour
{
    private float IntervaloDa�o;
    public float Da�o;
    public Transform Objetivo;
    private TropaMovimiento tm;
    public float IntervaloAtaque;
    public bool Atacando = false;
    public Vector3? ObjetivoAnterior;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Da�o *= -1;
        tm = GetComponent<TropaMovimiento>();
    }

    void Update()
    {
        if (Objetivo == null)
        {
            Atacando = false; 
            EncontrarObjetivo();
        }
        else
        {
            
            if (!Objetivo.gameObject.activeInHierarchy)
            {
                Objetivo = null;
                Atacando = false;
            }
        }

       

        IrHaciaObjetivo();

        //tm.agent.isStopped = Atacando;

    }


    public void EncontrarObjetivo()
    {
        string[] tags = { "TropaEnemigo", "BaseEnemiga" };
        List<GameObject> objetivosPosibles = new List<GameObject>();

        foreach (string tag in tags)
        {
            GameObject[] encontrados = GameObject.FindGameObjectsWithTag(tag);
            objetivosPosibles.AddRange(encontrados);
        }

        foreach (GameObject tpe in objetivosPosibles)
        {

            float distancia = Vector3.Distance(tpe.transform.position, transform.position);
            if (distancia < 25)
            {
                ObjetivoAnterior = tm.agent.destination;
                Objetivo = tpe.transform;
            }

        }
    }

    private void IrHaciaObjetivo()
    {
        if (Objetivo != null)
        {
            tm.target = Objetivo;
        }
        else if (ObjetivoAnterior.HasValue) {
            tm.agent.SetDestination(ObjetivoAnterior.Value);

            if (Vector3.Distance(transform.position, ObjetivoAnterior.Value) < 0.8)
            {
                ObjetivoAnterior = null;
            }

        } 
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("TropaEnemigo"))
        {
            Atacando = true;
            TropasEnemigas TE = collision.gameObject.GetComponent<TropasEnemigas>();
            
            if (IntervaloDa�o < IntervaloAtaque)
            {
                IntervaloDa�o += Time.deltaTime;
            }
            else
            {
                
                TE.CambiarVidaEnemiga(Da�o);
                IntervaloDa�o = 0f;
            }

        }
        

        if (collision.gameObject.CompareTag("BaseEnemiga")) 
        {
            tm.agent.isStopped = true;
            Base bs = collision.gameObject.GetComponent<Base>();

            if (IntervaloDa�o < 1f)
            {
                IntervaloDa�o += Time.deltaTime;
            }
            else
            {
                
                bs.CambioVida(Da�o);
                IntervaloDa�o = 0f;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("TropaEnemigo") || collision.gameObject.CompareTag("BaseEnemiga"))
        {
            Atacando = false;
        }
    }
}
