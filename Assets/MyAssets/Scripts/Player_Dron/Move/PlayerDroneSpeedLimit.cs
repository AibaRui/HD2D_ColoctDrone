using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDroneSpeedLimit
{
    [Header("êßå¿ê›íË")]
    [SerializeField] private List<SpeedLimit> _limits = new List<SpeedLimit>();

    private float _limitX = 1;
    private float _limitPlusY = 1;
    private float _limitMinusY = -1;
    private float _limitZ = 1;


    private PlayerDronnControl _playerControl;

    public void Init(PlayerDronnControl control)
    {
        _playerControl = control;
    }

    public void SetSpeed(DroneSpeedLimit limit)
    {
        foreach (var speedLimit in _limits)
        {
            if (speedLimit.Limit == limit)
            {
                _limitX = speedLimit.LimitX;
                _limitPlusY = speedLimit.LimitPlussY;
                _limitMinusY = speedLimit.LimitMinussY;
                _limitZ = speedLimit.LimitZ;
            }
            break;
        }
    }

    public void LimitSpeed()
    {
        //X
        if (_playerControl.Rb.velocity.x > _limitX)
        {
            _playerControl.Rb.velocity = new Vector3(_limitX, _playerControl.Rb.velocity.y, _playerControl.Rb.velocity.z);
        }
        if (_playerControl.Rb.velocity.x < -_limitX)
        {
            _playerControl.Rb.velocity = new Vector3(-_limitX, _playerControl.Rb.velocity.y, _playerControl.Rb.velocity.z);
        }

        //Y
        if (_playerControl.Rb.velocity.x > _limitPlusY)
        {
            _playerControl.Rb.velocity = new Vector3(_playerControl.Rb.velocity.x, _limitPlusY, _playerControl.Rb.velocity.z);
        }
        if (_playerControl.Rb.velocity.x < _limitMinusY)
        {
            _playerControl.Rb.velocity = new Vector3(_playerControl.Rb.velocity.x, _limitMinusY, _playerControl.Rb.velocity.z);
        }

        //Z
        if (_playerControl.Rb.velocity.x > _limitZ)
        {
            _playerControl.Rb.velocity = new Vector3(_playerControl.Rb.velocity.x, _playerControl.Rb.velocity.y, _limitZ);
        }
        if (_playerControl.Rb.velocity.x < -_limitZ)
        {
            _playerControl.Rb.velocity = new Vector3(_playerControl.Rb.velocity.x, _playerControl.Rb.velocity.y, -_limitZ);
        }




    }


}

public enum DroneSpeedLimit
{
    Idle,
    Move,
}


[System.Serializable]
public class SpeedLimit
{
    [SerializeField] private string _name;

    [Header("êßå¿")]
    [SerializeField] private DroneSpeedLimit _limit;

    [Header("X")]
    [SerializeField] private float _limitX;

    [Header("Y+")]
    [SerializeField] private float _limitPlussY;

    [Header("Y-")]
    [SerializeField] private float _limitMinussY;

    [Header("Z")]
    [SerializeField] private float _limitZ;

    public DroneSpeedLimit Limit => _limit;

    public float LimitX => _limitX;

    public float LimitPlussY => _limitPlussY;

    public float LimitMinussY => _limitMinussY;

    public float LimitZ => _limitZ;


}