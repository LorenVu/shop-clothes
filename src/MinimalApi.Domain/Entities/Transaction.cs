using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Transactions")]
public class Transaction : EntityAuditBase<int>
{
    [JsonPropertyName("account_number")]
    [Column("AccountNumber", TypeName = "varchar(50)")]
    public string AccountNumber { get; set; }
    
    [JsonPropertyName("sub_account")]
    [Column("SubAccount", TypeName = "varchar(50)")]
    public string SubAccount { get; set; }
    
    [JsonPropertyName("transaction_content")]
    [Column("TransactionContent", TypeName = "varchar(255)")]
    public string TransactionContent { get; set; }
    public string Balance { get; set; }
    
    [JsonPropertyName("reference_number")]
    [Column("ReferenceNumber", TypeName = "varchar(50)")]
    public string ReferenceNumber { get; set; }
   
    [JsonPropertyName("bank_brand_name")]
    [Column("BankBrandName", TypeName = "varchar(50)")]
    public string BankBrandName { get; set; }
    
    [JsonPropertyName("amount_in")]
    public string AmountIn { get; set; }
    
    [JsonPropertyName("amount_out")]
    public string AmountOut { get; set; }
    
    [JsonPropertyName("accumulated")]
    public string Accumulated { get; set; }
    
    // Relationship
    public int BankId { get; set; }
    public Bank Bank { get; set; } = null!;
}