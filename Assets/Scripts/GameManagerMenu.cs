using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public void IrAlJuego()
    {
        SceneManager.LoadScene(2);
    }

    public void IrAIntrucciones()
    {
        SceneManager.LoadScene(1);
    }

    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego");
    }
}
