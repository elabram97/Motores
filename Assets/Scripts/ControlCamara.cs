using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCamara : MonoBehaviour
{
    public InputAction Movimiento;
    public InputAction Rotacion;
    //public InputAction Zoom;

    public Transform yop;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Movimiento = InputSystem.actions.FindAction("Movimiento");
        Rotacion = InputSystem.actions.FindAction("Rotacion");
        //Zoom = InputSystem.actions.FindAction("Zoom");
        yop = transform.Find("Yam");
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        {
            if (Input.anyKey)
            {
                Vector2 mover = Movimiento.ReadValue<Vector2>();
                float rotar = Rotacion.ReadValue<float>();
                Vector3 rotacionnormal = yop.rotation * new Vector3(mover.x, 0, mover.y);
                transform.Translate(rotacionnormal);
                yop.Rotate(0, rotar, 0);
            }
        }
        
    }
}
