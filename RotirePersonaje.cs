using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotirePersonaje : MonoBehaviour
{
    public float vitezaRotatie = 50;

    void Update()
    {
        transform.Rotate(0, vitezaRotatie * Time.deltaTime, 0);
    }
}
