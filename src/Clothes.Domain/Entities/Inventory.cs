using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Common;
using MinimalApi.Domain.Enums;

namespace MinimalApi.Domain.Entities;

[Table("Inventories")]
public class Inventory : EntityAuditBase<string>
{
    public Inventory(string itemNo, string documentNo)
    {
        ItemNo = itemNo;
        DocumentNo = documentNo;
    }

    public EDocumentType DocumentType { get; set; }
    
    public string DocumentNo { get; set; }
    
    public string ItemNo { get; set; }
    
    public int Quantity { get; set; }
    
    public string?  ExternalDocumentNo { get; set; }
}