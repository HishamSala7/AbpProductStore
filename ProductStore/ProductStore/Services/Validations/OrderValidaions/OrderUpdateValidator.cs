namespace ProductStore.Services.Validations.OrderValidaions
{
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ProductStore.Entities;
    using ProductStore.Localization;
    using ProductStore.Services.Dtos.OrderDetailsDtos;
    using ProductStore.Services.Dtos.OrderDtos;
    using Volo.Abp.Localization;

    public class OrderUpdateValidator : AbstractValidator<UpdateOrderDto>
    {
        public OrderUpdateValidator(IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(localizer["Validation:Order:NotFound"]);

            RuleFor(x => x.OrderDate)
                .NotEmpty()
                .WithMessage(localizer["Validation:Order:OrderDateRequired"]);

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0)
                .WithMessage(localizer["Validation:Order:TotalAmountPositive"]);

            RuleForEach(x => x.OrderDetails)
                .SetValidator(new OrderDetailsUpdateValidator(localizer));
        }
    }

    public class OrderDetailsUpdateValidator : AbstractValidator<UpdateOrderDetailsDto>
    {
        public OrderDetailsUpdateValidator(IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(localizer["Validation:Order:DetailsNotFound"]);

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
