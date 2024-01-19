using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMinimap : MonoBehaviour
{
    [SerializeField] private Camera minimapCamera;
    [SerializeField] private float zoomMin = 1;     // ī�޶� �ּ� ũ��
    [SerializeField] private float zoomMax = 3;    // ī�޶� �ִ� ũ��
    [SerializeField] private float zoomOneStep = 1; // ī�޶� 1ȸ �� �� �� ����, ���� ��ġ
    [SerializeField] private TextMeshProUGUI textMapName;

    private void Awake()
    {
        textMapName.text = SceneManager.GetActiveScene().name;
    }

    public void ZoomIn()
    {
        minimapCamera.orthographicSize = Mathf.Max(minimapCamera.orthographicSize - zoomOneStep, zoomMin);
    }

    public void ZoomOut()
    {
        minimapCamera.orthographicSize = Mathf.Min(minimapCamera.orthographicSize + zoomOneStep, zoomMax);
    }
}
