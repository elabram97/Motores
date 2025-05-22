using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float Vida;
    public float VidaMaxima;
    public bool Aliada;
    public Image imagen;
    public Color ColorBase;
    private Renderer rd;
    private void Start()
    {
        rd= GetComponent<Renderer>();
        rd.material.color= ColorBase;
        imagen.fillAmount = Vida/VidaMaxima;
        
    }

    
    public void CambioVida(float CambioVida)
    {
        Vida += CambioVida;
        imagen.fillAmount = Vida / VidaMaxima;
        
    }
}
