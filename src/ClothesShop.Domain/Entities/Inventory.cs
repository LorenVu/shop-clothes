using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;
using Clothes.Domain.Enums;

namespace Clothes.Domain.Entities;

[Table("inventories")]
public class Inventory : EntityAuditBase<string>
{
    public Inventory(EDocumentType documentType, string documentNo, string itemNo)
    {
        DocumentType = documentType;
        DocumentNo = documentNo;
        ItemNo = itemNo;
    }

    [Column("document_type")]
    public EDocumentType DocumentType { get; private set; }

    [Column("document_no", TypeName = "varchar(100)")]
    public string DocumentNo { get; private set; }

    [Column("item_no", TypeName = "varchar(100)")]
    public string ItemNo { get; private set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("external_document_no", TypeName = "varchar(100)")]
    public string? ExternalDocumentNo { get; set; }
}