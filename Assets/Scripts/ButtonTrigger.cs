using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    public bool isforward = false;
    public Color defaultColor;

    private void Start()
    {
        defaultColor = GetComponent<MeshRenderer>().material.color;
    }
    

}
