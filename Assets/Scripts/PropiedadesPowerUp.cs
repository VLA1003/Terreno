using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropiedadesPowerUp : MonoBehaviour
{
    public static PropiedadesPowerUp _instance;
    public static PropiedadesPowerUp Instance { get { return _instance; } }

    [SerializeField]
    public float multiplicadorDisparo;
    [SerializeField]
    public bool haCogidoPowerUp;
    public MeshRenderer esfera;

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

    public void Start()
    {
        gameObject.GetComponent<SphereCollider>();
        gameObject.GetComponent<MeshRenderer>();
        multiplicadorDisparo = 1;
        haCogidoPowerUp = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jugador")
        {
            multiplicadorDisparo = 2;
            haCogidoPowerUp = true;
            esfera.enabled = false;
        }
    }
}
