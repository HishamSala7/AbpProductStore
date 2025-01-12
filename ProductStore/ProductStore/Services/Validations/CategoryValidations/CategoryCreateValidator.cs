namespace ProductStore.Services.Validations.CategoryValidations
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.CategoriesDtos;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class CategoryCreateValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryCreateValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Category, int> categoryRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizer["Validation:Category:NameRequired"])
                .MaximumLength(50)
                .WithMessage(localizer["Validation:Category:NameMaxLength"]);

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellation) =>
                {
                    return await categoryRepository.FirstOrDefaultAsync(c => c.Name == name) == null;
                })
                .WithMessage(localizer["Validation:Category:NameUnique"]);
        }
    }


}
