using PizzaDelivery.Src.Core.Common;

using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering.Aggregates;

public class OrderElement
{
    public Guid Id { get; }
    private List<Modification> _modifications;
    
    public Product BaseProduct { get; }
    public IReadOnlyCollection<Modification> Modifications => _modifications;
    public int Count { get;}
    public decimal Price
    {
        get
        {
          var SumationPrise = BaseProduct.Price + Modifications.Sum(ex => ex.PriceChange);
          
          if (SumationPrise < 0)
          {
              return 0;
          }

          return SumationPrise;
        }
    }
    public int Weight    {
        get
        {
            var summarWeight = BaseProduct.WeightInGrams + Modifications.Sum(ex => ex.WeightChange);
          
            if (summarWeight < 0)
            {
                return 0;
            }

            return summarWeight;
        }
    }

    protected OrderElement(Guid id, Product product, List<Modification> modifications, int count)
    {
        Id = id;
        BaseProduct = product;
        _modifications = modifications;
        Count = count;
    }
    
    public static Result<OrderElement> Create(Product baseProduct, List<Modification> modifications, int count)
    {
        if (count <= 0)
        {
            return Result.Failure<OrderElement>(new Error("123", "count must be mote that zero"));
        }

        if (modifications.Count > 0 && allModificationAvaliableForProduct(baseProduct, modifications) == false)
        {
            return Result.Failure<OrderElement>(new Error("123","not all modification awaliable for this product"));
        }

        return Result.Sucsesfull<OrderElement>(new (Guid.NewGuid(), baseProduct, modifications, count));
    }

    private static bool allModificationAvaliableForProduct(Product product, List<Modification> modifications)
    {
        if (modifications.Count == 0)
        {
            return true;
        }
        
        return modifications.All(
            ex => product.AvaliableModifications.Any(
                subEx => subEx.Id == ex.Id
            )
        );
    }
    
}