using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [SerializeField]
    public float velocidad = 1;


    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * velocidad;
    }
}
