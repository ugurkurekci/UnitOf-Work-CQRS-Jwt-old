using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{

    [Key]
    public int ID { get; set; }

    public int CategoryID { get; set; }

    public int Stock { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int CreateUserID { get; set; }

    public int? UpdateUserID { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

}