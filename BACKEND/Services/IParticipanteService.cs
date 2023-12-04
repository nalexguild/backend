// Services/IParticipanteService.cs
public interface IParticipanteService
{
    List<Participante> ObtenerTodos();

    void Agregar(Participante participante);

    Participante ObtenerPorId(int id);


    void Actualizar(Participante participante);
}

