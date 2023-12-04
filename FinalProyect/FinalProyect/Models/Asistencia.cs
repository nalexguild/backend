using System.ComponentModel.DataAnnotations;

public class Asistencia
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ParticipanteId { get; set; }

    [Required]
    public int ConferenciaId { get; set; }

    [Required]
    public bool ConfirmacionAsistencia { get; set; }

    public Participante Participante { get; set; }

    public Conferencia Conferencia { get; set; }
}
