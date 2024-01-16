using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject projectilePrefab;      // �߻�ü ������
    public int projectilePoolSize = 10;      // �߻�ü Ǯ ũ��    
    private Vector2 projectileForce;

    private List<GameObject> projectilePool; // �߻�ü ������Ʈ Ǯ    

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

    // �߻�ü ������Ʈ Ǯ�� �ʱ�ȭ�ϴ� �޼���
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

    // ������Ʈ Ǯ���� �߻�ü�� ������ Ȱ��ȭ�ϴ� �޼���
    private void CreateProjectileFromPool()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                // �߻�ü�� ��ġ�� ȸ�� ����
                projectilePool[i].transform.position = projectileSpawnPosition.position;

                // ���� ������ ������� ���� ���
                float angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;

                // �߻�ü�� ȸ�� ����
                projectilePool[i].transform.rotation = Quaternion.Euler(0, 0, angle);

                // �߻�ü�� Rigidbody2D�� ���ͼ� ����ȭ�� ���⿡ �߻�ü �ӵ��� ����
                Rigidbody2D projectileRigidbody = projectilePool[i].GetComponent<Rigidbody2D>();
                projectileRigidbody.AddForce(_aimDirection.normalized * projectileForce, ForceMode2D.Impulse);

                // �߻�ü Ȱ��ȭ
                projectilePool[i].SetActive(true);
                break;
            }
        }
    }
}