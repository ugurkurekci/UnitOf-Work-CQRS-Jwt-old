using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{

    [Key]
    public int ID { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; }

    public int CreateUserID { get; set; }

    public int? UpdateUserID { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

}