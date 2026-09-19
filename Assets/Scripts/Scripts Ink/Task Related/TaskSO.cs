using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Listed Task")]
public class TaskSO : ScriptableObject
{
    public bool bComplete = false; //Has this task been completed?

    public bool bIntermissionComplete = false; //Has the intermission of this task been completed?

    public string taskRequirement = ""; //What is the condition of completing this task?

    public string taskLocation = ""; //Where is this task located?
}
