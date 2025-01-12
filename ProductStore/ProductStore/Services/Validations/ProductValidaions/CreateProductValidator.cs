namespace ProductStore.Services.Validations.ProductValidaions
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.ReadProductDtos;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Category, int> categoryRepository, IRepository<Product, int> productRepository)
        {
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

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage(localizer["Validation:Product:CategoryIdRequired"])
                .MustAsync(async (categoryId, cancellation) =>
                {
                    return await categoryRepository.AnyAsync(c => c.Id == categoryId);
                })
                .WithMessage(localizer["Validation:Category:NotFound"]);

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellation) =>
                {
                    return await productRepository.FirstOrDefaultAsync(p => p.Name == name) == null;
                })
                .WithMessage(localizer["Validation:Product:NameUnique"]);
        }
    }


}
