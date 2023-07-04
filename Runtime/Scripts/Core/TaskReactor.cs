using System;
using System.Linq;

using UnityEngine;

using static Reflectis.PLG.Tasks.TaskNode;


namespace Reflectis.PLG.Tasks
{
    ///////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Utility class that enables/disables all Monobehaviours found in this
    /// gameObject according to the specified task status:
    /// - Task Unlocked: enable monobehaviours
    /// - Task Completed: disable monobehaviours
    /// </summary>
    public class TaskReactor : MonoBehaviour
    {
        [NonSerialized]
        private Task task = default;

        [NonSerialized]
        private MonoBehaviour[] behaviours;

        ///////////////////////////////////////////////////////////////////////////
        private void Awake()
        {
            task = GetComponentInParent<Task>();
            behaviours = GetComponents<MonoBehaviour>()
                .Where(component => component != this && component)
                .ToArray();
        }

        ///////////////////////////////////////////////////////////////////////////
        private void OnEnable()
        {
            task.Node.onStatusChanged.AddListener(OnTaskStatusChanged);
            OnTaskStatusChanged(task.Node.Status);
        }

        ///////////////////////////////////////////////////////////////////////////
        private void OnDisable()
        {
            task.Node.onStatusChanged.RemoveListener(OnTaskStatusChanged);
        }

        ///////////////////////////////////////////////////////////////////////////
        private void OnTaskStatusChanged(TaskStatus oldStatus)
        {
            bool shouldBeEnabled = task.Node.Status == TaskStatus.Todo;
            foreach (MonoBehaviour behaviour in behaviours)
            {
                if (behaviour)
                    behaviour.enabled = shouldBeEnabled;
            }
        }
    }
}