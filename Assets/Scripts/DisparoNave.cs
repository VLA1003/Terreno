using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    [SerializeField]
    public GameObject proyectil;
    public GameObject lugarDisparo1, lugarDisparo2;
    
    public Vector3 posicionDisparo1;
    public Vector3 posicionDisparo2;
    public Vector3 rotacionDisparo;

    [SerializeField]
    public float frecuenciaDisparo;
    public float frecuenciaDisparoFinal;
    public float multiplicadorPowerUp;
    public float tiempoConPowerUp;
    public bool tienePowerUp;
    [SerializeField]
    public bool tiempoEstaCorriendo;


    public void Start()
    {
        frecuenciaDisparo = 0.75f;
        tiempoConPowerUp = 0;
    }

    public void Update()
    {
        multiplicadorPowerUp = PropiedadesPowerUp._instance.multiplicadorDisparo;
        tienePowerUp = PropiedadesPowerUp._instance.haCogidoPowerUp;
        frecuenciaDisparoFinal = frecuenciaDisparo / multiplicadorPowerUp;
        if (Input.GetButtonDown("Fire2"))
        {
            InvokeRepeating("SistemaDisparo", 0, frecuenciaDisparoFinal);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            CancelInvoke();
        }

        if (tienePowerUp == true)
        {
            tiempoEstaCorriendo = true;
            if (tiempoEstaCorriendo == true)
            {
                tiempoConPowerUp += Time.deltaTime;
            }

            if (tiempoConPowerUp >= 20)
            {
                tienePowerUp = false;
                tiempoEstaCorriendo = false;
                if (tiempoEstaCorriendo == false)
                {
                    tiempoConPowerUp = 0;
                }
            }
        if (tienePowerUp == false)
            {
                PropiedadesPowerUp._instance.multiplicadorDisparo = 1;
            }
        }

    }

    //Sistema de disparo
    public void SistemaDisparo()
    {
        //Definición del lugar de donde salen los disparos.
        posicionDisparo1 = lugarDisparo1.transform.position;
        posicionDisparo2 = lugarDisparo2.transform.position;

        //Sistema de disparo.
        GameObject proyectiDisparado1 = Instantiate(proyectil, posicionDisparo1, Quaternion.identity);
        proyectiDisparado1.GetComponent<FisicasProyectil>().direccion = -transform.forward;
        proyectiDisparado1.transform.rotation = gameObject.transform.rotation;

        GameObject proyectiDisparado2 = Instantiate(proyectil, posicionDisparo2, Quaternion.identity);
        proyectiDisparado2.GetComponent<FisicasProyectil>().direccion = -transform.forward;
        proyectiDisparado2.transform.rotation = gameObject.transform.rotation;
    
    }

}
