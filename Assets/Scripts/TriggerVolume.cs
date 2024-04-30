using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent()]
[RequireComponent(typeof(Collider))]
public class TriggerVolume : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private bool _oneShot = true;

    public UnityEvent OnEnterTrigger;

    private Collider _collider;
    private bool _alreadyEntered = false;

    [Header("Gizmo Settings")]
    [SerializeField]
    private bool _displayGizmos = false;
    [SerializeField]
    private bool _showOnlyWhileSelected = true;
    [SerializeField]
    private Color _gizmoColor = Color.green;

    [Header("Items")]
    private InventoryManager inventoryManager;
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //validate object; ie can certain things work with the trigger?
        if (_oneShot && _alreadyEntered)
            return;

        OnEnterTrigger.Invoke();
        inventoryManager.AddItem(itemName, quantity, sprite);
        Destroy(gameObject);
        _alreadyEntered = true;
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

