using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerDronnMove
{
    [Header("à⁄ìÆë¨ìx")]
    [SerializeField] private float _movePower = 3f;

    [Header("ë¨ìxêäëﬁë¨ìx")]
    [SerializeField] private float _moveSpeedDiray = 1f;


    private PlayerDronnControl _playerControl;

    public void Init(PlayerDronnControl control)
    {
        _playerControl = control;
    }


    public void StopMove()
    {
        Vector2 dir = -_playerControl.Rb.velocity;

        _playerControl.Rb.AddForce(dir.normalized * _moveSpeedDiray);

        //X
        if (_playerControl.Rb.velocity.x < 0.1f && _playerControl.Rb.velocity.x > -0.1f)
        {
            _playerControl.Rb.velocity = new Vector3(0, _playerControl.Rb.velocity.y, _playerControl.Rb.velocity.z);
        }

        //Y
        if (_playerControl.Rb.velocity.y < 0.1f && _playerControl.Rb.velocity.y > -0.1f)
        {
            _playerControl.Rb.velocity = new Vector3(_playerControl.Rb.velocity.x, 0, _playerControl.Rb.velocity.z);
        }
    }


    public void Move()
    {
        var h = _playerControl.InputManager.GetValue<float>(InputType.MoveHorizontal);
        var v = _playerControl.InputManager.GetValue<float>(InputType.InputVertical);

        var velo = new Vector2(h, v);

        _playerControl.Rb.AddForce(velo * _movePower);

        if (h > 0)
        {
            _playerControl.DroneSpriteObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (h < 0)
        {
            _playerControl.DroneSpriteObject.transform.localScale = new Vector3(-1, 1, 1);
        }

    }
}
