// Models/Participante.cs
using System.ComponentModel.DataAnnotations;



    public class Participante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Email { get; set; }

        public string UsuarioTwitter { get; set; }

        [Required]
        public string Ocupacion { get; set; }

        [Required]

        public bool AceptaTerminos { get; set; }

        

    public string NombreCompleto => $"{Nombre} {Apellidos}";
    
}