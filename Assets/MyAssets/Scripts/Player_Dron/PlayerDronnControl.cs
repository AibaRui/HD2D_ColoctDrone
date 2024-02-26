using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Windows;

public class PlayerDronnControl : MonoBehaviour
{

    [Header("�h���[���̖{�̃I�u�W�F�N�g�A�j���[�V����")]
    [SerializeField] private Animator _animDroneBody;

    [Header("�h���[���̖{�̃I�u�W�F�N�g")]
    [SerializeField] private GameObject _droneBody;

    [Header("�h���[���̊G�̃I�u�W�F�N�g")]
    [SerializeField] private GameObject _droneSpriteObject;

    [SerializeField] private Transform _playerT;

    [SerializeField] private Transform _modelT;

    [SerializeField] private Rigidbody _rb;

    [Header("�A�j���[�V�����ݒ�")]
    [SerializeField] private PlayerDroneAnimatorControl _playerDroneAnimatorControl;

    [Header("�ړ��ݒ�")]
    [SerializeField] private PlayerDronnMove _move;

    [Header("���x����")]
    [SerializeField] private PlayerDroneSpeedLimit _speedLimit;

    [Header("��]�ݒ�")]
    [SerializeField] private PlayerDroneRotation _rotation;

    [SerializeField] private PlayerDronnStateMachine _stateMachine = default;
    public InputManager InputManager { get; private set; } = new InputManager();

    public PlayerDroneAnimatorControl PlayerDroneAnimatorControl => _playerDroneAnimatorControl;
    public PlayerDronnMove Move => _move;
    public PlayerDroneSpeedLimit PlayerDroneSpeedLimit => _speedLimit;
    public PlayerDroneRotation Rotation => _rotation;

    public GameObject DroneBoddy => _droneBody;
    public GameObject DroneSpriteObject => _droneSpriteObject;
    public Transform ModelT => _modelT;
    public Animator AnimDroneBody => _animDroneBody;
    public Rigidbody Rb => _rb;
    public Transform PlayerT => _playerT;

    private void Awake()
    {
        InputManager.Init();  
        _playerDroneAnimatorControl.Init(this);
        _stateMachine.Init(this);
        _move.Init(this);
        _speedLimit.Init(this);
        _rotation.Init(this);

    }

    void Start()
    {

    }

    private void OnDrawGizmosSelected()
    {

    }
    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void LateUpdate()
    {
        _stateMachine.LateUpdate();

    }


    public GameObject InstantiateObject(GameObject obj)
    {
        return Instantiate(obj);
    }



}
