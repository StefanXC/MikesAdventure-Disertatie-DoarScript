using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SareMisiune : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //verificam dupa eticheta daca obiectul intra in coliziune cu jucatorul
        {
   
            MisiuniManager2.progresSareMisiune += 1;
            MisiuniManager3.progresSareMisiune += 1;
            MisiuniManager4.progresSareMisiune += 1;

            Destroy(gameObject); //obiectul va fi eliminat din scena
        }
    }
}
