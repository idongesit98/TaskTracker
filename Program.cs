// See https://aka.ms/new-console-template for more information
using TaskTracker.Repository;

TaskRepository repo = new TaskRepository();
if(args.Length == 0)
{
    Console.WriteLine("Usage: [add/update/delete/summary] [arguments]");
    return;
}

string command = args[0].ToLower();

switch (command)
{
    case "add":
        if (args.Length > 1)
            repo.AddTask(args[1]);
        else 
            Console.WriteLine("Description required for adding a task.");    
        break;

    case "update":
        if(args.Length > 2 && int.TryParse(args[1], out int id))
        {
            string status = args[2];
            string description = args.Length > 3 ? args[3] : null;
            repo.UpdateTask(id, status, description);
        }
        else
            Console.WriteLine("Valid task ID, status and decription required for updating");
        break;

    case "delete":
        if(args.Length > 1 && int.TryParse(args[1], out id))
           repo.DeleteTask(id);
        else
           Console.WriteLine("Valid task ID and status required for updating.");
        break;

    case "list":
        string filter = args.Length > 1 ? args[1].ToLower():null;
        if(filter == "done" || filter == "in-progress" || filter == "to-do")
            repo.ListTasks(filter);
        else 
            repo.ListTasks();
        break;  

    case "summary":
        repo.summary();              
        break;

    default:
       Console.WriteLine("Invalid Command");
       break;
}
