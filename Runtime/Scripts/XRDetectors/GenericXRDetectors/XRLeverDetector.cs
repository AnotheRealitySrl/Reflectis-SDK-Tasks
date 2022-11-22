using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRLeverDetector : XRDetector
{
    public GameObject lever;

    public UnityEvent OnMin;
    public UnityEvent OnMid;
    public UnityEvent OnMax;

    protected void Init()
    {
        XRLeverDetector genericDetector = null;
        foreach (var detector in GetComponents<XRLeverDetector>())
        {
            if (detector != this)
            {
                genericDetector = detector;
                break;
            }
        }
        lever = genericDetector.lever;
        OnMin = genericDetector.OnMin;
        OnMid = genericDetector.OnMid;
        OnMax = genericDetector.OnMax;
        initialized = false;
        Destroy(genericDetector);
    }
}
