using System.Threading;
using UnityEngine;

public class RecoleccionRecursos : MonoBehaviour
{
    private float Intervalorecolectar;
    private RecursosInventario rgm;
    public bool Aliado;
    void Start()
    {
        if (Aliado)
        {
            rgm = GameObject.FindGameObjectWithTag("GM").GetComponent<RecursosInventario>();
        }
        else
        {
            rgm = GameObject.FindGameObjectWithTag("BaseEnemiga").GetComponent<RecursosInventario>();
        }
        
        Intervalorecolectar = 1f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Recurso"))
        {
            Recurso recursoActual = collision.collider.GetComponent<Recurso>();

            if(Intervalorecolectar > 0)
            {
                Intervalorecolectar -= Time.deltaTime;
            }
            else
            {
                rgm.ActualizarRecursos(1,recursoActual.TipoDeRecurso);
                recursoActual.TotalRecursoAcumulado -= 1f;
                Intervalorecolectar = 1f;

                if(recursoActual.TotalRecursoAcumulado <= 0)
                {
                    Destroy(recursoActual.gameObject);
                }
            }
        }
    }
}
