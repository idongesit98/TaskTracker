using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace TaskTracker.Repository
{
    public class TaskRepository
    {
        private string filePath = "tasks.json";

        public List<Task> LoadTask()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath,"[]"); //initialize with an empty json array
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Task>>(json);
        }

        public void SaveTask(List<Task> tasks)
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(filePath,json);
        }

        //Add Task
        public void AddTask(string description)
        {
            List<Task> tasks = LoadTask();
            int newId = tasks.Count > 0 ? tasks[tasks.Count - 1].Id + 1 : 1; //explain this code
            Task newTask = new Task
            { 
                Id = newId, 
                Description = description, 
                Status = "To Do", 
                CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now
            };
            tasks.Add(newTask);
            SaveTask(tasks);
            Console.WriteLine($"Tasks added. Task Id: {newTask.Id}");
        }

        //Update a task's status
        public void UpdateTask(int id, string newStatus, string? newDescription = null)
        {

            List<Task> tasks = LoadTask();
            Task task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                //update description only if a new one is provided
                if(!string.IsNullOrEmpty(newDescription))
                {
                task.Description = newDescription;
                }
                task.Status = newStatus;
                SaveTask(tasks);
                Console.WriteLine("Task Updated.");
            }
            else
            {
                Console.WriteLine("Task not found");
            }
        }
        
        //Delete a task by it's Id
        public void DeleteTask(int id)
        {
            List<Task> tasks = LoadTask();
            Task task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);
                SaveTask(tasks);
                Console.WriteLine("Task deleted");
            } 
            else
            {
                Console.WriteLine("Task not found");
            }
        }

        //List tasks(with optional filter)
        public void ListTasks(string filter = null)
        {
            List<Task> tasks = LoadTask();
            foreach (var task in tasks)
            {
                if(filter == null || task.Status.Equals(filter, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{task.Id}. {task.Description} - {task.Status} - Created at: {task.CreatedAt}");
                }
            }
        }

        public void summary()
        {
            List<Task> tasks = LoadTask();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            Console.WriteLine("Summaries");

            foreach (var task in tasks)
            {
                if (task != null)
                {         
                    Console.WriteLine($"{task.Id}.{task.Description} - {task.Status} {task.CreatedAt}");
                }
            }
        }
    }
}