using System.Collections.ObjectModel;
using JAbarcaS5.Models;

namespace JAbarcaS5.Vistas;

public partial class ViPersona : ContentPage
{
    //public ObservableCollection<Persona> Personass { get; set; }

    public ViPersona()
	{
		InitializeComponent();
       // Personass = new ObservableCollection<Persona>();
       // BindingContext = this;


    }

    void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    void btnObtener_Clicked(System.Object sender, System.EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> person = App.personRepo.getAllPeople();
        ListaPersona.ItemsSource = person;
        lblStatus.Text = App.personRepo.StatusMessage;
        /*Personass.Clear();
        var people = App.personRepo.getAllPeople();
        foreach (var person in people)
        {
            Personass.Add(person);
        }*/

    }

    void btnEditar_Clicked(System.Object sender, System.EventArgs e)
    {
        // Aquí deberías obtener el ID de la persona seleccionada en la lista y el nuevo nombre de alguna manera
        string id = txtIdSelect.Text; // Obtén el ID de la persona seleccionada
        string newName = txtName.Text; // Obtén el nuevo nombre

        App.personRepo.EditPerson(newName, id);
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
    {
        // Se obtiene el ID de la persona seleccionada en la lista
        string id = txtIdSelect.Text; // Obtén el ID de la persona seleccionada

        App.personRepo.DropPerson(id);
        lblStatus.Text = App.personRepo.StatusMessage;
    }

    private void ListaPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            // Obtener la persona seleccionada
            Persona selectedPerson = (Persona)e.CurrentSelection.FirstOrDefault();

            if (selectedPerson != null)
            {
                // Capturar el ID y el nombre de la persona seleccionada
                string id = Convert.ToString(selectedPerson.Id);
                string name = selectedPerson.Name;

                // Asignar el nombre al Entry para editar
                txtName.Text = name;
                txtIdSelect.Text = id;
            }
        }
    }

    void ListaPersona_SelectionChanged_1(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
    }
}
