using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

[RequireComponent(typeof(Rigidbody))]

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PathCreator _pathCreator;

    private Rigidbody _rigidbody;
    private float _distabceTravelled;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.MovePosition(_pathCreator.path.GetPointAtDistance(_distabceTravelled));
    }
    private void Update()
    {
        _distabceTravelled += Time.deltaTime * _speed;

        Vector3 nextPoint = _pathCreator.path.GetPointAtDistance(_distabceTravelled, EndOfPathInstruction.Loop);
        nextPoint.y = transform.position.y;

        transform.LookAt(nextPoint);
        _rigidbody.MovePosition(nextPoint);
    }

}
