using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class NavControl : MonoBehaviour
{
    public GameObject _target;
    public NavMeshAgent _agent;
    bool isWalking = true;
    private Animator _animator;

    [SerializeField] float animSpeed = 1.0f;
    [SerializeField] float navSpeed = 0.95f;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        if (animSpeed != 1.0f)
        {
            navSpeed = (animSpeed * 0.95f);
        }
        else if (navSpeed != 0.95f)
        {
            animSpeed = (navSpeed * 1.05f);
        }
        else
        {
            animSpeed = (navSpeed * 1.05f);
        }

        _animator.speed = animSpeed;    
        _agent.speed = navSpeed;
    }

    void Update()
    {
        if (_target != null && isWalking)
        {
            _agent.destination = _target.transform.position;
        }
        else
        {
            _agent.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = false;
            _agent.updateRotation = false;

            _animator.speed = 1.0f;
            _animator.SetTrigger("ATTACK");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = true;
            _agent.updateRotation = true;

            _animator.speed = animSpeed;
            _animator.SetTrigger("WALK");
        }
    }
}
