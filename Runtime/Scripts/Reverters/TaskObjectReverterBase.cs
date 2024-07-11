﻿using UnityEngine;

namespace Reflectis.PLG.Tasks
{
    public abstract class TaskObjectReverterBase : MonoBehaviour
    {
        public abstract void Prepare(TaskSystem taskSystem);

        public abstract void Revert();
    }
}
