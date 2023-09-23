using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotireBanutz : MonoBehaviour
{
    
    public float vitezaRotatie = 50;

    void Update()
    {
        transform.Rotate(vitezaRotatie * Time.deltaTime,0,0);
    }


}
