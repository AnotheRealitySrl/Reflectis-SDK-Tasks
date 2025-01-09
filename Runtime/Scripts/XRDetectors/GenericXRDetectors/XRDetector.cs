using UnityEngine;

namespace Reflectis.SDK.Tasks.XRDetectors
{
    public abstract class XRDetector : MonoBehaviour
    {
        protected bool initialized = false;

        protected virtual void Start() { }
    }
}
