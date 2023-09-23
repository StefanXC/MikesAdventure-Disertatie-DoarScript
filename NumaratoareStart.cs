using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumaratoareStart : MonoBehaviour
{
    public float start = 3;
    public GameObject StartText;
    public TextMeshProUGUI startText;
    public ControlCamera cam; //referire la scriptul ce controleaza camera

    void Start()
    {
        cam.start = false;
        GameObject playerController = GameObject.FindWithTag("Player"); //cauta dupa eticheta obiectul ce contine scriptul
        playerController.GetComponent<ControlPersonaj>().enabled = false; //opreste scriptul
    }

    void Update()
    {
        if (start >= 0)
        {
            start -= 1 * Time.deltaTime; //valoarea variabilei este decrementata cu 1 pe secunda

            startText.text = start.ToString("0"); //afisam valoarea variabilei in text

            if (start <= 0)
            {

                StartText.SetActive(false); //eliminam din interfata texul
                cam.start = true;

                GameObject playerController = GameObject.FindWithTag("Player");
                playerController.GetComponent<ControlPersonaj>().enabled = true; //scriptul devine activ

            }
        }
    }
}
