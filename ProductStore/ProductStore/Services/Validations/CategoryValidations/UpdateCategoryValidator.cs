namespace ProductStore.Services.Validations.CategoryValidations
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.CategoriesDtos;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Category, int> categoryRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(localizer["Validation:Category:NotFound"]);
                /*.MustAsync(async (id, cancellation) =>
                {
                    return await categoryRepository.AnyAsync(c => c.Id == id);
                })
                .WithMessage(localizer["Validation:Category:NotFound"]);*/

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizer["Validation:Category:NameRequired"])
                .MaximumLength(50)
                .WithMessage(localizer["Validation:Category:NameMaxLength"]);
        }
    }


}
