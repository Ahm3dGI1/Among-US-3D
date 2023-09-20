using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{

    [SerializeField] private Transform _interactPoint;
    [SerializeField] private float _interactRadius = 0.5f;
    [SerializeField] private LayerMask _interactableLayer;

    [SerializeField] private UnityEngine.UI.Image interactBtn;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _colliderCount;

    public bool isTasking = false;


    private void Update()
    {
        _colliderCount = Physics.OverlapSphereNonAlloc(_interactPoint.position, _interactRadius, _colliders, _interactableLayer);

        if (_colliderCount > 0)
        {
            interactBtn.color = Color.white;
            isTasking = _colliders[0].GetComponent<Task_initiator>().isTasking;
        }
        else
        {
            interactBtn.color = Color.grey;
        }

        if (Input.GetKeyDown(KeyCode.E) && _colliderCount > 0)
        {
            _colliders[0].GetComponent<Task_initiator>().StartTask();
        }

        if (Input.GetKeyDown(KeyCode.Space) && _colliderCount > 0)
        {
            _colliders[0].GetComponent<Task_initiator>().EndTask();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactPoint.position, _interactRadius);
    }
}
