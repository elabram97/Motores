using UnityEngine;

public class GenerarTropasAuto : MonoBehaviour
{
    public Transform PosicionSpawn;
    public GameObject UnidadEspadachines;
    public GameObject UnidadesArqueras;
    public GameObject UnidadesRecolectoras;
    public GameObject UnidadesTanque;
    public float TiempoEspera;
    private RecursosInventario im;
    private LimiteUnidades lu;

    void Start()
    {
        im = GameObject.FindGameObjectWithTag("BaseEnemiga").GetComponent<RecursosInventario>();
        lu = GameObject.FindGameObjectWithTag("BaseEnemiga").GetComponent<LimiteUnidades>();
    }

    // Update is called once per frame
    void Update()
    {
        TiempoDeEspera();
    }


    public void TiempoDeEspera()
    {
        if (TiempoEspera > 0)
        {
            TiempoEspera -= Time.deltaTime;
        }
        else
        {
            AparecerUnidades();
        }
    }

    public void AparecerUnidades()
    {
        if (lu.PermiteCrear)
        {
            int GenerarUnidad = Random.Range(1, 4);
            switch (GenerarUnidad)
            {
                case 1:
                    if (im.Madera >= 2 && im.Minerales >= 2)
                    {
                        Instantiate(UnidadEspadachines, PosicionSpawn);
                        im.ActualizarRecursos(-2, 1);
                        im.ActualizarRecursos(-2, 2);
                        TiempoEspera = 30;
                    }
                    else
                    {
                        Debug.Log("No hay materiales suficientes para enemigo");
                    }
                    break;

                case 2:
                    if (im.Madera >= 5 && im.Minerales >= 3)
                    {
                        Instantiate(UnidadesArqueras, PosicionSpawn);
                        im.ActualizarRecursos(-5, 1);
                        im.ActualizarRecursos(-3, 2);
                        TiempoEspera = 30;
                    }
                    else
                    {
                        Debug.Log("No hay materiales suficientes para enemigo");
                    }
                    break;

                case 3:
                    if (im.Madera >= 1 && im.Minerales >= 2)
                    {
                        Instantiate(UnidadEspadachines, PosicionSpawn);
                        im.ActualizarRecursos(-1, 1);
                        im.ActualizarRecursos(-2, 2);
                        TiempoEspera = 30;
                    }
                    else
                    {
                        Debug.Log("No hay materiales suficientes");
                    }
                    break;
                case 4:
                    if (im.Madera >= 10 && im.Minerales >= 10)
                    {
                        Instantiate(UnidadesTanque, PosicionSpawn);
                        im.ActualizarRecursos(-10, 1);
                        im.ActualizarRecursos(-10, 2);
                        TiempoEspera = 30;
                    }
                    else
                    {
                        Debug.Log("No hay materiales suficientes");
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("Aún no se pueden crear unidades, espera");
        }
    }
}
    


