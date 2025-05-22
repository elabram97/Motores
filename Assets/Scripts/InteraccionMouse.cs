using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InteraccionMouse : MonoBehaviour
{
    public List<GameObject> ObjetosSeleccionados = new List<GameObject>();
    private Camera cam;
    private Tropa TodaLaTropa;
    
    public Edificio ed;
    public GameObject NuevoPunto;
    public GameObject EdificioSeleccionado;
    

    void Start()
    {
        cam = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        Ray RayoInteraccion = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(RayoInteraccion.origin,RayoInteraccion.direction * 20f,Color.red);
        if(Physics.Raycast(RayoInteraccion,out hit, maxDistance: 100f) && Input.GetMouseButtonDown(1))
        {
            
            if (hit.collider.CompareTag("TropaEspadachin") || hit.collider.CompareTag("TropaArquero") || hit.collider.CompareTag("TropaTanque"))
            {
                Tropa tp = hit.collider.GetComponent<Tropa>();
                
                if (!tp.Seleccionado)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        AñadirTropaALaLista(tp);
          
                    }else if (Input.GetKey(KeyCode.LeftControl))
                    {
                        GameObject[] TropasdelaMismaUnidad = GameObject.FindGameObjectsWithTag(hit.collider.tag);
                        foreach (GameObject top in TropasdelaMismaUnidad)
                        {
                            Tropa tpa = top.GetComponent<Tropa>();
                            AñadirTropaALaLista(tpa);
                        }
                    }
                    else
                    {
                        QuitarTodasLasTropas();
                        AñadirTropaALaLista(tp);

                    }


                }else if (tp.Seleccionado)
                {
                    QuitarTropaDeLaLista(tp);

                }
            }else
            {
                QuitarTodasLasTropas();
            }

            if (hit.collider.CompareTag("EdificioAliado"))
            {
                Tropa tropaActual = hit.collider.GetComponent<Tropa>();
                QuitarTodasLasTropas();

                if (EdificioSeleccionado != null)
                {
                    Tropa tropaAnterior = EdificioSeleccionado.GetComponent<Tropa>();
                    tropaAnterior.Seleccionado = false;
                }

                if (!tropaActual.Seleccionado)
                {
                    tropaActual.Seleccionado = true;
                    ed = hit.collider.GetComponent<Edificio>();
                    EdificioSeleccionado = hit.collider.gameObject;
                }
                else
                {
                   
                    QuitarEdificio();
                }
            }
            else
            {
                QuitarEdificio();
            }
        }

        if (Physics.Raycast(RayoInteraccion, out hit, maxDistance: 100f) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.CompareTag("Suelo") && ObjetosSeleccionados.Count > 0)
            {
                Vector3 PosicionSpawneo = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                GameObject NuevoObjeto = Instantiate(NuevoPunto, PosicionSpawneo, transform.rotation);
                Transform PuntoNuevo = NuevoObjeto.transform;
                MoverTodasLasTropas(PuntoNuevo);
                Debug.Log("Moviendo la tropa a la nueva posicion");
            }
            else if (hit.collider.CompareTag("TropaEnemigo") || hit.collider.CompareTag("BaseEnemiga"))
            {
                Transform PosicionEnemigo = hit.collider.transform;
                AtacarTropas(PosicionEnemigo); 
                Debug.Log("Moviendo tropas al enemigo");
            }
        }
        else
        {
            Debug.Log("Ya se esta siguiendo a un punto");
        }
    }

    public void AñadirTropaALaLista(Tropa tp)
    {
        tp.Seleccionado = true;
        ObjetosSeleccionados.Add(tp.gameObject);
    }

    public void QuitarTropaDeLaLista(Tropa tp)
    {
        tp.Seleccionado = false;
        ObjetosSeleccionados.Remove(tp.gameObject);
    }

    public void QuitarEdificio()
    {
        if (EdificioSeleccionado != null)
        {
            Tropa tropa = EdificioSeleccionado.GetComponent<Tropa>();
            tropa.Seleccionado = false;
        }

        ed = null;
        EdificioSeleccionado = null;
    }

    public void QuitarTodasLasTropas()
    {
        if(ObjetosSeleccionados.Count > 0)
        {
            foreach (GameObject objetos in ObjetosSeleccionados)
            {
                TodaLaTropa = objetos.GetComponent<Tropa>();
                TodaLaTropa.Seleccionado = false;

            }
            TodaLaTropa = null;
        }
        ObjetosSeleccionados.Clear();
    }

    public void AtacarTropas(Transform punto)
    {
        foreach(var tropas in ObjetosSeleccionados)
        {
            if (tropas.CompareTag("TropaEspadachin")|| tropas.CompareTag("TropaTanque"))
            {
                MoverTropasAlPunto(punto,tropas);
            }
        }
    }

    public void MoverTodasLasTropas(Transform punto)
    {
        foreach (var tropas in ObjetosSeleccionados)
        {
           MoverTropasAlPunto(punto, tropas); 
        }
    }

    

    public void MoverTropasAlPunto(Transform NuevaPosicion, GameObject Objetoquesemovera)
    {

        TropaMovimiento TM = Objetoquesemovera.GetComponent<TropaMovimiento>();
        TM.target = null;
        Transform PosicionNueva = NuevaPosicion;   
        TM.target = PosicionNueva; 
    }

}
