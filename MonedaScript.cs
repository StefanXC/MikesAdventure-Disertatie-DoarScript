using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaScript : MonoBehaviour
{

    public Transform playerTransform;
    public float vitezaDeMiscare = 17f;

    MiscareMoneda miscareMonedaScript;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //informam variabila cu caracteristicile pozitiei jucatorului
        miscareMonedaScript = gameObject.GetComponent<MiscareMoneda>();
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MagnetMonede") //verificam etichetele obiectelor atinse
        {
            miscareMonedaScript.enabled = true; //activam scriptul
        }

        if (other.tag == "Player")
        {
         
            PlayerManager.numarBanutzi += 1;
            MisiuniManager2.progresBanutziMisiune += 1;   //
            MisiuniManager3.progresBanutziMisiune += 1;  //adauga la progresul misiunii
            MisiuniManager4.progresBanutziMisiune += 1; //

            FindObjectOfType<AudioManager>().Play("Coin"); //se va reda sunetul

            Debug.Log("Ai " + PlayerManager.numarBanutzi + "monede");
            Destroy(gameObject);
        }


    }

}
