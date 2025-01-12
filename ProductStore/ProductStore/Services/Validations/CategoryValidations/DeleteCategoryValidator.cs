namespace ProductStore.Services.Validations.CategoryValidations
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class DeleteCategoryValidator : AbstractValidator<int>
    {
        public DeleteCategoryValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Category, int> categoryRepository)
        {
            RuleFor(id => id)
                .NotEmpty()
                .WithMessage(localizer["Validation:Category:NotFound"])
                .MustAsync(async (id, cancellation) =>
                {
                    return await categoryRepository.AnyAsync(c => c.Id == id);
                })
                .WithMessage(localizer["Validation:Category:NotFound"]);
        }
    }


}
