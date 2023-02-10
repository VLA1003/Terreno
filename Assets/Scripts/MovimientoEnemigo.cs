using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField]
    public Transform[] puntosRuta;
    public Transform puntoRutaActual;
    public float velocidadEnemigo = 2;
    public int numeroPuntoRuta = 0;

    private void Start()
    {
        gameObject.transform.position = puntosRuta[numeroPuntoRuta].transform.position;
    }

    //Movimiento constante de la nave enemiga.
    private void Update()
    {
        MovimientoNaveEnemiga();
    }

    //Movimiento de la nave enemiga.
    public void MovimientoNaveEnemiga()
    {
        puntoRutaActual = puntosRuta[numeroPuntoRuta];
        if (numeroPuntoRuta <= puntosRuta.Length - 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, puntosRuta[numeroPuntoRuta].transform.position, velocidadEnemigo * Time.deltaTime);
            if (transform.position == puntosRuta[numeroPuntoRuta].transform.position)
            {
                numeroPuntoRuta += 1;
            }

        if (numeroPuntoRuta == puntosRuta.Length)
            {
                numeroPuntoRuta = 0;
                gameObject.transform.position = puntosRuta[numeroPuntoRuta].transform.position;
            }
            
            Vector3 posicionPuntoRutaActual = puntoRutaActual.position - transform.position;
            gameObject.transform.rotation = Quaternion.LookRotation(-posicionPuntoRutaActual);

        }
    }

    //Detección del proyectil para destrucción del enemigo.
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Destroy(gameObject);
        }
    }
}
