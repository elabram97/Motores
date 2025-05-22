using UnityEngine;

public class EliminarPunto : MonoBehaviour
{
    private float TiempoEliminacion;
    public float Tiempo;
    
    // Update is called once per frame
    void Update()
    {
        if(TiempoEliminacion < Tiempo)
        {
            TiempoEliminacion += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
