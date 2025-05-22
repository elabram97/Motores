using System.Linq;
using TMPro;
using UnityEngine;

public class AparecerVentanas : MonoBehaviour
{
    public GameObject VentanaTropas;
    public GameObject VentanaEdificios;
    private InteraccionMouse itm;
    public TMP_Text TextoTropas;
    public TMP_Text TotalDeTropas;
    private LimiteUnidades lu;
    
    void Start()
    {
        itm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<InteraccionMouse>();
        lu = GameObject.FindGameObjectWithTag("BaseAliada").GetComponent<LimiteUnidades>();
        VentanaTropas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        VentanaTropa();
        VentanaEdificos();
        TotalDeTropas.text = "Total: " + lu.TotalUnidades + "/" + lu.Limite;
    }

    public void VentanaTropa()
    {
        if (itm.ObjetosSeleccionados.Count > 0)
        {
            VentanaTropas.SetActive(true);
            foreach(GameObject tropa in itm.ObjetosSeleccionados)
            {
                TextoTropas.text = "Tropas seleccionadas: <color=red>" + itm.ObjetosSeleccionados.Count.ToString() +
                "</color>\nEspadachines: <color=red>" + itm.ObjetosSeleccionados.Count(tropa => tropa.tag == "TropaEspadachin").ToString() +
                "</color>\nArqueros: <color=red>" + itm.ObjetosSeleccionados.Count(tropa => tropa.tag == "TropaArquero").ToString() +
                "</color>\nTanques: <color=red>" + itm.ObjetosSeleccionados.Count(tropa => tropa.tag == "TropaTanque").ToString();
            }

            


        }
        else
        {
            VentanaTropas.SetActive(false);
            TextoTropas.text = "Ninguna unidad seleccionada";
            
        }
    }

    public void VentanaEdificos()
    {
        if (itm.ed != null)
        {
            VentanaEdificios.SetActive(true);
        }
        else
        {
            VentanaEdificios.SetActive(false);
        }
    }

    public void EscogerUnidad(int Indice)
    {
        itm.ed.AparecerUnidades(Indice);
    }
}
