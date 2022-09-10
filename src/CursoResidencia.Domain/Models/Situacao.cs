using System.ComponentModel;

namespace CursoResidencia.Domain.Models;

public enum Situacao
{
    [Description("Inativo")]
    Inativo = 0,
    [Description("Ativo")]
    Ativo = 1
}