namespace ProductStore.Services.Validations.OrderValidaions
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.OrderDetailsDtos;
    using ProductStore.Services.Dtos.OrderDtos;
    using Volo.Abp.Localization;

    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator(IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(x => x.OrderDate)
                .NotEmpty()
                .WithMessage(localizer["Validation:Order:OrderDateRequired"]);

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0)
                .WithMessage(localizer["Validation:Order:TotalAmountPositive"]);

            RuleForEach(x => x.OrderDetails)
                .SetValidator(new OrderDetailsCreateValidator(localizer));
        }
    }

    public class OrderDetailsCreateValidator : AbstractValidator<CreateOrderDetailsDto>
    {
        public OrderDetailsCreateValidator(IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage(localizer["Validation:Order:DetailsProductIdRequired"]);

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage(localizer["Validation:Order:DetailsQuantityPositive"]);

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage(localizer["Validation:Order:DetailsUnitPricePositive"]);
        }
    }

}
