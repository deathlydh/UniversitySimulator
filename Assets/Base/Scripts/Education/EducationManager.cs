using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EducationManager : MonoBehaviour
{
    [System.Serializable]
    public class EducationDataEvent : UnityEvent<int, int, int, int> { }

    public static EducationManager Instance;

    [Header("Capacity Settings")]
    [SerializeField] public int maxStudents = 200;
    [SerializeField] public int maxTeachers = 32;

    [Header("Programs")]
    [SerializeField] private List<EducationalProgram> programs = new List<EducationalProgram>();

    public EducationDataEvent OnDataUpdated = new EducationDataEvent();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            UpdateEducationData();
        }
        
    }

    public void AddProgram(EducationalProgram program)
    {
        programs.Add(program);
        UpdateEducationData();
    }

    public void RemoveProgram(EducationalProgram program)
    {
        programs.Remove(program);
        UpdateEducationData();
    }

    public void UpdateEducationData()
    {
        int totalStudents = 0;
        int totalTeachers = 0;

        if (programs != null && programs.Count > 0)
        {
            foreach (var program in programs)
            {
                totalStudents += program.StudentsCapacity;
                totalTeachers += program.TeachersRequired;
            }
        }

        OnDataUpdated.Invoke(totalStudents, maxStudents, totalTeachers, maxTeachers);

        OnDataUpdated.Invoke(
          totalStudents,
          maxStudents,
          totalTeachers,
          maxTeachers
      );
    }
}
