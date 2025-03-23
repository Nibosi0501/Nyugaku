using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCamera : MonoBehaviour
{
    [SerializeField] private Camera secondCamera;
    void Start()
    {
        secondCamera.targetDisplay = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
