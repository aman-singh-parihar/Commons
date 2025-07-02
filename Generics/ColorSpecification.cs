internal class ColorSpecification : ISpecification<Product>
{
    public Color Color { get; set; }
    public ColorSpecification(Color color)
    {
        Color = color;
    }
    public bool IsSatisfied(Product t) => Color == t.Color;
}
