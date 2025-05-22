using UnityEngine;

public class ImpactoProyectil : MonoBehaviour
{
    public float Daño;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Daño *= -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TropaEnemigo"))
        {
            TropasEnemigas tpe = other.GetComponent<TropasEnemigas>();
            tpe.CambiarVidaEnemiga(Daño);
            Destroy(gameObject);
        }
        else if (other.CompareTag("BaseEnemiga"))
        {
            Base bs = other.GetComponent<Base>();
            bs.CambioVida(Daño);
            Destroy(gameObject);
            
        }else if (other.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}
