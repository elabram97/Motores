using System.Runtime.CompilerServices;
using UnityEngine;

public class Edificio : MonoBehaviour
{
    public Transform PosicionSpawn;
    public GameObject UnidadEspadachines;
    public GameObject UnidadesArqueras;
    public GameObject UnidadesRecolectoras;
    public GameObject UnidadesTanque;
    private Tropa Tp;
    private bool SePuedeCrear;
    public float TiempoEspera;
    private RecursosInventario im;
    private LimiteUnidades lu;
    
    void Start()
    {
        Tp = GetComponent<Tropa>();
        TiempoEspera = 0f;
        SePuedeCrear = true;
        im = GameObject.FindGameObjectWithTag("GM").GetComponent<RecursosInventario>();
        lu = GameObject.FindGameObjectWithTag("BaseAliada").GetComponent<LimiteUnidades>();
    }

    void Update()
    {
        if (!SePuedeCrear)
        {
            TiempoDeEspera();
        }
    }

    public void TiempoDeEspera()
    {
        if (TiempoEspera > 0)
        {
            TiempoEspera -= Time.deltaTime;
        }
        else
        {
            TiempoEspera = 0;
            SePuedeCrear = true;
        }
    }

    public void AparecerUnidades(int Indice)
    {
        if (Tp.Seleccionado)
        {
            if (SePuedeCrear && lu.PermiteCrear)
            {
                switch (Indice)
                {
                    case 1:
                        if(im.Madera >=2 && im.Minerales >= 2)
                        {
                            Instantiate(UnidadEspadachines, PosicionSpawn);
                            im.ActualizarRecursos(-2,1);
                            im.ActualizarRecursos(-2, 2);
                            SePuedeCrear = false;
                            TiempoEspera = 30;
                        }
                        else
                        {
                            Debug.Log("No hay materiales suficientes");
                        }

                        break;
                    case 2:
                        if (im.Madera >= 5 && im.Minerales >= 3)
                        {
                            Instantiate(UnidadesArqueras, PosicionSpawn);
                            im.ActualizarRecursos(-5, 1);
                            im.ActualizarRecursos(-3, 2);
                            SePuedeCrear = false;
                            TiempoEspera = 30;
                        }
                        else
                        {
                            Debug.Log("No hay materiales suficientes");
                        }
                        break;
                    case 3:
                        if (im.Madera >= 1 && im.Minerales >= 2)
                        {
                            Instantiate(UnidadEspadachines, PosicionSpawn);
                            im.ActualizarRecursos(-1, 1);
                            im.ActualizarRecursos(-2, 2);
                            SePuedeCrear = false;
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
                            SePuedeCrear = false;
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
                Debug.Log("Aun no se pueden crear unidades, espera");
            }
            
            
            
        }
        
    }
}
