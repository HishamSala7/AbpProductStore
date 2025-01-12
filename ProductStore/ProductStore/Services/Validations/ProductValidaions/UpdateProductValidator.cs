namespace ProductStore.Services.Validations.ProductValidaions
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.ProductDtos;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Product, int> productRepository, IRepository<Category, int> categoryRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(localizer["Validation:Product:NotFound"]);
                /*.MustAsync(async (id, cancellation) =>
                {
                    return await productRepository.AnyAsync(p => p.Id == id);
                })
                .WithMessage(localizer["Validation:Product:NotFound"]);*/

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizer["Validation:Product:NameRequired"])
                .MaximumLength(100)
                .WithMessage(localizer["Validation:Product:NameMaxLength"]);

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage(localizer["Validation:Product:PricePositive"]);

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer["Validation:Product:StockNonNegative"]);

            /*RuleFor(x => x.CategoryId)
                .MustAsync(async (categoryId, cancellation) =>
                {
                    return await categoryRepository.AnyAsync(c => c.Id == categoryId);
                })
                .WithMessage(localizer["Validation:Category:NotFound"]);*/
        }
    }

}
