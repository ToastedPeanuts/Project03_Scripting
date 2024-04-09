using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent()]
[RequireComponent(typeof(Collider))]
public class TriggerVolume : MonoBehaviour
{
    public UnityEvent OnEnterTrigger;

    private Collider _collider;

    [Header("Gizmo Settings")]
    [SerializeField]
    private bool _displayGizmos = false;
    [SerializeField]
    private bool _showOnlyWhileSelected = true;
    [SerializeField]
    private Color _gizmoColor = Color.green;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //validate object; ie can certain things work with the trigger?
        
        OnEnterTrigger.Invoke();
    }

    private void OnDrawGizmos()
    {
        if (_displayGizmos == false)
            return;
        if (_showOnlyWhileSelected == true)
            return;

        if (_collider == null)
            _collider = GetComponent<Collider>();

        Gizmos.color = _gizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }

    private void OnDrawGizmosSelected()
    {
        if (_displayGizmos == false)
            return;
        if (_showOnlyWhileSelected == false)
            return;

        if (_collider == null)
            _collider = GetComponent<Collider>();

        Gizmos.color = _gizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }

}

