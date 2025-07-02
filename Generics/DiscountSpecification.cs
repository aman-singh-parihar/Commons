internal class DiscountSpecification : ISpecification<Product>
{
    public Discount Discount { get; set; }
    public DiscountSpecification(Discount discount)
    {
        Discount = discount;
    }
    public bool IsSatisfied(Product t) => Discount == t.Discount;
}
