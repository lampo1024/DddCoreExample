﻿namespace DddCoreExample.Domain.Models.Carts
{
    public enum CheckOutIssue
    {
        UnpaidBalance = 101,
        NoActiveCreditCardAvailable = 102,
        ProductNotInStock = 201,
        ProductIsFaulty = 202
    }
}
