using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPACS.PLG.Tasks.XRDetectors
{
    public abstract class XRDetector : MonoBehaviour
    {
        protected bool initialized = false;

        protected virtual void Start() { }
    }
}
