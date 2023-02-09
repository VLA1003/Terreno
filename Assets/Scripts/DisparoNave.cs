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

    public void Update()
    {
        //Definición del lugar de donde salen los disparos.
        posicionDisparo1 = lugarDisparo1.transform.position;
        posicionDisparo2 = lugarDisparo2.transform.position;

        //Sistema de disparo.
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject proyectiDisparado1 = Instantiate(proyectil, posicionDisparo1, Quaternion.identity);
            proyectiDisparado1.GetComponent<FisicasProyectil>().direccion = -transform.forward;
            proyectiDisparado1.transform.rotation = gameObject.transform.rotation;

            GameObject proyectiDisparado2 = Instantiate(proyectil, posicionDisparo2, Quaternion.identity);
            proyectiDisparado2.GetComponent<FisicasProyectil>().direccion = -transform.forward;
            proyectiDisparado2.transform.rotation = gameObject.transform.rotation;
        }
    }
}
