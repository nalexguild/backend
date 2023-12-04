using System.ComponentModel.DataAnnotations;

    public class Conferencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Conferencista { get; set; }
    }


