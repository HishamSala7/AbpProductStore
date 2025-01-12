namespace ProductStore.Services.Validations.CategoryValidations
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.CategoriesDtos;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        private readonly IStringLocalizer<ValidationResource> _localizer;

        public CreateCategoryValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Category, int> categoryRepository)
        {
            _localizer = localizer;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(_localizer["Validation:Category:NameRequired"])
                .MaximumLength(50)
                .WithMessage(_localizer["Validation:Category:NameMaxLength"]);

            
        }
    }


}
