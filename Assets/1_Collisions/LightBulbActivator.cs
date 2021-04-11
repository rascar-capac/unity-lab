using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LightBulbActivator : MonoBehaviour
{
    public Light LightBulb { get => _lightBulb; set => _lightBulb = value; }
    public bool DetectTrigger { get => _detectTrigger; set => _detectTrigger = value; }
    public bool DetectCollision { get => _detectCollision; set => _detectCollision = value; }



    private Light _lightBulb;
    private bool _detectTrigger;
    private bool _detectCollision;



    private void Awake()
    {
        _detectTrigger = false;
        _detectCollision = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_detectTrigger) return;
        if(_lightBulb)
        {
            _lightBulb.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!_detectTrigger) return;
        if(_lightBulb)
        {
            _lightBulb.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!_detectCollision) return;
        if(_lightBulb)
        {
            _lightBulb.enabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(!_detectCollision) return;
        if(_lightBulb)
        {
            _lightBulb.enabled = false;
        }
    }
}
