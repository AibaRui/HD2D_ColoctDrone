using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Windows;

public class PlayerDronnControl : MonoBehaviour
{

    [Header("ドローンの本体オブジェクトアニメーション")]
    [SerializeField] private Animator _animDroneBody;

    [Header("ドローンの本体オブジェクト")]
    [SerializeField] private GameObject _droneBody;

    [Header("ドローンの絵のオブジェクト")]
    [SerializeField] private GameObject _droneSpriteObject;

    [SerializeField] private Transform _playerT;

    [SerializeField] private Transform _modelT;

    [SerializeField] private Rigidbody _rb;

    [Header("アニメーション設定")]
    [SerializeField] private PlayerDroneAnimatorControl _playerDroneAnimatorControl;

    [Header("移動設定")]
    [SerializeField] private PlayerDronnMove _move;

    [Header("速度制限")]
    [SerializeField] private PlayerDroneSpeedLimit _speedLimit;

    [Header("回転設定")]
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
