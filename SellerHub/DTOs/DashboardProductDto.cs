namespace SellerHub.DTOs
{
    public record DashboardProductDto(
        int ProductId,
        string ProductCode,
        string Name,
        decimal Price,
        int Stock,
        int TotalSold,
        string StockStatus,
        string Visibility
    );


    public record CreateProductCategoryDto(string Name);
    public record ProductCategoryDto(int Id, string Name);

    public record BulkEditProductDto(
    List<int> ProductIds,
    List<int>? CategoryIds = null,
    int? Stock = null,
    decimal? Price = null,
    string? Visibility = null
);


}
