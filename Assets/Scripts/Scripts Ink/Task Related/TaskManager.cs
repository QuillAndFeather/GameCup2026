using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance; //Created instance of the task manager

    [Header("Task Lists")]

    public List<TaskSO> tasks = new(); //List of currently active tasks that will display on the to do list
    public List<TaskSO> inactiveTasks = new(); //List of currently inactive tasks that can reappear after (x) [Figure out what x is with others]

    [SerializeField] int taskCompletionThreshold; //Number of tasks that have to be completed for the game to end

    [SerializeField] TMP_Text testText; //Temp for testing


    private void Awake()
    {
        instance = this; //Set the instance of the task manager
    }


    private void Start()
    {
        //Testing
        DisplayTasks(testText);
    }

    // Task Addition and Removal

    public void AddInactiveTask(Predicate<TaskSO> taskToAdd)
    {
        int taskRefIndex = tasks.FindIndex(taskToAdd); //Identify the index at which the task is located within the active list

        inactiveTasks.Add(tasks[taskRefIndex]); //Move the designated task to the inactive tasks list

        tasks.RemoveAt(taskRefIndex); //Remove the specified index of the found reference index
    }

    public void RemoveActiveTask(Predicate<TaskSO> taskToRemove)
    {
        int taskRefIndex = inactiveTasks.FindIndex(taskToRemove); //Identify the index at which the task is located within the inactive list

        tasks.Add(inactiveTasks[taskRefIndex]); //Move the designated task to the active tasks list

        inactiveTasks.RemoveAt(taskRefIndex); //Remove the specified index of the found reference index
    }


    // Task Completion

    public void MarkTaskComplete(Predicate<TaskSO> taskToComplete)
    {
        int completedTaskIndex = tasks.FindIndex(taskToComplete); //Find the index of the task that was just completed

        tasks[completedTaskIndex].bComplete = true; //Mark the task as complete

        //Complete a check if all tasks have been completed, should this mark the end of this game
        bool bWin = ChecklistComplete();

        Debug.Log(bWin);
    }

    public bool ChecklistComplete()
    {
        int completeMarks = 0; //Initial counter

        for (int task = 0; task < tasks.Count; task++)
        {
            if (tasks[task].bComplete) completeMarks++; //Increment if the task was completed
        }

        if (completeMarks == taskCompletionThreshold)
        {
            Debug.Log("Game win");
            return true;
        }

        return false;
    }


    // Task Displaying

    public void DisplayTasks(TMP_Text textField)
    {
        //Reset the text field
        textField.text = ""; 

        //Loop through all the active tasks to display
        for (int task = 0; task < tasks.Count; task++)
        {
            string taskToAdd = tasks[task].taskRequirement; //Grab the string to add

            textField.text += $"- {taskToAdd} \n"; //Add to the text field appropriately
        }
    }


    // Task Checks

    //Check if there is currently that task in the active task list
    public bool bContainsTask(TaskSO searchTask)
    {
        if(tasks.Contains(searchTask)) return true;

        return false;
    }
}
