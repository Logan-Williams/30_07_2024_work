using System.ComponentModel.DataAnnotations;

namespace _30_07_2024_work.DTOs;

public class DelitePersonRequest
{
    [Required]
    public int Id { get; set; }
}
