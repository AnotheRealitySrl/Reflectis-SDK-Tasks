using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRSliderDetector : XRDetector
{
    public GameObject slider;

    public UnityEvent OnMin;
    public UnityEvent OnMid;
    public UnityEvent OnMax;

    protected void Init()
    {
        XRSliderDetector genericDetector = null;
        foreach (var detector in GetComponents<XRSliderDetector>())
        {
            if (detector != this)
            {
                genericDetector = detector;
                break;
            }
        }
        slider = genericDetector.slider;
        OnMin = genericDetector.OnMin;
        OnMid = genericDetector.OnMid;
        OnMax = genericDetector.OnMax;
        initialized = false;
        Destroy(genericDetector);
    }
}
