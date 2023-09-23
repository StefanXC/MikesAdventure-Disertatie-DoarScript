using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenegerGlisare : MonoBehaviour
{
    public static bool tap, glisareStanga, glisareDreapta, glisareSus, glisareJos;
    private bool atinge = false;
    private Vector2 startAtingere, glisareDelta;

    private void Update()
    {
        tap = glisareJos = glisareSus = glisareStanga = glisareDreapta = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            atinge = true;
            startAtingere = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            atinge = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                atinge = true;
                startAtingere = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                atinge = false;
                Reset();
            }

        }
        #endregion

        glisareDelta = Vector2.zero;

        if (atinge) //verificam daca ecranul este atins
        {
            if (Input.touches.Length < 0)
                glisareDelta = Input.touches[0].position - startAtingere;
            else if (Input.GetMouseButton(0))
                glisareDelta = (Vector2)Input.mousePosition - startAtingere;
            
        }

        if(glisareDelta.magnitude >170) //verificam daca lungimea glisarii este mai mare decat 170
        {
            float x = glisareDelta.x;
            float y = glisareDelta.y;

            if(Mathf.Abs(x)> Mathf.Abs(y)) //verificam pe ce axa lungimea glisarii este mai mare -- Mathf.Abs valaorea absoluta (pozitiva)
            {
                if (x < 0)
                    glisareStanga = true;
                else
                    glisareDreapta = true;
            }
            else
            {
                if (y < 0)
                    glisareJos = true;
                else
                    glisareSus = true;
            }
            Reset();
        }
    }

    private void Reset()
    {
        startAtingere = glisareDelta = Vector2.zero; //resetam calculele lungimii glisarii pentru o noua atingere
        atinge = false;
    }


}
