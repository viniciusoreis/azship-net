using AzShip.Core.Interfaces.Repositories;
using AzShip.Core.Models;
using AzShip.Infra.Persistence.Contexts;
using AzShip.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzShip.Infra.Persistence.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(AzShipContext context) : base(context)
        {
        }
    }
}
