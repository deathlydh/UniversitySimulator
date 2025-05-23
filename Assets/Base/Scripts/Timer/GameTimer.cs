using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float realSecondsPerYear = 60f; // Реальных секунд на 1 игровой год
    [SerializeField] private bool showProgressInTime = false; // Показывать "1 год 3/12" вместо процентов

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

                // Проверка завершения года
                if (currentYearTime >= realSecondsPerYear)
                {
                    currentYear++;
                    currentYearTime = 0f;
                    Debug.Log($"Year {currentYear} started!");
                    // Здесь можно вызвать годовые события
                }
            }
            yield return null;
        }
    }

    private void UpdateUI()
    {
        // Прогресс года (0-1)
        float progress = currentYearTime / realSecondsPerYear;

        // Обновление кругового индикатора
        if (progressCircle != null)
        {
            progressCircle.fillAmount = progress;
        }

        // Форматирование текста
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

    // === Управление таймером ===
    public void SetPause(bool pause)
    {
        isTimerRunning = !pause;
    }

    public void SetGameSpeed(float speedMultiplier)
    {
        Time.timeScale = speedMultiplier; // 1 = нормально, 2 = 2x speed
    }

    public void ResetTimer()
    {
        currentYear = 1;
        currentYearTime = 0f;
        UpdateUI();
    }
}
