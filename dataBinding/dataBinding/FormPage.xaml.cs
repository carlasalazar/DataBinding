using System.Text;
using System.Text.Json;

namespace dataBinding;

public partial class FormPage : ContentPage
{
	public FormPage()
	{
		InitializeComponent();
        FechaNacimientoPicker.Date = DateTime.Now;
	}

    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        // Recoger los datos del formulario
        var nombre = NombreEntry.Text;
        var apellido = ApellidoEntry.Text;
        var sexo = SexoPicker.SelectedItem?.ToString();
        var fechaNacimiento = FechaNacimientoPicker.Date.ToString("yyyy-MM-dd");
        var idRol = IdRolEntry.Text;

        // Validar que todos los campos están completos
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
            string.IsNullOrEmpty(sexo) || string.IsNullOrEmpty(idRol))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        // Crear el objeto que contiene los datos
        var persona = new
        {
            nombre = nombre,
            apellido = apellido,
            sexo = sexo,
            fh_nac = fechaNacimiento,
            id_rol = int.Parse(idRol)
        };

        // Convertir el objeto a JSON
        var jsonContent = new StringContent(JsonSerializer.Serialize(persona), Encoding.UTF8, "application/json");

        // Hacer la solicitud POST al servidor
        var client = new HttpClient();
        try
        {

            var response = await client.PostAsync("https://fi.jcaguilar.dev/v1/escuela/persona", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Datos guardados correctamente.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al guardar los datos.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }
}