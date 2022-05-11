using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    private PlayerMovement _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (_player.IsAlive() && _player.IsReady())
        {
            transform.position -= Vector3.left * -_speed * Time.deltaTime;
        }
        if(gameObject.transform.position.x <= -10) { Destroy(gameObject); }
    }
}
