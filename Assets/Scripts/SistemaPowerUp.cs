using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPowerUp : MonoBehaviour
{
    public static SistemaPowerUp _instance;
    public static SistemaPowerUp Instance { get { return _instance; } }

    [SerializeField]
    public Transform[] puntosSpawn;
    public Transform puntoSpawnActual;
    public float numeroPuntoSpawnActual;

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}
