using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{

    [Key]

    public int ID { get; set; }

    public string EMail { get; set; }

    public string Password { get; set; }

    public DateTime CreateDate { get; set; }

}
