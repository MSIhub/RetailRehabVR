using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingGrabber : OVRGrabber
{
    private OVRHand _hand;

    protected override void Start()
    {
        base.Start();
        _hand = GetComponent<OVRHand>();
        

    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();

    }

    private void CheckIndexPinch()
    {
        bool isPinching = _hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        if (!m_grabbedObj && isPinching && m_grabCandidates.Count>0)
        {
            GrabBegin();
        }
        else if (m_grabbedObj && !isPinching)
        {
            GrabEnd();
        }
    }

    protected override void GrabEnd()
    {
        if (m_grabbedObj)
        {
            Vector3 linerVelocity = (transform.position - m_lastPos) / Time.fixedDeltaTime;
            Vector3 angularVelocity = (transform.eulerAngles - m_lastRot.eulerAngles) / Time.fixedDeltaTime;
            
            GrabbableRelease(linerVelocity, angularVelocity);
        }
        
        GrabVolumeEnable(true);
    }
}
