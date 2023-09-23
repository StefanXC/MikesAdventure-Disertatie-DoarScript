using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomFacultate : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform facultate;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        transform.position = new Vector3(0,slider.value, -slider.value);
    }
}
