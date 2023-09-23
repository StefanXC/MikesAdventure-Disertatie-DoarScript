using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Magnet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //verifica eticheta obiectului cu care produce coliziunea
        {
            FindObjectOfType<PowerUpsManager>().MagnetColectat(); //cauta funcia MagnetColectat din scriptul PowerUpsManager

            //Destroy(transform.GetChild(0).gameObject);
            Destroy(gameObject); //elimina obiectul din scena

        }

    }

}
