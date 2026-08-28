using Autohand;

using Virtuademy.SDK.Tasks.XRDetectors;

namespace Virtuademy.SDK.TasksXRKit.AutoHandDetectors
{
    public class AutoHandGrabDetector : XRGrabDetector
    {
        private Grabbable autoHandgrabbable = default;


        ///////////////////////////////////////////////////////////////////////////
        private void OnEnable()
        {
            if (!initialized)
            {
                Init();
                autoHandgrabbable = grabbable.GetComponent<Grabbable>();
            }

            autoHandgrabbable.OnGrabEvent += GrabStart;
            autoHandgrabbable.OnReleaseEvent += GrabEnd;
            autoHandgrabbable.OnHighlightEvent += HoverStart;
            autoHandgrabbable.OnUnhighlightEvent += HoverEnd;
        }

        ///////////////////////////////////////////////////////////////////////////
        private void OnDisable()
        {
            autoHandgrabbable.OnGrabEvent -= GrabStart;
            autoHandgrabbable.OnReleaseEvent -= GrabEnd;
            autoHandgrabbable.OnHighlightEvent -= HoverStart;
            autoHandgrabbable.OnUnhighlightEvent -= HoverEnd;
        }

        ///////////////////////////////////////////////////////////////////////////
        private void GrabStart(Hand hand, Grabbable obj)
        {
            OnGrabStart.Invoke();
        }

        ///////////////////////////////////////////////////////////////////////////
        private void GrabEnd(Hand hand, Grabbable obj)
        {
            OnGrabEnd.Invoke();
        }

        ///////////////////////////////////////////////////////////////////////////
        private void HoverStart(Hand hand, Grabbable obj)
        {
            OnHoverStart.Invoke();
        }

        ///////////////////////////////////////////////////////////////////////////
        private void HoverEnd(Hand hand, Grabbable obj)
        {
            OnHoverStart.Invoke();
        }
    }
}
