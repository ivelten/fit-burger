using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.WebApp.Models.Product;

namespace FitBurger.WebApp.Services;

public class ProductService :
    ICreateService<CreateProduct>,
    IUpdateService<UpdateProduct>,
    IListService<ListProduct>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(
        IRepository<Product> productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task CreateAsync(CreateProduct request)
    {
        var product = new Product(
            request.Description!,
            request.Price!.Value);

        await _productRepository.AddAsync(product);
        await _unitOfWork.CommitAsync();
    }

    public async Task<UpdateProduct?> GetAsync(int id)
    {
        var product = await _productRepository.GetAsync(id);

        if (product is null)
            return null;

        return new UpdateProduct
        {
            Description = product.Description,
            Price = product.Price
        };
    }

    public async Task UpdateAsync(int id, UpdateProduct request)
    {
        var product = await _productRepository.GetAsync(id);

        if (product is null)
            return;
        
        product.Update(
            request.Description!,
            request.Price!.Value);

        await _unitOfWork.CommitAsync();
    }

    public async Task<ListProduct[]> ListAsync(string? queryValue = null)
    {
        Func<Product, bool>? predicate =
            queryValue is not null
                ? x => x.Description.Contains(queryValue)
                : null;

        var products = await _productRepository.GetAsync(predicate);

        return products.Select(x => new ListProduct
        {
            Id = x.Id,
            Description = x.Description,
            Price = x.Price
        }).ToArray();
    }
}