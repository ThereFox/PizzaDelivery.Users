using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace Src.Core.App.Service
{
    public class ProductService
    {
        private readonly IProductsStore _productStore;
        private readonly IIngridientStore _ingridiensStore;

        public ProductService(
            IProductsStore productsStore,
            IIngridientStore ingridientStore
        )
        {
            _productStore = productsStore;
            _ingridiensStore = ingridientStore;
        }

        public async Task<Result> Create(Product product)
        {
            product.IsArchived = true;

            var addProductResult = await _productStore.AddProduct(product);

            if(addProductResult.IsSucsesfull == false)
            {
                return Result.Failure(addProductResult.ErrorInfo);
            }

            return Result.Sucsesfull();
        }
        public async Task<Result> Update(Product product)
        {
            var containingCheckProductResult = await _productStore.GetById(product.Id);
            
            if(containingCheckProductResult.IsSucsesfull == false)
            {
                return Result.Failure(containingCheckProductResult.ErrorInfo);
            }

            var updateProductResult = await _productStore.UpdateProduct(product);

            return updateProductResult;

        }
        public async Task<Result> Archive(Guid guid)
        {
            var getProductResult = await _productStore.GetById(guid);
            
            if(getProductResult.IsSucsesfull == false)
            {
                return Result.Failure(new Error("123", "Dont have element for archive"));
            }

            var product = getProductResult.ResultValue;

            if(product.IsArchived)
            {
                return Result.Sucsesfull();
            }

            product.IsArchived = true;

            var updateProductResult = await _productStore.UpdateProduct(product);

            return updateProductResult;
        }
        public async Task<Result> ReturnProductFromArchive(Guid guid)
        {
            var getProductResult = await _productStore.GetById(guid);
            
            if(getProductResult.IsSucsesfull == false)
            {
                return Result.Failure(new Error("123", "Dont have element for archive"));
            }

            var product = getProductResult.ResultValue;

            if(product.IsArchived == false)
            {
                return Result.Sucsesfull();
            }

            product.IsArchived = false;

            var updateProductResult = await _productStore.UpdateProduct(product);

            return updateProductResult;
        }
        public async Task<Result<List<Product>>> GetNWithInfridient(Guid guid, int n)
        {
            var getIngridientResult = await _ingridiensStore.GetById(guid);

            if(getIngridientResult.IsSucsesfull == false)
            {
                return Result.Failure<List<Product>>(getIngridientResult.ErrorInfo);
            }

            var ingridientFiltr = new ProductsFiltr([guid], ArchiveFiltrationVariant.OnlyUnArchived);

            var getedProducts = await _productStore.GetFirstNByFiltr(ingridientFiltr,  n);

            return Result.Sucsesfull(getedProducts);

        }
        public async Task<Result<List<Product>>> GetNWithMostContainsInfridient(Guid guid, int n)
        {
            var getIngridientResult = await _ingridiensStore.GetById(guid);

            if(getIngridientResult.IsSucsesfull == false)
            {
                return Result.Failure<List<Product>>(getIngridientResult.ErrorInfo);
            }

            var filtr = new ProductsFiltr([guid], ArchiveFiltrationVariant.OnlyUnArchived);

            var productWithIngridient = await _productStore.GetFirstNByFiltrWihtOrderingByIngridientContaining(filtr, n);

            return Result.Sucsesfull(productWithIngridient);
        }
        public async Task<List<Product>> GetNArchived(int n)
        {
            var archivedFiltr = new ProductsFiltr(null, ArchiveFiltrationVariant.OnlyArchived);
        
            var getedArchivedProducts = await _productStore.GetFirstNByFiltr(archivedFiltr, n);

            return getedArchivedProducts;
        }
        public async Task<List<Product>> GetFirstNProduct(int n)
        {
            var unarchivedFiltr = new ProductsFiltr(null, ArchiveFiltrationVariant.OnlyUnArchived);
        
            var getedProducts = await _productStore.GetFirstNByFiltr(unarchivedFiltr, n);

            return getedProducts;
        }
        public async Task<List<Product>> GetNMostLikedProduct(int n)
        {
            var unarchivedFiltr = new ProductsFiltr(null, ArchiveFiltrationVariant.OnlyUnArchived);

            var products = await _productStore.GetMostLikedNWithFiltr(unarchivedFiltr, n);

            return products;
        }
        public async Task<List<Product>> GetNMostDeliveredProduct(int n)
        {
            var unarchivedFiltr = new ProductsFiltr(null, ArchiveFiltrationVariant.OnlyUnArchived);

            var products = await _productStore.GetNMostDeliveredWithFiltr(unarchivedFiltr, n);

            return products;
        }
        

    }
}