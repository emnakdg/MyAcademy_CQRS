using CQRSProject.CQRSPattern.Handlers.CategoryHandlers;
using CQRSProject.CQRSPattern.Handlers.ProductHandlers;
using CQRSProject.CQRSPattern.Handlers.SliderHandlers;
using CQRSProject.CQRSPattern.Handlers.ContactHandlers;
using CQRSProject.CQRSPattern.Handlers.OrderHandlers;
using CQRSProject.CQRSPattern.Handlers.TestimonialHandlers;
using CQRSProject.CQRSPattern.Handlers.PromotionHandlers;
using CQRSProject.CQRSPattern.Handlers.PhotoGalleryHandlers;
using CQRSProject.CQRSPattern.Handlers.CampaignHandlers;
using CQRSProject.Patterns.Observer;
using CQRSProject.Patterns.Observer.Events;
using CQRSProject.Patterns.Observer.Handlers;
using CQRSProject.Patterns.UnitOfWork;
using CQRSProject.Services;
using System.Reflection;

namespace CQRSProject.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddCQRSHandlers(this IServiceCollection services)
        {
            #region categoryHandlers
            services.AddScoped<GetCategoriesQueryHandler>();
            services.AddScoped<GetCategoriesByIdQueryHandler>();
            services.AddScoped<UpdateCategoriesCommandHandler>();
            services.AddScoped<CreateCategoriesCommandHandler>();
            services.AddScoped<RemoveCategoriesCommandHandler>();
            #endregion

            #region productHandlers
            services.AddScoped<GetProductsQueryHandler>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();
            #endregion

            #region sliderHandlers
            services.AddScoped<CreateSliderCommandHandler>();
            services.AddScoped<UpdateSliderCommandHandler>();
            services.AddScoped<RemoveSliderCommandHandler>();
            services.AddScoped<GetSlidersQueryHandler>();
            services.AddScoped<GetSliderByIdQueryHandler>();
            #endregion

            #region contactHandlers
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<GetContactsQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            #endregion

            #region orderHandlers
            services.AddScoped<CreateOrderCommandHandler>();
            services.AddScoped<GetOrdersQueryHandler>();
            services.AddScoped<GetOrderByIdQueryHandler>();
            #endregion

            #region testimonialHandlers
            services.AddScoped<GetTestimonialsQueryHandler>();
            services.AddScoped<GetTestimonialByIdQueryHandler>();
            services.AddScoped<CreateTestimonialCommandHandler>();
            services.AddScoped<UpdateTestimonialCommandHandler>();
            services.AddScoped<RemoveTestimonialCommandHandler>();
            #endregion

            #region promotionHandlers
            services.AddScoped<GetPromotionsQueryHandler>();
            services.AddScoped<GetPromotionByIdQueryHandler>();
            services.AddScoped<CreatePromotionCommandHandler>();
            services.AddScoped<UpdatePromotionCommandHandler>();
            services.AddScoped<RemovePromotionCommandHandler>();
            #endregion

            #region photoGalleryHandlers
            services.AddScoped<GetPhotoGalleriesQueryHandler>();
            services.AddScoped<GetPhotoGalleryByIdQueryHandler>();
            services.AddScoped<CreatePhotoGalleryCommandHandler>();
            services.AddScoped<UpdatePhotoGalleryCommandHandler>();
            services.AddScoped<RemovePhotoGalleryCommandHandler>();
            #endregion

            #region campaignHandlers
            services.AddScoped<GetCampaignsQueryHandler>();
            services.AddScoped<GetCampaignByIdQueryHandler>();
            services.AddScoped<CreateCampaignCommandHandler>();
            services.AddScoped<UpdateCampaignCommandHandler>();
            services.AddScoped<RemoveCampaignCommandHandler>();
            #endregion
        }

        public static void AddPackageExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void AddDesignPatterns(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, Patterns.UnitOfWork.UnitOfWork>();

            services.AddSingleton<IEventPublisher>(sp =>
            {
                var publisher = new EventPublisher();
                
                var orderHandler = new OrderEventHandler(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<OrderEventHandler>());
                var campaignHandler = new CampaignEventHandler(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<CampaignEventHandler>());
                var contactHandler = new ContactEventHandler(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<ContactEventHandler>());

                publisher.Subscribe(orderHandler);
                publisher.Subscribe(campaignHandler);
                publisher.Subscribe(contactHandler);

                return publisher;
            });

            services.AddScoped<ICloudStorageService, CloudinaryStorageService>();
        }
    }
}
