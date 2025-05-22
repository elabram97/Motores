using Unity.VisualScripting;
using UnityEngine;

public class TropasEnemigas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Renderer rd;
    public float Vida = 20f;

    void Start()
    {

        rd = GetComponent<Renderer>();
        rd.material.color = Color.red;

    }

    // Update is called once per frame


    public void CambiarVidaEnemiga(float vidaCambio)
    {
        Vida += vidaCambio;
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
    
