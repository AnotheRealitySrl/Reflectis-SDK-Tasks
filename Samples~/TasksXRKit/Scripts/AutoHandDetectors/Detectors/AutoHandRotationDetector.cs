using Autohand;

using Reflectis.SDK.Tasks.XRDetectors;

namespace Reflectis.SDK.TasksXRKit.AutoHandDetectors
{
    public class AutoHandRotationDetector : XRRotationDetector
    {
        private Grabbable grabbableHandle;

        ///////////////////////////////////////////////////////////////////////////
        protected override void Awake()
        {
            if (!initialized)
                Init();

            base.Awake();
            grabbableHandle = handle.GetComponent<Grabbable>();
            grabbableHandle.OnGrabEvent += (hand, grabbable) => isGrabbed = true;
            grabbableHandle.OnReleaseEvent += (hand, grabbable) => isGrabbed = false;
            ResetTool();
        }
    }
}
