using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiscareLenta : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player") //verifica eticheta obiectelor cu care intra in coliziune
        {
            //FindObjectOfType<AudioManager>().Play("SlowMotion");
            FindObjectOfType<PowerUpsManager>().MiscareLentaColectata();
            Destroy(gameObject);

        }


    }
}
