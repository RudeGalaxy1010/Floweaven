using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private Transform _playerBody;

    private float _mouseX;
    private float _mouseY;
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        ReadInput();
        Rotate();
    }

    private void ReadInput()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        xRotation -= _mouseY * _verticalSpeed;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    private void Rotate()
    {
        _playerBody.Rotate(Vector3.up * _mouseX * _horizontalSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
