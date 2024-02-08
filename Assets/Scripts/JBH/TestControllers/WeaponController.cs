using UnityEngine;

public class WeaponController : MonoBehaviour
{
    void Update()
    {
        // 마우스 포인터의 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 활의 위치를 플레이어 위치로 설정
        Vector3 bowPosition = transform.position;

        // 활의 방향을 마우스 위치로 설정
        Vector3 direction = mousePosition - bowPosition;
        direction.z = 0f; // 활은 2D 평면에서 동작하므로 z축 값을 0으로 설정

        // 활의 각도를 계산하여 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
