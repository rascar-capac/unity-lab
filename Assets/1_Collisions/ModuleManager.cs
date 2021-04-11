using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    [SerializeField] private PhysicsPropertiesController controller1 = null;
    [SerializeField] private PhysicsPropertiesController controller2 = null;



    public void ResetModule()
    {
        controller1?.Reset();
        controller2?.Reset();
    }
}
