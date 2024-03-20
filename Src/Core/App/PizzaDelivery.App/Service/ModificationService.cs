using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace Src.Core.App.Service
{
    public class ModificationService
    {
        private readonly IModificationStore _modification;
        private readonly IIngridientStore _ingridientsStore;

        public ModificationService(
            IModificationStore modificationStore,
            IIngridientStore ingridientStore
            )
        {
            _modification = modificationStore;
            _ingridientsStore = ingridientStore;
        }

        public async Task<Result> Create(Modification modification)
        {
            var getIngridientByIdResult = await _ingridientsStore.GetById(modification.Ingridient.Id);

            if(getIngridientByIdResult.IsSucsesfull == false)
            {
                return Result.Failure(new Error("123", "dont have ingridient for this modification"));
            }

            var createModificationResult = await _modification.Create(modification);

            return createModificationResult;
        }
        public async Task<Result> UpdateModification(Modification modification)
        {
            var haveBaseModificationResult = await _modification.GetById(modification.Id);

            if(haveBaseModificationResult.IsSucsesfull == false)
            {
                return Result.Failure(new Error("123", "dont have modification for change"));
            }

            var getIngridientByIdResult = await _ingridientsStore.GetById(modification.Ingridient.Id);

            if(getIngridientByIdResult.IsSucsesfull == false)
            {
                return Result.Failure(new Error("123", "dont have ingridient for this modification"));
            }

            var updateModificationResult = await _modification.Update(modification);

            return updateModificationResult;
        }
        
        public async Task<Result<List<Modification>>> GetByIngridient(Guid ingridient)
        {
            var getIngridientByIdResult = await _ingridientsStore.GetById(ingridient);

            if(getIngridientByIdResult.IsSucsesfull == false)
            {
                return Result.Failure<List<Modification>>(new Error("123", "dont have ingridient"));
            }

            var getModificationByIngridientResult = await _modification.GetByIngridient(ingridient);
        
            return getModificationByIngridientResult;

        }
        
    }
}