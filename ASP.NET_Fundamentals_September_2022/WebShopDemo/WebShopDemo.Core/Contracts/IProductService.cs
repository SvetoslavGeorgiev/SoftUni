namespace WebShopDemo.Core.Contracts
{
    using WebShopDemo.Core.Models;

    /// <summary>
    /// Manipulating product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GetAll();

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        Task Add(ProductDto productDto);

        Task Delete(Guid id);

    }
}
