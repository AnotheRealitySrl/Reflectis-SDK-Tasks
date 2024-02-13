using Reflectis.PLG.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Reflectis.SDK.CreatorKit
{
    [UnitTitle("Trigger Complete Task")]
    [UnitSurtitle("Task")]
    [UnitShortTitle("Trigger Complete Task")]
    [UnitCategory("Events\\Reflectis\\Task")]
    [TypeIcon(typeof(Material))]
    public class CompleteTaskNode : Unit
    {
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput inputTrigger { get; private set; }
        [DoNotSerialize]
        [PortLabelHidden]
        public ControlOutput outputTrigger { get; private set; }

        protected override void Definition()
        {
            inputTrigger = ControlInput(nameof(inputTrigger), (f) =>
            {
                if (f.stack.gameObject.GetComponent<Task>())
                    f.stack.gameObject.GetComponent<Task>().CompleteTask();
                else
                    Debug.LogError("[Reflectis Creator Kit] You are triggering a Complete Task Node while you don't have Task Component", f.stack.gameObject);

                return outputTrigger;
            });

            outputTrigger = ControlOutput(nameof(outputTrigger));

            Succession(inputTrigger, outputTrigger);
        }
    }
}
