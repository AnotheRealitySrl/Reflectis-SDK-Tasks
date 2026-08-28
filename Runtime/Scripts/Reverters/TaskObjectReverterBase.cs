using UnityEngine;

namespace Virtuademy.SDK.Tasks
{
    public abstract class TaskObjectReverterBase : MonoBehaviour
    {
        public abstract void Prepare(TaskSystem taskSystem);

        public abstract void Revert();
    }
}
