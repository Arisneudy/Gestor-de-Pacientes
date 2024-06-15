using GestorDePaciente.Core.Domain.Common;
using GestorDePaciente.Core.Domain.Entities.Office;

namespace GestorDePaciente.Core.Domain.Entities.Lab;

public class ResultLabTest : BaseEntity
{
    public string Result { get; set; }
    public ResultLabTestStatus Status { get; set; }
    
    public int IdPatient { get; set; }
    public int IdLabTest { get; set; }
    
    public Patient Patient { get; set; }
    public LabTests LabTest { get; set; }
    
}

public enum ResultLabTestStatus
{
    PENDIENTE = 1,
    COMPLETADO,
}