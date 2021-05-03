using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoList
{
    class ToDoListViewModel
    {
        // Ejecuta la funcion para agregar tarea
        public ICommand AddNewTaskCommand => new Command(AddTask);
        // Ejecuta la funcion para remover tarea
        public ICommand DeleteTaskCommand => new Command(DeleteTask);
        // Ejecuta la funcion para actualizar tarea
        public ICommand UpdateTaskCommand => new Command(UpdateTask);

        // Crea una coleccion que guardara todas las tareas
        public ObservableCollection<string> Tasks { get; set; }
       
        // Propiedad para la descripcion de la tarea
        public string TaskDesc { get; set; }

        public string SelectedTask { get; set; }

        // Agrega tareas por defecto
        public ToDoListViewModel()
        {
            Tasks = new ObservableCollection<string>();
            Tasks.Add("Crear aplicacion iOS");
            Tasks.Add("Hacer manual tecnico");
            Tasks.Add("Grabar video");
            Tasks.Add("Entregar tareas");
        }
        
        // Funcion para agregar tarea
        public void AddTask()
        {
            if (!String.IsNullOrEmpty(TaskDesc))
            {
                Tasks.Add(TaskDesc);
            }
        }
        // Funcion para remover tarea
        public void DeleteTask()
        {
            Tasks.Remove(SelectedTask);
        }
        // Funcion para actualizar tarea
        public void UpdateTask()
        {
            // Recupera el indice y borra la tarea seleccionada
            int newItemIndex = Tasks.IndexOf(SelectedTask);
            Tasks.Remove(SelectedTask);

            // Agrega la nueva tarea con la descripcion actual
            Tasks.Add(TaskDesc);
            int oldItemIndex = Tasks.IndexOf(TaskDesc);

            // Reordena las tareas
            Tasks.Move(oldItemIndex, newItemIndex);
        }
    }
}
