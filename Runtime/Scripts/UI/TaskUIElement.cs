using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace SPACS.Tasks.UI
{
    ///////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Controller for an element that represents a task in the UI
    /// </summary>
    public class TaskUIElement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private TMP_Text taskName = default;

        [Header("Settings")]
        [SerializeField]
        private Color lockedColor;
        [SerializeField]
        private Color toDoColor;
        [SerializeField]
        private Color completedColor;

        [Header("Events")]
        [SerializeField]
        private UnityEvent onTaskLocked = default;

        [SerializeField]
        private UnityEvent onTaskUnlocked = default;

        [SerializeField]
        private UnityEvent onTaskCompleted = default;


        ///////////////////////////////////////////////////////////////////////////
        private TaskNode task;

        ///////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The task represented by this UI element
        /// </summary>
        public TaskNode Task
        {
            get => task;
            set
            {
                task = value;
                taskName.text = task.Description;
                switch (task.Status)
                {
                    case TaskNode.TaskStatus.Locked:
                        taskName.color = lockedColor;
                        onTaskLocked.Invoke();
                        break;
                    case TaskNode.TaskStatus.Todo:
                        taskName.color = toDoColor;
                        onTaskUnlocked.Invoke();
                        break;
                    case TaskNode.TaskStatus.Completed:
                        taskName.color = completedColor;
                        onTaskCompleted.Invoke();
                        break;
                }
            }
        }
    }
}
