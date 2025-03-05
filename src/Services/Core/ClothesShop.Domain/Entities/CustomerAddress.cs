using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clothes.Domain.Entities;

[Table("customer_address")]
public class CustomerAddress(Guid customerId, int addressId)
{
    [Key]
    [Required]
    [Column("customer_id")]
    public Guid CustomerId { get; private set; } = customerId;

    [Key]
    [Required]
    [Column("address_id")]
    public int AddressId { get; private set; } = addressId;
}