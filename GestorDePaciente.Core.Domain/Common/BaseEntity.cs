namespace GestorDePaciente.Core.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    
}