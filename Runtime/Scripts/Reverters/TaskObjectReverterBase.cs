using UnityEngine;

namespace Reflectis.SDK.Tasks
{
    public abstract class TaskObjectReverterBase : MonoBehaviour
    {
        public abstract void Prepare(TaskSystem taskSystem);

        public abstract void Revert();
    }
}
