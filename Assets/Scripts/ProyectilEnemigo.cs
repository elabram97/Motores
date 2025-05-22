using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    public float Da�o;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Da�o *= -1;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TropaEspadachin") || other.CompareTag("TropaArquero") || other.CompareTag("TropaRecolector") || other.CompareTag("TropaTanque"))
        {
            Tropa tpe = other.GetComponent<Tropa>();
            tpe.CambiarVida(Da�o);
            Destroy(gameObject);
        }
        else if (other.CompareTag("BaseAliada"))
        {
            Base bs = other.GetComponent<Base>();
            bs.CambioVida(Da�o);
            Destroy(gameObject);

        }
        else if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}
