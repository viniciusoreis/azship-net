using AzShip.Core.Interfaces.Repositories;
using AzShip.Core.Models;
using AzShip.Infra.Persistence.Contexts;
using AzShip.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AzShip.Tests.Infra.Persistence.Repositories
{
    public class CargoRepositoryTest
    {
        private AzShipContext _azshipContext;
        private ICargoRepository _cargoRepository;

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<AzShipContext>().UseInMemoryDatabase();

            var context = new AzShipContext(builder.Options);

            _azshipContext = context;
        }

        public CargoRepositoryTest()
        {
            InitContext();
            _cargoRepository = new CargoRepository(_azshipContext);
        }

        [Theory]
        [InlineData("Carga de teste", "Apenas uma carga de teste", 700, "São Paulo - SP", "Brasília - DF", "azship@azhip.com")]
        public void AddCargo_ShouldBeStored(string title, string description, decimal price, string source, string destination, string email)
        {
            // Arrange
            Cargo cargo = new Cargo(title, description, price);
            cargo.InformAddresses(source, destination);
            cargo.InformContactInfo(email);

            // Act
            _cargoRepository.Add(cargo);
            _cargoRepository.SaveChanges();

            // Assert
            var inserted = _cargoRepository.Query(q => q.ContactEmail == email);

            Assert.True(inserted.Count() > 0);
        }
    }
}
