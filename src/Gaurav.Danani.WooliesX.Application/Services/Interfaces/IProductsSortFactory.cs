namespace Gaurav.Danani.WooliesX.Application.Services.Interfaces
{
    public interface IProductsSortFactory
    {
        IProductsSortStrategy GetProductsSortStrategy(string sortOption);
    }
}