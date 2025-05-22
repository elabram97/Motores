using System.Collections.Generic;
using UnityEngine;

public class AtaqueArqueroEnemigo : MonoBehaviour
{
    public GameObject ObjetoLanzable;
    public float TiempoDeDisparo;
    private float TiempoTranscurrido;
    public Transform Objetivo;
    private TropaMovimiento tpm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tpm = GetComponent<TropaMovimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Objetivo != null)
        {
            DispararAObjetivo();
            tpm.agent.isStopped = true;
            Debug.Log("ObjetivoEncontrado, iniciando ataque");
        }
        else
        {
            EncontrarObjetivo();
            tpm.agent.isStopped = false;
            Debug.Log("BuscandoObjetivos");

        }
    }

    public void EncontrarObjetivo()
    {
        string[] tags = { "TropaEspadachin", "TropaArquero", "TropaRecolector", "TropaTanque" };
        List<GameObject> objetivosPosibles = new List<GameObject>();

        foreach (string tag in tags)
        {
            GameObject[] encontrados = GameObject.FindGameObjectsWithTag(tag);
            objetivosPosibles.AddRange(encontrados);
        }

        foreach (GameObject tpe in objetivosPosibles)
        {
            float distancia = Vector3.Distance(tpe.transform.position, transform.position);
            if (distancia < 20)
            {

                Objetivo = tpe.transform;
                transform.rotation = Objetivo.rotation;
            }
        }
    }

    public void DispararAObjetivo()
    {
        if (TiempoTranscurrido < TiempoDeDisparo)
        {
            TiempoTranscurrido += Time.deltaTime;
        }
        else
        {
            GameObject NuevoProyectil = Instantiate(ObjetoLanzable, transform.position, ObjetoLanzable.transform.rotation);
            Rigidbody ObjetoNuevoLanzable = NuevoProyectil.GetComponent<Rigidbody>();
            Vector3 DireccionObjetivo = (Objetivo.position - NuevoProyectil.transform.position).normalized;
            float Fuerza = 50f;
            ObjetoNuevoLanzable.AddForce(DireccionObjetivo * Fuerza, ForceMode.Impulse);
            TiempoTranscurrido = 0f;
        }
    }
}
