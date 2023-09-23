using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiziuneJucator : MonoBehaviour
{   

    void OnCollisionEnter(Collision collisionInfo) //putem identifica obiectele cu care jucatorul intra in coliziune
    {
        if(collisionInfo.collider.name != "Player") //scrie in consola numele obiectelor care intra in coliziuna cu jucatorul
            Debug.Log(collisionInfo.collider.name);

        if (collisionInfo.collider.tag=="Obstacol") //verifica eticheta obiectul
        {
            Debug.Log("Am atins obstacol");
            FindObjectOfType<PlayerManager>().EndGame();//cauta functia numita EndGame aflata in scriptul PlayerManager
            //FindObjectOfType<AudioManager>().Play("GameOver");
            //FindObjectOfType<AudioManager>().Stop("Fundal");
        }

        if (collisionInfo.collider.tag == "Magnet")
        {
            //FindObjectOfType<>().EndGame();

        }

    }

}
