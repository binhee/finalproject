using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject projectilePrefab;      // 발사체 프리팹
    public int projectilePoolSize = 10;      // 발사체 풀 크기    
    private Vector2 projectileForce;

    private List<GameObject> projectilePool; // 발사체 오브젝트 풀    

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        InitializeProjectilePool();
    }

    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        CreateProjectileFromPool();
    }

    // 발사체 오브젝트 풀을 초기화하는 메서드
    private void InitializeProjectilePool()
    {
        projectilePool = new List<GameObject>();

        for (int i = 0; i < projectilePoolSize; i++)
        {            
            GameObject projectile = Instantiate(projectilePrefab, Vector3.zero, Quaternion.identity);
            projectile.SetActive(false);
            projectilePool.Add(projectile);
        }
    }

    // 오브젝트 풀에서 발사체를 가져와 활성화하는 메서드
    private void CreateProjectileFromPool()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                // 발사체의 위치와 회전 설정
                projectilePool[i].transform.position = projectileSpawnPosition.position;

                // 조준 방향을 기반으로 각도 계산
                float angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;

                // 발사체의 회전 설정
                projectilePool[i].transform.rotation = Quaternion.Euler(0, 0, angle);

                // 발사체의 Rigidbody2D를 얻어와서 정규화된 방향에 발사체 속도를 설정
                Rigidbody2D projectileRigidbody = projectilePool[i].GetComponent<Rigidbody2D>();
                projectileRigidbody.AddForce(_aimDirection.normalized * projectileForce, ForceMode2D.Impulse);

                // 발사체 활성화
                projectilePool[i].SetActive(true);
                break;
            }
        }
    }
}