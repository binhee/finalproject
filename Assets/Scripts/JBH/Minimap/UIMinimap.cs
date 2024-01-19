using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMinimap : MonoBehaviour
{
    [SerializeField] private Camera minimapCamera;
    [SerializeField] private float zoomMin = 1;     // 카메라 최소 크기
    [SerializeField] private float zoomMax = 3;    // 카메라 최대 크기
    [SerializeField] private float zoomOneStep = 1; // 카메라 1회 줌 할 때 증가, 감소 수치
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
