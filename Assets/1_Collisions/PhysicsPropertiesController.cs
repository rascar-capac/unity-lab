using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPropertiesController : MonoBehaviour
{
    [SerializeField] private ModuleManager _module = null;
    [SerializeField] private GameObject _target = null;
    [SerializeField] private GameObject _spherePrefab = null;
    [SerializeField] private GameObject _boxPrefab = null;
    [SerializeField] private Material _transparentMaterial = null;
    [SerializeField] private Light _lightBulb = null;
    private Transform _targetTransform;
    private Vector3 _initialPosition;
    private Collider _collider;
    private MeshRenderer _renderer;
    private Material _initialMaterial;
    private Rigidbody _rigidbody;
    private LightBulbActivator _lightBulbActivator;
    private bool _isKinematic;
    private bool _useGravity;
    private bool _isTrigger;
    private bool _hasLightTrigger;
    private bool _hasLightCollision;



    public void SetTrigger(bool isTrigger)
    {
        if(_collider)
        {
            _isTrigger = isTrigger;
            if(_collider)
            {
                _collider.isTrigger = isTrigger;
            }
            if(_renderer)
            {
                _renderer.material = (isTrigger ? _transparentMaterial : _initialMaterial);
            }
        }
        _module?.ResetModule();
    }

    public void SetRigidbody(bool hasRigidbody)
    {
        if(hasRigidbody)
        {
            Destroy(_target);
            _target = Instantiate(_spherePrefab, _initialPosition, Quaternion.identity);
            _targetTransform = _target.transform;
            _collider = _target.GetComponent<Collider>();
            _collider.isTrigger = _isTrigger;
            _renderer = _target.GetComponent<MeshRenderer>();
            if(_renderer)
            {
                _initialMaterial = _renderer.material;
                _renderer.material = (_isTrigger ? _transparentMaterial : _initialMaterial);
            }
            _rigidbody = _target.GetComponent<Rigidbody>();
            if(_rigidbody)
            {
                _rigidbody.isKinematic = _isKinematic;
                _rigidbody.useGravity = _useGravity;
            }
            _lightBulbActivator = _target.GetComponent<LightBulbActivator>();
            if(_lightBulbActivator)
            {
                _lightBulbActivator.LightBulb = _lightBulb;
                _lightBulbActivator.DetectTrigger = _hasLightTrigger;
                _lightBulbActivator.DetectCollision = _hasLightCollision;
            }
        }
        else
        {
            Destroy(_target);
            _target = Instantiate(_boxPrefab, _initialPosition, Quaternion.identity);
            _targetTransform = _target.transform;
            _collider = _target.GetComponent<Collider>();
            _collider.isTrigger = _isTrigger;
            _renderer = _target.GetComponent<MeshRenderer>();
            if(_renderer)
            {
                _initialMaterial = _renderer.material;
                _renderer.material = (_isTrigger ? _transparentMaterial : _initialMaterial);
            }
            _lightBulbActivator = _target.GetComponent<LightBulbActivator>();
            if(_lightBulbActivator)
            {
                _lightBulbActivator.LightBulb = _lightBulb;
                _lightBulbActivator.DetectTrigger = _hasLightTrigger;
                _lightBulbActivator.DetectCollision = _hasLightCollision;
            }
        }
        _module?.ResetModule();
    }

    public void SetKinematic(bool isKinematic)
    {
        _isKinematic = isKinematic;
        if(_rigidbody)
        {
            _rigidbody.isKinematic = isKinematic;
        }
        _module?.ResetModule();
    }

    public void SetGravity(bool useGravity)
    {
        _useGravity = useGravity;
        if(_rigidbody)
        {
            _rigidbody.useGravity = useGravity;
        }
        _module?.ResetModule();
    }

    public void SetLightTrigger(bool hasLightTrigger)
    {
        if(_lightBulbActivator)
        {
            _hasLightTrigger = hasLightTrigger;
            _lightBulbActivator.DetectTrigger = hasLightTrigger;
        }
        _module?.ResetModule();
    }

    public void SetLightCollision(bool hasLightCollision)
    {
        if(_lightBulbActivator)
        {
            _hasLightCollision = hasLightCollision;
            _lightBulbActivator.DetectCollision = hasLightCollision;
        }
        _module?.ResetModule();
    }

    public void Reset()
    {
        _targetTransform.position = _initialPosition;
        _targetTransform.rotation = Quaternion.identity;
        if(_rigidbody)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        if(_lightBulb)
        {
            _lightBulb.enabled = false;
        }
    }



    private void Awake()
    {
        _targetTransform = _target.transform;
        _initialPosition = _targetTransform.position;
        _collider = _target.GetComponent<Collider>();
        _renderer = _target.GetComponent<MeshRenderer>();
        if(_renderer)
        {
            _initialMaterial = _renderer.material;
        }
        _rigidbody = _target.GetComponent<Rigidbody>();
        _lightBulbActivator = _target.GetComponent<LightBulbActivator>();
        if(_lightBulbActivator)
        {
            _lightBulbActivator.LightBulb = _lightBulb;
        }
    }
}
