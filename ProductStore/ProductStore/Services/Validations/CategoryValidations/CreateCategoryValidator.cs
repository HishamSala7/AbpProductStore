namespace ProductStore.Services.Validations.CategoryValidations
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.CategoriesDtos;
    using Serilog;
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
                .WithMessage(_localizer["NameRequired"])
                .MaximumLength(50)
                .WithMessage(_localizer["FirstNameLength"]);

            /*RuleFor(x => x.Name)
                .MustAsync(async (name, cancellation) =>
                {
                    return await categoryRepository.FirstOrDefaultAsync(c => c.Name == name) == null;
                })
                .WithMessage(_localizer["Validation:Category:NameUnique"]);*/
        }
    }


}
