using SPACS.PLG.Graphs;

using UnityEngine;
using UnityEngine.Events;

using static SPACS.PLG.Tasks.TaskNode;

namespace SPACS.PLG.Tasks
{
    ///////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Scene component that contains a task and handles its events in the
    /// Graph System
    /// </summary>
    public class Task : NodeBehaviour<TaskNode>
    {
        [Header("Events")]
        [SerializeField, Tooltip("Invoked when the task is unlocked (status ToDo)")]
        private UnityEvent onTaskUnlocked = default;

        [SerializeField, Tooltip("Invoked when the task is completed (status Completed)")]
        private UnityEvent<bool> onTaskCompleted = default;


        ///////////////////////////////////////////////////////////////////////////
        /// <summary>Invoked when the task is unlocked (status ToDo)</summary>
        public UnityEvent OnTaskUnlocked => onTaskUnlocked;

        ///////////////////////////////////////////////////////////////////////////
        /// <summary>Invoked when the task is completed (status Completed)</summary>
        public UnityEvent<bool> OnTaskCompleted => onTaskCompleted;


        ///////////////////////////////////////////////////////////////////////////
        /// <summary>Turns the task status to ToDo</summary>
        public void UnlockTask() => Node.Status = TaskStatus.Todo;

        ///////////////////////////////////////////////////////////////////////////
        /// <summary>Turns the task status to Completed</summary>
        public void CompleteTask()
        {
            if (Node.Status == TaskStatus.Todo)
                Node.Status = TaskStatus.Completed;
        }

        ///////////////////////////////////////////////////////////////////////////
        /// <summary>Turns the task status to Failed</summary>
        public void FailTask() => Node.Status = TaskStatus.Failed;


        ///////////////////////////////////////////////////////////////////////////
        private void Awake()
        {
            OnStatusChanged(oldStatus: TaskStatus.Locked);
            Node.onStatusChanged.AddListener(OnStatusChanged);
        }

        ///////////////////////////////////////////////////////////////////////////
        private void OnStatusChanged(TaskStatus oldStatus)
        {
            if (Node.Status == TaskStatus.Todo)
                onTaskUnlocked.Invoke();
            else if (Node.Status == TaskStatus.Completed)
                onTaskCompleted.Invoke(true);
            else if (Node.Status == TaskStatus.Failed)
                onTaskCompleted.Invoke(false);
        }
    }
}