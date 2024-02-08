using UnityEngine;

public class WeaponController : MonoBehaviour
{
    void Update()
    {
        // ���콺 �������� ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Ȱ�� ��ġ�� �÷��̾� ��ġ�� ����
        Vector3 bowPosition = transform.position;

        // Ȱ�� ������ ���콺 ��ġ�� ����
        Vector3 direction = mousePosition - bowPosition;
        direction.z = 0f; // Ȱ�� 2D ��鿡�� �����ϹǷ� z�� ���� 0���� ����

        // Ȱ�� ������ ����Ͽ� ȸ��
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
