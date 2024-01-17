using System.ComponentModel.DataAnnotations;

namespace Projeto_MVC_DIO.Models;

public class Contato
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;
    
    [EmailAddress(ErrorMessage = "Escreva um email válido.")]
    public string Email { get; set; } = string.Empty;
    public bool Ativo { get; set; }

}
