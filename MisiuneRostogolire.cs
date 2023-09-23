using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisiuneRostogolire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //verificam dupa eticheta daca obiectul intra in coliziune cu jucatorul
        {
            MisiuniManager2.progresRostogolireMisiune += 1;
            MisiuniManager3.progresRostogolireMisiune += 1;
            MisiuniManager4.progresRostogolireMisiune += 1;

            Destroy(gameObject); //obiectul va fi eliminat din scena
        }
    }
}
