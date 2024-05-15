
//Nueva funcion de C# que me permite darle valores a los metodos ahi mismo. 
// En este caso hace que no me muestre error porque la variable este vacia al comenzar 
List<string> TaskList = new();  //Nombramiento 

//  string s="This is my string"; 
// s.Replace("this","my string now"); 
//Console.WriteLine(s);

int mainMenuVariable = 0;
do
{
    mainMenuVariable = ShowMainMenu();
    if ((EnumMenu)mainMenuVariable == EnumMenu.Add)
    {
        ShowMenuAdd();
    }
    else if ((EnumMenu)mainMenuVariable == EnumMenu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((EnumMenu)mainMenuVariable == EnumMenu.List)
    {
        ShowMenuTaskList();
    }
} while ((EnumMenu)mainMenuVariable != EnumMenu.Exit);

void ShowTaskList()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    TaskList.ForEach(p => Console.WriteLine($"{++indexTask} . {p}"));
    Console.WriteLine("----------------------------------------");

}
//Show the option for task 
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string menuSelected = Console.ReadLine();
    return Convert.ToInt32(menuSelected);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowTaskList();
        string taskNumberToDelete = Console.ReadLine();
        // Remove one position because the array starts in 0 
        int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;
        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
        {
            Console.WriteLine("Numero ingresado no valido");

        }
        else
        {


            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                //string task = TaskList[indexToRemove]; No era necesario, principio KISS
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {TaskList[indexToRemove]} eliminada");

            }
        }

    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea ");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string task = Console.ReadLine();
        TaskList.Add(task);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception e)
    {
        throw e;
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        ShowTaskList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

enum EnumMenu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}

