using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEducationDisplay : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text studentsText;
    [SerializeField] private TMP_Text teachersText;

    private void Start()
    {

        if (EducationManager.Instance == null) return;

        
        UpdateUI(0, EducationManager.Instance.maxStudents,
               0, EducationManager.Instance.maxTeachers);

        EducationManager.Instance.OnDataUpdated.AddListener(UpdateUI);
    }

    private void UpdateUI(int students, int maxStudents, int teachers, int maxTeachers)
    {
        studentsText.text = $"Students: {students}/{maxStudents}";
        teachersText.text = $"Teachers: {teachers}/{maxTeachers}";
    }
}
