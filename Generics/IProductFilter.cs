interface IProductFilter
{
    IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification);
}
