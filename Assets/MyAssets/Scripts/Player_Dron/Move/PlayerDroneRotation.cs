using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDroneRotation 
{
    [Header("�E��ړ����̊p�x")]
    [SerializeField] private Vector3 _rightUp = new Vector3(0, 0, 20);
    [Header("�E���ړ����̊p�x")]
    [SerializeField] private Vector3 _rightDown = new Vector3(0, 0, -20);

    [Header("����ړ����̊p�x")]
    [SerializeField] private Vector3 _leftUp = new Vector3(0, 0, -20);
    [Header("�����ړ����̊p�x")]
    [SerializeField] private Vector3 _leftDown = new Vector3(0, 0, 20);

    [Header("�E�ړ���")]
    [SerializeField] private Vector3 _right = new Vector3(0, 0, 10);

    [Header("���ړ���")]
    [SerializeField] private Vector3 _left = new Vector3(0, 0, -10);

    [Header("��]���x")]
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

        //�p�x�ݒ�
        Quaternion r = default;
        Quaternion targetR = default;

        //�E�ړ�
        if (h > 0)
        {
            Debug.Log("�E");
            if (v > 0)
            {
                r = Quaternion.Euler(_rightUp);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //��
            else if (v < 0)
            {
                r = Quaternion.Euler(_rightDown);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //��
            else
            {
                r = Quaternion.Euler(_right);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }//��
        }
        else if (h < 0)
        {
            Debug.Log("��");

            if (v > 0)
            {
                r = Quaternion.Euler(_leftUp);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //��
            else if (v < 0)
            {
                r = Quaternion.Euler(_leftDown);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }   //��
            else
            {
                r = Quaternion.Euler(_left);
                targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
            }//��
        }
        else
        {
            Debug.Log("����");
            r = Quaternion.Euler(Vector3.zero);
            targetR = Quaternion.RotateTowards(_playerControl.DroneBoddy.transform.localRotation, r, Time.deltaTime * _rotateSpeed);
        }


        _playerControl.DroneBoddy.transform.localRotation = targetR;
    }

}
