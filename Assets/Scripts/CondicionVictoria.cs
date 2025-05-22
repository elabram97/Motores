using UnityEngine;
using UnityEngine.SceneManagement;

public class CondicionVictoria : MonoBehaviour
{
    Base baseAliada;
    Base baseEnemiga;
    void Start()
    {
        baseAliada = GameObject.FindGameObjectWithTag("BaseAliada").GetComponent<Base>();
        baseEnemiga = GameObject.FindGameObjectWithTag("BaseEnemiga").GetComponent<Base>();
    }

    // Update is called once per frame
    void Update()
    {
        if(baseAliada.Vida <= 0 || baseEnemiga.Vida <= 0)
        {
            Victoria();
        }
    }

    private void Victoria()
    {
        if (baseAliada.Vida <= 0f)
        {
            SceneManager.LoadScene(2);
            GameManagerVictoria.Titulomg = "Has perdido";
            GameManagerVictoria.Mensajemg = "Los enemigos te han conquistado";
            GameManagerVictoria.colorMensaje = Color.red;
        }
        else if (baseEnemiga.Vida <= 0f)
        {
            SceneManager.LoadScene(2);
            GameManagerVictoria.Titulomg = "¡Has ganado!";
            GameManagerVictoria.Mensajemg = "Felicidades Conquistador!";
            GameManagerVictoria.colorMensaje = Color.blue;
        }
    }
}
