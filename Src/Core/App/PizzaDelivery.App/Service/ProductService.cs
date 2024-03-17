using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace Src.Core.App.Service
{
    public class ProductService
    {
        public Task<Result> Create(Product product){}
        public Task<Result> Update(Product product){}
        public Task<Result> Archive(Guid guid){}
        public Task<Result> ReturnProductFromArchive(Guid guid){}

        public Task<Result> GetNWithInfridient(Guid guid, int n){}
        public Task<Result> GetNWithMostContainsInfridient(Guid guid, int n){}

    public Task<Result> GetFirstNProduct(int n){}
    public Task<Result> GetNMostLikedProduct(int n){}
    public Task<Result> GetNMostDeliveredProduct(int n){}
        

    }
}