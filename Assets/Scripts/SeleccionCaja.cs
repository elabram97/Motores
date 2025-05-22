using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeleccionCaja : MonoBehaviour
{
    Camera Camara;

    public RectTransform Caja;

    Rect Seleccion;

    Vector2 PosicionInicial;
    Vector2 Posicionfinal;
    void Start()
    {
        Camara = Camera.main;
        PosicionInicial = Vector2.zero;
        Posicionfinal = Vector2.zero;
        DibujarCaja();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PosicionInicial = Input.mousePosition;

            Seleccion = new Rect();
        }

        if (Input.GetMouseButton(1))
        {
            Posicionfinal = Input.mousePosition;
            DibujarCaja();
            DibujarSeleccion();
        }

        if (Input.GetMouseButtonUp(1))
        {
            SeleccionarUnidades();

            Posicionfinal = Vector2.zero;
            PosicionInicial = Vector2.zero;
            DibujarCaja();
        }
    }



    void DibujarCaja()//Dibuja la caja en la pantalla
    {
        Vector2 CajaInicio = PosicionInicial;
        Vector2 CajaFinal = Posicionfinal;

        Vector2 CajaCentro = (CajaInicio + CajaFinal) / 2;

        Caja.position = CajaCentro;

        Vector2 TamañoCaja = new Vector2(Mathf.Abs(CajaInicio.x - CajaFinal.x), Mathf.Abs(CajaInicio.y - CajaFinal.y));

        Caja.sizeDelta = TamañoCaja;
    }

    void DibujarSeleccion()
    {
        if (Input.mousePosition.x < PosicionInicial.x)
        {
            Seleccion.xMin = Input.mousePosition.x;
            Seleccion.xMax = PosicionInicial.x;
        }
        else
        {
            Seleccion.xMin = PosicionInicial.x;
            Seleccion.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < PosicionInicial.y)
        {
            Seleccion.yMin = Input.mousePosition.y;
            Seleccion.yMax = PosicionInicial.y;
        }
        else
        {
            Seleccion.yMin = PosicionInicial.y;
            Seleccion.yMax = Input.mousePosition.y;
        }
    }

    void SeleccionarUnidades()
    {
        Tropa[] TodasLasTropas = FindObjectsByType<Tropa>(FindObjectsSortMode.None);
        InteraccionMouse im = Camara.GetComponent<InteraccionMouse>();
        foreach (var TodasLasUni in TodasLasTropas)
        {
            Vector3 screenPos = Camara.WorldToScreenPoint(TodasLasUni.transform.position);
            if (screenPos.z > 0 && Seleccion.Contains(screenPos))
            {
                if(TodasLasUni.CompareTag("TropaEspadachin") || TodasLasUni.CompareTag("TropaArquero") || TodasLasUni.CompareTag("TropaTanque"))
                {
                    im.AñadirTropaALaLista(TodasLasUni);
                }
                
            }
        }
    }
}
