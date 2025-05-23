using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Educational Program", menuName = "Education/Educational Program")]
public class EducationalProgram : ScriptableObject
{
    [SerializeField] private int studentsCapacity;
    [SerializeField] private int teachersRequired;
    [SerializeField] private int programCost;

    public void Initialize(int students, int teachers, int cost)
    {
        studentsCapacity = students;
        teachersRequired = teachers;
        programCost = cost;
    }

  
    public int StudentsCapacity => studentsCapacity;
    public int TeachersRequired => teachersRequired;
    public int ProgramCost => programCost;
}
