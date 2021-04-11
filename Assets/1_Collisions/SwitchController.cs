using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(TextMeshPro), typeof(Collider))]
public class SwitchController : MonoBehaviour
{
    [SerializeField] private UnityEvent onActivated = null;
    [SerializeField] private UnityEvent onDeactivated = null;
    private TextMeshPro text;
    private bool isActivated;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        isActivated = false;
        text.faceColor = Color.gray;
    }

    private void OnMouseDown()
    {
        if(!isActivated)
        {
            isActivated = true;
            text.faceColor = Color.white;
            onActivated.Invoke();
        }
        else
        {
            isActivated = false;
            text.faceColor = Color.gray;
            onDeactivated.Invoke();
        }
    }
}
