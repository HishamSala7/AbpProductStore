namespace ProductStore.Services.Validations.ProductValidaions
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class DeleteProductValidator : AbstractValidator<int>
    {
        public DeleteProductValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Product, int> productRepository)
        {
            RuleFor(id => id)
                .NotEmpty()
                .WithMessage(localizer["Validation:Product:NotFound"])
                .MustAsync(async (id, cancellation) =>
                {
                    return await productRepository.AnyAsync(p => p.Id == id);
                })
                .WithMessage(localizer["Validation:Product:NotFound"]);
        }
    }


}
