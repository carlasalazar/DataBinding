namespace dataBinding
{
    public class Persona
    {

        public string? nombre { get; set; } // Nombre de la persona

        public string? apellido { get; set; } // Apellido de la persona

        public string? sexo { get; set; } // Sexo: "h" (hombre) o "m" (mujer)

        public DateTime fh_nac { get; set; } // Fecha de nacimiento

        public int id_rol { get; set; } // ID del rol asociado
    }
}
