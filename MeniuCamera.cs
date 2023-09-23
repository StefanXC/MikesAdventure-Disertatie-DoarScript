using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeniuCamera : MonoBehaviour
{
    public float SmoothSpeed = 1f;
    public Vector3 pozitieCamera; //Vector3 folosit pentru modificarea coordonatelor camerei

    public float minX = -100; //valoarea minima a coordonatei Ox
    public float maxX = 100;  //valoarea maxima a coordonatei Ox
    public float minZ = -100; //valoarea minima a coordonatei Oz
    public float maxZ = 100;  //valoarea maxima a coordonatei Oz

    public float vitezaX = 10; //viteza de miscare pentru ambele axe pe care le vom modifica
    public float vitezaZ = 6;  //

    public bool miscaX = true;
    public bool miscaZ = true;

     void Update()
    {
        MiscaX();
        MiscaZ();
        
        pozitieCamera = new Vector3(pozitieCamera.x, pozitieCamera.y, pozitieCamera.z);
        transform.position = pozitieCamera;

    } 

    /*void Update()
    {

        Vector3 desiredPosition = new Vector3(player.position.x + distantaCamera.x, distantaCamera.y, player.position.z + distantaCamera.z);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = SmoothedPosition;
    }
    */

    public void MiscaX()
    {
        if (pozitieCamera.x <= maxX && miscaX == true)
        {
            pozitieCamera.x += vitezaX * Time.deltaTime; //valoarea coordonatei Ox creste
        }

        if (pozitieCamera.x >= maxX - 1)
        {
            miscaX = false;
        }

        if (pozitieCamera.x > minX && miscaX == false)
        {
            pozitieCamera.x -= vitezaX * Time.deltaTime; //valoarea coordonatei Ox descreste
        }

        if (pozitieCamera.x <= minX + 1)
        {
            miscaX = true;
        }
    }

    public void MiscaZ()
    {
        if (pozitieCamera.z <= maxZ && miscaZ == true)
        {
            pozitieCamera.z += vitezaZ * Time.deltaTime; //valoarea coordonatei Oy creste
        }

        if (pozitieCamera.z >= maxZ - 1)
        {
            miscaZ = false;
        }

        if (pozitieCamera.z > minZ && miscaZ == false)
        {
            pozitieCamera.z -= vitezaZ * Time.deltaTime; //valoarea coordonatei Oy descreste
        }

        if (pozitieCamera.z <= minZ + 1)
        {
            miscaZ = true;
        }
    }
}
