using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACS.Tasks;

public class SetTaskStepSetterIndex : MonoBehaviour
{
    public int index;

    private void Start()
    {
        var stepSetter = GetComponent<TaskStepSetter>();
        stepSetter.SetStepIndex(index);
        stepSetter.InitDefaultStep();
    }
}
