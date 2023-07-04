using UnityEngine;

namespace Reflectis.PLG.Tasks.XRDetectors
{
    public abstract class XRDetector : MonoBehaviour
    {
        protected bool initialized = false;

        protected virtual void Start() { }
    }
}
