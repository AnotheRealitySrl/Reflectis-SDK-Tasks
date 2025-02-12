using Reflectis.SDK.Tasks.XRDetectors;



namespace Reflectis.SDK.TasksXRKit.XRKitDetectors
{
    public class XRKitRotationDetector : XRRotationDetector
    {
        private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactableHandle = default;

        ///////////////////////////////////////////////////////////////////////////
        protected override void Awake()
        {
            if (!initialized)
                Init();

            base.Awake();

            interactableHandle = handle.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
            interactableHandle.selectEntered.AddListener(grabber => isGrabbed = true);
            interactableHandle.selectExited.AddListener(grabber => isGrabbed = false);
            ResetTool();
        }

    }
}
