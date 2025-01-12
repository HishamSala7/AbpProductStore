namespace ProductStore.Services.Validations.OrderValidaions
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using Volo.Abp.Domain.Repositories;
    using Volo.Abp.Localization;

    public class DeleteOrderValidator : AbstractValidator<int>
    {
        public DeleteOrderValidator(IStringLocalizer<ValidationResource> localizer, IRepository<Order, int> orderRepository)
        {
            RuleFor(id => id)
                .NotEmpty()
                .WithMessage(localizer["Validation:Order:NotFound"]);
                /*.MustAsync(async (id, cancellation) =>
                {
                    return await orderRepository.AnyAsync(o => o.Id == id);
                })
                .WithMessage(localizer["Validation:Order:NotFound"]);*/
        }
    }


}
