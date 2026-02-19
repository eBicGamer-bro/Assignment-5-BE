using System.Reflection.Metadata;

namespace Assignment_5
{
    public enum Status
    {
        Pending,
        Completed
    }
    public class TaskItem
    {
        public string description;
        public Status status;
        public TaskItem(string description)
        {
            this.description = description;
           this.status = Status.Pending;
        }
        public void MarkAsCompleted()
        {
            if(this.status == Status.Completed) {
                Console.WriteLine("Task is already marked as completed.");
                return;
            }
            this.status = Status.Completed;
            Console.WriteLine("Task marked as completed.");
        }

    }
    public class ToDoList
    {
        public List<TaskItem> tasks;
        public ToDoList()
        {
            this.tasks = new List<TaskItem>();
        }
        public void AddTask(string description)
        {
            if (description.Length == 0)
            {
                Console.WriteLine("Description is Empty! Task not added!");
                return;
            }
            TaskItem newTask = new TaskItem(description);
            tasks.Add(newTask);
            Console.WriteLine("Task added successfully");
        }
        public void RemoveTask(int index)
        {
            if (index < tasks.Count && index >= 0)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Task removed successfully.");
            }
            else Console.WriteLine("Invalid task number.");
        }
        public void ViewTasks()
        {
            Console.WriteLine("\nYour Tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].description} - {tasks[i].status}");
            }
            Console.WriteLine("\n");
        }
        public void MarkTaskAsCompleted(int index)
        {
            if (index < tasks.Count && index >= 0)
            {
                tasks[index].MarkAsCompleted();
            }
            else Console.WriteLine("Invalid task number.");
        }
    }
    
    internal class Program
    {
        public static void Interface(ToDoList list)
        {
            Console.WriteLine("To-Do List APP");
            while (true)
            {
                int choice;
                Console.WriteLine("1. Add Task\n2. View Task\n3. Mark Task as Completed\n4. Remove Task\n5. Exit");
                do
                {
                    Console.Write("Choose an option (1-5): ");
                    if(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        continue;
                    }
                    break;

                } while (true);
                switch (choice)
                {
                    case 1: {
                                 Console.Write("Enter task description: ");
                                 list.AddTask(Console.ReadLine());
                             }break;
                    case 2: list.ViewTasks(); break;
                    case 3: {
                                 Console.Write("Enter task number to mark as completed: ");
                                 int taskNum;
                                 if (int.TryParse(Console.ReadLine(), out taskNum))
                                 {
                                     list.MarkTaskAsCompleted(taskNum - 1);
                                 }
                                 else
                                 {
                                     Console.WriteLine("Invalid Input!");
                                 }
                             }break;
                    case 4:
                        {
                            Console.Write("Enter task number to remove: ");
                            int taskNum;
                            if (int.TryParse(Console.ReadLine(), out taskNum))
                            {
                                list.RemoveTask(taskNum - 1);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input!");
                            }
                        }break;
                    case 5: return;
                    default: Console.WriteLine("Invalid choice. Please select a number between 1 and 5."); break;


                }
            }
        }
        static void Main(string[] args)
        {
           ToDoList myList = new ToDoList();
            Interface(myList);

        }
    }
}
