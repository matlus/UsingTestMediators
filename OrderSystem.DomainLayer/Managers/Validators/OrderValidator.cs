namespace OrderSystem.DomainLayer.Managers.Validators
{
    internal static class OrderValidator
    {
        internal static void EnsureOrderParameters(int customerId, long productId, int quantity)
        {
            // TODO: Validate all prameters and throw a specific business exception if there are validation issues, indicating clearly the issue(s) found.
        }
    }
}
