using UnityEngine;

public class Tropa : MonoBehaviour
{
    public bool Seleccionado;
    private Renderer rd;
    public float Vida = 20f;
    public Color SeleccionColor;
    private InteraccionMouse im;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Seleccionado = false;
        rd = GetComponent<Renderer>();
        im = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<InteraccionMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Seleccionado)
        {
            rd.material.color = SeleccionColor;
        }
        else
        {
            rd.material.color = Color.blue;
        }

        
    }

    public void CambiarVida(float Cambio) 
    {
        Vida += Cambio;
        if (Vida <= 0)
        {
            Destroy(gameObject);
            im.ObjetosSeleccionados.Remove(gameObject);
        }
    }



    
}
