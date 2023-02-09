using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisicasProyectil : MonoBehaviour
{
    public Vector3 direccion;
    public Vector3 rotacion;
    
    [SerializeField]
    public float velocidadProyectil = 50;
    public float duracionProyectil;

    private void Update()
    {
        //F�sicas del proyectil.
        transform.position += direccion * velocidadProyectil * Time.deltaTime;

        //Duraci�n/vida del proyectil. Cuando es disparado, el proyectil s�lo existe durante 1 segundo y medio.
        duracionProyectil += Time.deltaTime;
        if (duracionProyectil > 1.5)
        {
            Destroy(gameObject);
        }
    }
}
