using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.Domain.Interfaces;

public interface IModificationRepository
{
    public Modification GetById(int Id);
    public void Create(Modification modification);
    public void Update(Modification modification);
}
