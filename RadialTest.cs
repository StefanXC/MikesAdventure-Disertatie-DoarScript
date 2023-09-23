using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialTest : MonoBehaviour
{
    public ProgresCircular radial;

    public void Adauga10()
    {
        radial.Adauga(10); //adaugam 10 unitati la valoarea curenta
    }

    public void Adauga1()
    {
        radial.Adauga(1); //adaugam o unitate la valoarea curenta
    }
}
