using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscareMoneda : MonoBehaviour
{

    MonedaScript moneda;
    void Start()
    {
        moneda = gameObject.GetComponent<MonedaScript>();//atribuim variabilei componenta(scriptul) MonedaScript
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moneda.playerTransform.position, moneda.vitezaDeMiscare * Time.deltaTime);
        //moneda se va apropria de jucator prin modificarea pozitiei la fiecare cadru
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //verifica etichetele obiectelor atinse
        {
            Destroy(gameObject);  //obiectul va disparea din scena
        }
    }
}
