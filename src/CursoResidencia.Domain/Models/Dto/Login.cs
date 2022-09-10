using System.ComponentModel.DataAnnotations;

namespace CursoResidencia.Domain.Models.Dto;

public class Login
{
    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    public Login(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }

    public Login()
    {

    }
}