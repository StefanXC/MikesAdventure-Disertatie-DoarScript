using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresCircular : MonoBehaviour
{
    public float min = 0;
    public float max;
    public float curent;
    public Image masca;
    public Image incarcat;
    public Color color;
    public Gradient gradient;

    void Update()
    {
        Curent();
    }

    public void Adauga(int val)
    {
        curent += val; //adaugam la progres
    }

    void Curent()
    {

        float decalajCurent = curent - min;
        float decalajMaxim = max - min;
        float progres = decalajCurent / decalajMaxim;
        masca.fillAmount = progres;

        incarcat.fillAmount = decalajCurent / decalajMaxim;

        incarcat.color = gradient.Evaluate(curent);
    }

}
