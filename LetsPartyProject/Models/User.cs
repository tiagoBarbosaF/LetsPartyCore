using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LetsPartyProject.Models
{
  public class User
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(2, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string Name { get; set; }

    [MinLength(2, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string Nickname { get; set; }

    [Required]
    [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(2, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
    public string Sector { get; set; }
    public int DDD { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public int TeamId { get; set; }
    public string Confirm { get; set; }

    public Team Team { get; set; }
  }
}

