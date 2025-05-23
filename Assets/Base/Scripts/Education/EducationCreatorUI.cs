using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EducationCreatorUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject creationPanel;
    [SerializeField] private TMP_InputField studentsInput;
    [SerializeField] private TMP_InputField teachersInput;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Button createButton;
    [SerializeField] private TMP_Text errorText;

    [Header("Settings")]
    [SerializeField] private int costPerStudent = 100;
    [SerializeField] private int costPerTeacher = 500;

    private int currentCost;

    private void Start()
    {
        creationPanel.SetActive(false);
        createButton.onClick.AddListener(TryCreateProgram);
        studentsInput.onValueChanged.AddListener(CalculateCost);
        teachersInput.onValueChanged.AddListener(CalculateCost);
    }

    public void ToggleCreationMenu()
    {
        creationPanel.SetActive(!creationPanel.activeSelf);
        errorText.text = "";
    }

    private void CalculateCost(string _)
    {
        int students = int.Parse(studentsInput.text.Length > 0 ? studentsInput.text : "0");
        int teachers = int.Parse(teachersInput.text.Length > 0 ? teachersInput.text : "0");

        currentCost = students * costPerStudent + teachers * costPerTeacher;
        costText.text = $"Cost: {currentCost}";
    }

    private void TryCreateProgram()
    {
        if (!EconomyManager.Instance.CanAfford(currentCost))
        {
            errorText.text = "Not enough money!";
            return;
        }

        var newProgram = ScriptableObject.CreateInstance<EducationalProgram>();
        newProgram.Initialize(
            int.Parse(studentsInput.text),
            int.Parse(teachersInput.text),
            currentCost
        );

        EconomyManager.Instance.SpendMoney(currentCost);
        EducationManager.Instance.AddProgram(newProgram);
        ToggleCreationMenu();
    }
}
