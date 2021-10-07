using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class HandPalmTriggerAction : MonoBehaviour
{
    [SerializeField] private GameObject _ovrRig;
    [SerializeField] private float _smoothing = 1f;
    private Color _defaultButtonColor;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ButtonTrigger>(out var button))
        {
            Vector3 targetMove = Vector3.zero;
            _defaultButtonColor = button.GetComponent<MeshRenderer>().material.color;
            button.GetComponent<MeshRenderer>().material.color = Color.blue;
            if (button.isforward)
            {
                targetMove = _ovrRig.transform.position + (Vector3.forward * 0.5f);
            }
            else
            {
                targetMove = _ovrRig.transform.position - (Vector3.forward * 0.5f);
            }
            StopCoroutine("OvrRigMoveForward");
            StartCoroutine(nameof(OvrRigMoveForward), targetMove);
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ButtonTrigger>(out var button))
        {
            button.GetComponent<MeshRenderer>().material.color  = _defaultButtonColor;
        }
    }

    IEnumerator OvrRigMoveForward(Vector3 targetMove)
    {
        
        while (Vector3.Distance(_ovrRig.transform.position, targetMove) > 0.05f)
        {
            _ovrRig.transform.position =
                Vector3.Lerp(_ovrRig.transform.position, targetMove, _smoothing * Time.deltaTime);

            yield return null;
        }

    }
    
    
}

