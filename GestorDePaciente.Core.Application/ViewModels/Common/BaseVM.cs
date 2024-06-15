using System.ComponentModel.DataAnnotations;

namespace GestorDePaciente.Core.Application.ViewModels.Common;

public class BaseVM
{
    public int Id { get; set; }
    
    public DateTime DateCreated { get; set; }
}