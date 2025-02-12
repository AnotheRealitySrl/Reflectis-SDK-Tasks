using UnityEngine;

namespace Reflectis.SDK.Tasks.XRDetectors
{
    [CreateAssetMenu(menuName = "Reflectis/SDK-Tasks/DetectorsConfig", fileName = "DetectorsConfig")]
    public abstract class DetectorsSystemConfig : ScriptableObject
    {
        public abstract void AddActivation(GameObject detector);
        public abstract void AddClimb(GameObject detector);
        public abstract void AddGrabber(GameObject detector);
        public abstract void AddGrab(GameObject detector);
        public abstract void AddLever(GameObject detector);
        public abstract void AddPlace(GameObject detector);
        public abstract void AddPressButton(GameObject detector);
        public abstract void AddRotation(GameObject detector);
        public abstract void AddSlider(GameObject detector);
        public abstract void AddTeleport(GameObject detector);
    }
}
