using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//este necesara biblioteeca deoarece fara ea nu putem accesa parametri regasiti in interfata vizuala

public class BaraProgres : MonoBehaviour
{

    public Slider slider; //realizam o referinta la slider pentru al putea manipula
    public Gradient gradient; //gradientul este utilizat pentru a putea schimba culoarea cursiv
    public Image incarcat; //imaginea barei de progress caruia ii vom aplica gradientul

    public void Cerinta(int progres) 
    {
        slider.maxValue = progres; //alocam cerinta misiunii valorii maxime 
        slider.value = 0; //setam ca valoare curenta 0

        incarcat.color = gradient.Evaluate(1f); //evaluam progresul si alocam gradientul corespunzator
    }

    public void Progres(int progres)
    {
        slider.value = progres; //alocam progresul misiunii valorii barei de progres

        incarcat.color = gradient.Evaluate(slider.normalizedValue);//calculeaza si genereaza culaore in functie de procent
    }
}
