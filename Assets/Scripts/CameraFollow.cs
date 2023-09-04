using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        transform.position = _player.transform.position + _offset;
    }

    void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
