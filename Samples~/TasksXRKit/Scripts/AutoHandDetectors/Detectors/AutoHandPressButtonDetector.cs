using Autohand;

using Virtuademy.SDK.Tasks.XRDetectors;

namespace Virtuademy.SDK.TasksXRKit.AutoHandDetectors
{
    public class AutoHandPressButtonDetector : XRPressButtonDetector
    {
        private PhysicsGadgetButton autoHandButton;

        private void OnEnable()
        {
            if (!initialized)
            {
                Init();
                autoHandButton = button.GetComponent<PhysicsGadgetButton>();
            }

            autoHandButton.OnPressed.AddListener(OnPressed.Invoke);
            autoHandButton.OnUnpressed.AddListener(OnUnpressed.Invoke);
        }

        private void OnDisable()
        {
            autoHandButton.OnPressed.RemoveListener(OnPressed.Invoke);
            autoHandButton.OnUnpressed.RemoveListener(OnUnpressed.Invoke);
        }
    }
}
