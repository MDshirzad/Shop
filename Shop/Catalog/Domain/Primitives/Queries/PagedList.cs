namespace Shop.Catalog.Application.Product.Queries{

public class PagedList<TEntity>(IEnumerable<TEntity> items, int totalRecordCount)
{
    public IReadOnlyList<TEntity> Items => items.ToList().AsReadOnly();
    public int TotalRecordCount => totalRecordCount;
}
}