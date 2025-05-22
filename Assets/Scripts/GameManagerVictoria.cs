using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerVictoria : MonoBehaviour
{
    public static string Titulomg;
    public static string Mensajemg;
    public static Color colorMensaje;
    public TMP_Text Titulo;
    public TMP_Text Mensaje;
    
    void Start()
    {
        string hex = ColorUtility.ToHtmlStringRGBA(colorMensaje);
        Titulo.text = $"<color=#{hex}>"+Titulomg;
        Mensaje.text = $"<color=#{hex}>" + Mensajemg;
    }

    public void IRAlMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }
    
}
