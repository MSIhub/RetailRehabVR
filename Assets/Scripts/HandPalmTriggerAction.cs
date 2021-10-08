using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class HandPalmTriggerAction : MonoBehaviour
{
    [SerializeField] private GameObject _ovrRig;
    [SerializeField] private GameObject _trolley;
    [SerializeField] private float _smoothing = 1f;
    private Color _defaultButtonColor;

    private Coroutine locomotionCoroutine;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ButtonTrigger>(out var button))
        {
            
            button.GetComponent<MeshRenderer>().material.color = Color.blue;
            
            
            Vector3 ovrTargetMove = Vector3.zero;
            Vector3 trolleyTargetMove = Vector3.zero;
            if (button.isforward)
            {
                ovrTargetMove = _ovrRig.transform.position + (Vector3.forward * 0.5f);
                trolleyTargetMove = _trolley.transform.position + (Vector3.forward * 0.5f);
            }
            else if (!button.isforward)
            {
                ovrTargetMove = _ovrRig.transform.position - (Vector3.forward * 0.5f);
                trolleyTargetMove = _trolley.transform.position - (Vector3.forward * 0.5f);
            }

            if (locomotionCoroutine != null)
            {
                StopCoroutine(locomotionCoroutine);
            }
            
            locomotionCoroutine = StartCoroutine(LocomotionTrolleyOvrRig(ovrTargetMove,trolleyTargetMove));
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ButtonTrigger>(out var button))
        {
            button.GetComponent<MeshRenderer>().material.color  = button.defaultColor;
        }
    }

    IEnumerator LocomotionTrolleyOvrRig(Vector3 ovrtargetMove, Vector3 trolleytargetMove)
    {
        
        while (Vector3.Distance(_ovrRig.transform.position, ovrtargetMove) > 0.05f)
        {
            _ovrRig.transform.position =
                Vector3.Lerp(_ovrRig.transform.position, ovrtargetMove, _smoothing * Time.deltaTime);
            
            _trolley.transform.position =
                Vector3.Lerp(_trolley.transform.position, trolleytargetMove, _smoothing * Time.deltaTime);

            yield return null;
        }

    }
    
    
}

