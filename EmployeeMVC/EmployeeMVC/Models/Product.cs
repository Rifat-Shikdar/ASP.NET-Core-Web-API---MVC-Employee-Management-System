namespace EmployeeMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public object? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? UnitName { get; set; }
        public string? Name { get; set; }
        public string? LocalName { get; set; }
        public string? Code { get; set; }
        public object? ParentCode { get; set; }
        public string? ProductBarcode { get; set; }
        public string? Description { get; set; }
        public string? BrandName { get; set; }
        public string? SizeName { get; set; }
        public string? ColorName { get; set; }
        public object? ModelName { get; set; }
        public object? VariantName { get; set; }
        public double? OldPrice { get; set; }
        public double? Price { get; set; }
        public double? CostPrice { get; set; }
        public List<object>? WarehouseList { get; set; }
        public double? stock { get; set; }
        public double? TotalPurchase { get; set; }
        public string? LastPurchaseDate { get; set; }
        public string? LastPurchaseSupplier { get; set; }
        public double? TotalSales { get; set; }
        public string? LastSalesDate { get; set; }
        public string? LastSalesCustomer { get; set; }
        public object? ImagePath { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public double? CommissionAmount { get; set; }
        public double? CommissionPer { get; set; }
        public double? PCTN { get; set; }
    }


}
