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

    [SerializeField] TMP_Text taskText; //Text to display tasks

    [SerializeField] GameObject taskList; //Display of the task list


    private void Awake()
    {
        instance = this; //Set the instance of the task manager
    }


    private void Start()
    {
        //Testing
        RandomizeTasks();
        DisplayTasks(taskText);
    }

    // Task Addition and Removal

    public void AddInactiveTask(TaskSO taskToAdd)
    {
        int taskRefIndex = tasks.IndexOf(taskToAdd); //Identify the index at which the task is located within the active list

        inactiveTasks.Add(tasks[taskRefIndex]); //Move the designated task to the inactive tasks list

        tasks.RemoveAt(taskRefIndex); //Remove the specified index of the found reference index

        DisplayTasks(taskText); //Update the task list
    }

    public void RemoveActiveTask(TaskSO taskToRemove)
    {
        int taskRefIndex = inactiveTasks.IndexOf(taskToRemove); //Identify the index at which the task is located within the inactive list

        tasks.Add(inactiveTasks[taskRefIndex]); //Move the designated task to the active tasks list

        inactiveTasks.RemoveAt(taskRefIndex); //Remove the specified index of the found reference index

        DisplayTasks(taskText); //Update the task list
    }

    public void RandomizeTasks()
    {
        List<TaskSO> randomize = new(tasks); //Create a copy of the list

        int loops = randomize.Count; //Get the loop count

        tasks.Clear(); //Clear the list

        for (int task = 0; task < loops; task++)
        {
            int index = UnityEngine.Random.Range(0, randomize.Count);

            tasks.Add(randomize[index]);

            randomize.RemoveAt(index);
        }
    }


    // Task Completion

    public void MarkTaskComplete(TaskSO taskToComplete)
    {
        int completedTaskIndex = tasks.IndexOf(taskToComplete); //Find the index of the task that was just completed

        tasks[completedTaskIndex].bComplete = true; //Mark the task as complete

        DisplayTasks(taskText); //Update the task list

        //Complete a check if all tasks have been completed, should this mark the end of this game
        bool bWin = ChecklistComplete();

        //Debug.Log(bWin); //testing purposes
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
            Application.Quit(); //Temporary, but quit the game
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
            string taskToAdd;

            if (tasks[task].bComplete) taskToAdd = tasks[task].taskLocation + "\n" + "-------------------" + "\n" + $"<s>{tasks[task].taskRequirement}</s>"; //Grab the string to add

            else taskToAdd = tasks[task].taskLocation + "\n" + "-------------------" + "\n" + tasks[task].taskRequirement; //Grab the string to add

            textField.text += $"{taskToAdd} \n \n"; //Add to the text field appropriately
        }
    }


    // Task Checks

    //Check if there is currently that task in the active task list
    public bool bContainsTask(TaskSO searchTask)
    {
        if(tasks.Contains(searchTask)) return true;

        return false;
    }

    // Enabling and Disabling Task List

    public void EnableTaskList()
    {
        taskList.SetActive(true);
    }

    public void DisableTaskList()
    {
        taskList.SetActive(false);
    }
}
