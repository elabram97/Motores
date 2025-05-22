using Unity.VisualScripting;
using UnityEngine;

public class BuscarRecursosEnMapa : MonoBehaviour
{
    private TropaMovimiento tmp;
    private Transform RecursoSeleccionado;
    public string TagBase;
    private Transform Base;
    void Start()
    {
        tmp = GetComponent<TropaMovimiento>();
        Base = GameObject.Find(TagBase).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (RecursoSeleccionado == null)
        {
            BuscarRecursos();
            
        }
        else
        {
            tmp.target = RecursoSeleccionado;
            
        }

        


    }

    private void BuscarRecursos()
    {
        GameObject[] RecursosEnELMapa = GameObject.FindGameObjectsWithTag("Recurso");
        if(RecursosEnELMapa.Length > 0)
        {
            foreach (var Recursos in RecursosEnELMapa)
            {
                float distancia = Vector3.Distance(Recursos.transform.position, transform.position);
                if (distancia < 100)
                {
                    RecursoSeleccionado = Recursos.transform; 
                    break;
                }
            }
        }
        else
        {
            tmp.target = Base;
        }
        
    }
}
