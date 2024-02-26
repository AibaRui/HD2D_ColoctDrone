using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDroneRotation 
{
    [Header("右上移動時の角度")]
    [SerializeField] private Vector3 _rightUp = new Vector3(0, 0, 20);
    [Header("右下移動時の角度")]
    [SerializeField] private Vector3 _rightDown = new Vector3(0, 0, -20);

    [Header("左上移動時の角度")]
    [SerializeField] private Vector3 _leftUp = new Vector3(0, 0, -20);
    [Header("左下移動時の角度")]
    [SerializeField] private Vector3 _leftDown = new Vector3(0, 0, 20);

    [Header("右移動時")]
    [SerializeField] private Vector3 _right = new Vector3(0, 0, 10);

    [Header("左移動時")]
    [SerializeField] private Vector3 _left = new Vector3(0, 0, -10);

    [Header("回転速度")]
    [SerializeField] private float _rotateSpeed = 200;


    private PlayerDronnControl _playerControl;

    public void Init(PlayerDronnControl control)
    {
        _playerControl = control;
    }



    public void Rotation()
    {
        var h = _playerControl.InputManager.GetValue<float>(InputType.MoveHorizontal);
        var v = _playerControl.InputManager.GetValue<float>(InputType.InputVertical);

        //角度設定
        Quaternion r = default;
        Quaternion targetR = default;

        //右移動
        if (h > 0)
        {
            Debug.Log("右");
            if (v > 0)
            {
                r = Quaternion.Euler(_rightUp);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //上
            else if (v < 0)
            {
                r = Quaternion.Euler(_rightDown);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //下
            else
            {
                r = Quaternion.Euler(_right);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }//横
        }
        else if (h < 0)
        {
            Debug.Log("左");

            if (v > 0)
            {
                r = Quaternion.Euler(_leftUp);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //上
            else if (v < 0)
            {
                r = Quaternion.Euler(_leftDown);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //下
            else
            {
                r = Quaternion.Euler(_left);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }//横
        }
        else
        {
            Debug.Log("ぜろ");
            r = Quaternion.Euler(Vector3.zero);
            targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
        }


        _playerControl.DroneBoddy.transform.localRotation = targetR;
    }

}
