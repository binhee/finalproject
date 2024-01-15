using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject test;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimeDirection)
    {
        _aimDirection = newAimeDirection;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(test, projectileSpawnPosition.position,Quaternion.identity);
    }
}
