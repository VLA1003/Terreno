using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    [SerializeField]
    public float velocidadNave = 1f;
    public float velocidadTurbo = 10f;
    public float velocidadRotacionVerticalNave = 50f;
    public float velocidadRotacionHorizontalNave = 50f;
    public float velocidadRotacionDiagonalNave = 10f;

    void Update()
    {
        // Movimiento y rotación de la nave.
        float rotacionX = Input.GetAxis("Vertical") * Time.deltaTime * velocidadRotacionVerticalNave;
        float rotacionY = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadRotacionHorizontalNave;
        float rotacionZ = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadRotacionDiagonalNave;
        transform.position += -transform.forward * Time.deltaTime * velocidadNave;
        transform.Rotate(rotacionX, 0, 0, Space.Self);
        transform.Rotate(0, rotacionY, 0, Space.Self);
        transform.Rotate(0, 0, rotacionZ, Space.Self);

        // Sistema de turbo de la nave.
        if (Input.GetButtonDown("Jump"))
        {
            velocidadNave = velocidadNave + 10;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            velocidadNave = velocidadNave - 10;
        }

        //Sistema de freno de la nave.
        if (Input.GetButtonDown("Enable Debug Button 1"))
        {
            velocidadNave = velocidadNave - 5;
        }
        else if (Input.GetButtonUp("Enable Debug Button 1"))
        {
            velocidadNave = velocidadNave + 5;
        }

    }
}
