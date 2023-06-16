using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float HorizontalMove => Input.GetAxis("Horizontal");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    #region On Inspector
    [SerializeField] private float _speed;
    #endregion

    private Rigidbody2D _rigidbody;
}
