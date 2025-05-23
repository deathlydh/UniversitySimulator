using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float realSecondsPerYear = 60f; // �������� ������ �� 1 ������� ���
    [SerializeField] private bool showProgressInTime = false; // ���������� "1 ��� 3/12" ������ ���������

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image progressCircle;

    private float currentYearTime = 0f;
    private int currentYear = 1;
    private bool isTimerRunning = true;

    void Start()
    {
        StartCoroutine(YearCycle());
    }

    IEnumerator YearCycle()
    {
        while (true)
        {
            if (isTimerRunning)
            {
                currentYearTime += Time.deltaTime;
                UpdateUI();

                // �������� ���������� ����
                if (currentYearTime >= realSecondsPerYear)
                {
                    currentYear++;
                    currentYearTime = 0f;
                    Debug.Log($"Year {currentYear} started!");
                    // ����� ����� ������� ������� �������
                }
            }
            yield return null;
        }
    }

    private void UpdateUI()
    {
        // �������� ���� (0-1)
        float progress = currentYearTime / realSecondsPerYear;

        // ���������� ��������� ����������
        if (progressCircle != null)
        {
            progressCircle.fillAmount = progress;
        }

        // �������������� ������
        if (showProgressInTime)
        {
            int months = Mathf.FloorToInt(progress * 12);
            timerText.text = $"Year {currentYear}\n{months + 1}/12";
        }
        else
        {
            timerText.text = $"Year {currentYear}\n{Mathf.FloorToInt(progress * 100)}%";
        }
    }

    // === ���������� �������� ===
    public void SetPause(bool pause)
    {
        isTimerRunning = !pause;
    }

    public void SetGameSpeed(float speedMultiplier)
    {
        Time.timeScale = speedMultiplier; // 1 = ���������, 2 = 2x speed
    }

    public void ResetTimer()
    {
        currentYear = 1;
        currentYearTime = 0f;
        UpdateUI();
    }
}
