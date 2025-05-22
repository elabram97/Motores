using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LimiteUnidades : MonoBehaviour
{
    public bool Aliados;
    public int Limite;
    public int TotalUnidades;
    public bool PermiteCrear;
    void Start()
    {
        TotalUnidades = 0;
        PermiteCrear = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        BuscarUnidades();
        if (TotalUnidades < Limite)
        {
            PermiteCrear = true;
        }
        else
        {
            PermiteCrear = false;
        }
    }

    public void BuscarUnidades()
    {
        
        if (Aliados)
        {
            List<string> tagsABuscar = new List<string>{"TropaArquero","TropaEspadachin","TropaRecolector"};
            List<GameObject> objetosEncontrados = new List<GameObject>();
            int TotalDeUnidades = 0;
            foreach (string tag in tagsABuscar)
            {
                GameObject[] objetosConTag = GameObject.FindGameObjectsWithTag(tag);
                objetosEncontrados.AddRange(objetosConTag);
            }

            foreach (var TodosLosObjetos in objetosEncontrados)
            {
                TotalDeUnidades++;
            }
            TotalUnidades = TotalDeUnidades;
            
        }
        else
        {
            int TotalDeUnidades = 0;
            GameObject[] UnidadesEnemigas = GameObject.FindGameObjectsWithTag("TropaEnemigo");
            foreach (var ue in UnidadesEnemigas)
            {
                TotalDeUnidades++;
            }
            TotalUnidades = TotalDeUnidades;
        }
    }
}
