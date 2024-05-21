﻿using Reflectis.PLG.Graphs;
using Reflectis.PLG.Tasks.Detectors;
using UnityEngine;
using UnityEngine.Events;
using static Reflectis.PLG.Tasks.TaskNode;

namespace Reflectis.PLG.Tasks
{
    ///////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Scene component that contains a task and handles its events in the
    /// Graph System
    /// </summary>
    public class Task : NodeBehaviour<TaskNode>, ITaskNode<TaskNode>
    {
        public TaskNode Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        [Header("Events")]
        [SerializeField, Tooltip("Invoked when the task is unlocked (status ToDo)")]
        protected UnityEvent onTaskUnlocked = default;

        [SerializeField, Tooltip("Invoked when the task is completed (status Completed)")]
        protected UnityEvent<bool> onTaskCompleted = default;


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
        protected virtual void OnStatusChanged(TaskStatus oldStatus)
        {
            if (Node.Status == TaskStatus.Todo)
                onTaskUnlocked.Invoke();
            else if (Node.Status == TaskStatus.Completed)
                onTaskCompleted.Invoke(true);
            else if (Node.Status == TaskStatus.Failed)
                onTaskCompleted.Invoke(false);
        }

        public virtual void AddDetector()
        {
            GameObject go = new GameObject("TaskListener");
            go.transform.SetParent(gameObject.transform);
            go.AddComponent<TaskListener>();
        }
    }
}