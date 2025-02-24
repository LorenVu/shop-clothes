using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BuildingBlock.Shared.Contracts.Domains;

namespace Clothes.Domain.Entities;
#nullable disable

[Table("sepay_transactions")]
public class SepayTransaction : EntityAuditBase<int>
{
    [JsonPropertyName("account_number")]
    [Column("account_number", TypeName = "varchar(50)")]
    public string AccountNumber { get; init; }

    [JsonPropertyName("sub_account")]
    [Column("sub_account", TypeName = "varchar(50)")]
    public string SubAccount { get; init; }

    [JsonPropertyName("transaction_content")]
    [Column("transaction_content", TypeName = "varchar(255)")]
    public string TransactionContent { get; init; }
    
    [Column("balance", TypeName = "varchar(255)")]
    public string Balance { get; init; }

    [JsonPropertyName("reference_number")]
    [Column("reference_number", TypeName = "varchar(50)")]
    public string ReferenceNumber { get; init; }

    [JsonPropertyName("bank_brand_name")]
    [Column("bank_brand_name", TypeName = "varchar(50)")]
    public string BankBrandName { get; init; }

    [JsonPropertyName("amount_in")]
    [Column("amount_in", TypeName = "varchar(50)")]
    public string AmountIn { get; init; }

    [JsonPropertyName("amount_out")]
    [Column("amount_out", TypeName = "varchar(50)")]
    public string AmountOut { get; init; }

    [JsonPropertyName("accumulated")]
    [Column("accumulated", TypeName = "varchar(50)")]
    public string Accumulated { get; init; }

    // Relationship
    [Column("bank_id")]
    public int BankId { get; set; }
    public Bank Bank { get; init; }
}