using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRGrabDetector : XRDetector
{
    [Header("References")]
    public GameObject grabbable = default;

    [Header("Events")]
    public UnityEvent OnGrabStart = default;

    public UnityEvent OnGrabEnd = default;

    public UnityEvent OnHoverStart = default;

    public UnityEvent OnHoverEnd = default;

    protected void Init()
    {
        XRGrabDetector genericDetector = null;
        foreach (var detector in GetComponents<XRGrabDetector>())
        {
            if (detector != this)
            {
                genericDetector = detector;
                break;
            }
        }
        grabbable = genericDetector.grabbable;
        OnGrabStart = genericDetector.OnGrabStart;
        OnGrabEnd = genericDetector.OnGrabEnd;
        OnHoverStart = genericDetector.OnHoverStart;
        OnHoverEnd = genericDetector.OnHoverEnd;
        initialized = false;
        Destroy(genericDetector);
    }
}
