using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clothes.Domain.Entities;

[Table("user_address")]
public class UserAddress(Guid userId, int addressId)
{
    [Key] 
    [Required] 
    [Column("user_id")] 
    public Guid UserId { get; init; } = userId;

    [Key]
    [Required]
    [Column("address_id")]
    public int AddressId { get; init; } = addressId;
}