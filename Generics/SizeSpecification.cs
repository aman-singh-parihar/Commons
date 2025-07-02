internal class SizeSpecification : ISpecification<Product>
{
    public Size Size { get; set; }
    public SizeSpecification(Size size)
    {
        Size = size;
    }
    public bool IsSatisfied(Product t) => Size == t.Size;
}
