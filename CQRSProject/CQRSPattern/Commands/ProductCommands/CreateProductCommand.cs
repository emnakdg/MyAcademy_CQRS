namespace CQRSProject.CQRSPattern.Commands.ProductCommands;

public record CreateProductCommand(string Name,
                                   string Description,
                                   decimal Price,
                                   string ImageUrl,
                                   int CategoryId,
                                   Microsoft.AspNetCore.Http.IFormFile? ImageFile);
