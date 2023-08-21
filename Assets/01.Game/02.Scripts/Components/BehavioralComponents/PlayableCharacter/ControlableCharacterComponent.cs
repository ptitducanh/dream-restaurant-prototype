using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Components;
using UnityEngine;

public class ControlableCharacterComponent : BehavioralComponent
{
    [SerializeField] private Joystick joystick;

    private Animator              _animator;
    private CharacterController   _characterController;
    private MovementStatComponent _movementStatComponent;
    
    #region lifecycle methods
    public override void OnAwake()
    {
        base.OnAwake();

        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _movementStatComponent = Entity.GetDataComponent<MovementStatComponent>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _animator.SetFloat("speed", _characterController.velocity.magnitude);    
            
        var joyStickDirection = joystick.Direction;
        var movingDirection = new Vector3(joyStickDirection.x, 0, joyStickDirection.y);
        
        _characterController.Move(movingDirection * Time.deltaTime * _movementStatComponent.GetFloatStat("MaxSpeed"));

        if (movingDirection.magnitude > float.Epsilon)
        { 
            _characterController.transform.LookAt(_characterController.transform.position + movingDirection);
        }
    }

    #endregion

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction);
    }

    #region event handlers

    

    #endregion
}
