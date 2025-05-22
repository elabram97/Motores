using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecursosInventario : MonoBehaviour
{
    public TMP_Text MostrarRecursosMadera;
    public TMP_Text MostrarRecursosMinerales;
    public int Madera;
    public int Minerales;
    public bool Aliado;

    void Start()
    {
        if (Aliado)
        {
            MostrarRecursosMadera.text = Madera.ToString();
            MostrarRecursosMinerales.text = Minerales.ToString();
        }
 
    }

    public void ActualizarRecursos(int CambiarRecursos,int tipo)
    {
        switch (tipo)
        {
            case 1:
                Madera += CambiarRecursos;
                if(Aliado) MostrarRecursosMadera.text = Madera.ToString();

                break;
            case 2:
                Minerales += CambiarRecursos;
                if(Aliado) MostrarRecursosMinerales.text = Minerales.ToString();
                break;
        }
    }
}
