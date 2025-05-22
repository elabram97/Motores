using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject PantallaPausa;
    void Start()
    {
        PantallaPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0)
            {
                PausarJuego();
            }
            else
            {
                ReanudarPartida();
            }
            
        }

    }

    public void PausarJuego()
    {
        if (Time.timeScale != 0)
        {
            PantallaPausa.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ReanudarPartida()
    {
        if (Time.timeScale == 0) 
        {
            PantallaPausa.SetActive(false);
            Time.timeScale = 1;
        
        }
    }

    public void IRalMenu()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

    public void SalirJuego()
    {
        if(Time.timeScale == 0)
        {
            Application.Quit();
        }
    }
}
