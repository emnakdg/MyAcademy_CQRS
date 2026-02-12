using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.ProductCommands;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(AppDbContext context, IMapper mapper, Services.ICloudStorageService cloudStorage)
    {
        public async Task Handle(UpdateProductCommand command)
        {
            var product = mapper.Map<Product>(command);
            
            if (command.ImageFile != null)
            {
                product.ImageUrl = await cloudStorage.UploadAsync(command.ImageFile.OpenReadStream(), command.ImageFile.FileName, command.ImageFile.ContentType);
            }

            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
