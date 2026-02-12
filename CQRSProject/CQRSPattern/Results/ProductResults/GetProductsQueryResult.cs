using CQRSProject.CQRSPattern.Results.CategoryResults;

namespace CQRSProject.CQRSPattern.Results.ProductResults;

public record GetProductsQueryResult(int Id,
                                     string Name, 
                                     string Description, 
                                     decimal Price, 
                                     string ImageUrl, 
                                     int CategoryId, 
                                     GetCategoriesQueryResult Category);