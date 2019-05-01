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

        private void InitContext()
        {
            var builder = new DbContextOptionsBuilder<AzShipContext>().UseInMemoryDatabase();

            var context = new AzShipContext(builder.Options);

            _azshipContext = context;
        }

        private void SeedContext()
        {
            List<Cargo> CargoSeeds = new List<Cargo>();

            CargoSeeds.Add(new Cargo("Titulo 1", "Descricao 1", 100).InformAddresses("Origem 1", "Destino 1").InformContactInfo("email.1@azship.com"));
            CargoSeeds.Add(new Cargo("Titulo 2", "Descricao 2", 200).InformAddresses("Origem 2", "Destino 2").InformContactInfo("email.2@azship.com"));
            CargoSeeds.Add(new Cargo("Titulo 3", "Descricao 3", 300).InformAddresses("Origem 3", "Destino 3").InformContactInfo("email.3@azship.com"));
            CargoSeeds.Add(new Cargo("Titulo 4", "Descricao 4", 400).InformAddresses("Origem 4", "Destino 4").InformContactInfo("email.4@azship.com"));
            CargoSeeds.Add(new Cargo("Titulo 5", "Descricao 5", 500).InformAddresses("Origem 5", "Destino 5").InformContactInfo("email.5@azship.com"));
            CargoSeeds.Add(new Cargo("Titulo 6", "Descricao 6", 600).InformAddresses("Origem 6", "Destino 6").InformContactInfo("email.6@azship.com"));
            CargoSeeds.Add(new Cargo("Titulo 7", "Descricao 7", 700).InformAddresses("Origem 7", "Destino 7").InformContactInfo("email.7@azship.com"));

            _azshipContext.Cargos.AddRange(CargoSeeds);
            _azshipContext.SaveChanges();
        }

        public CargoRepositoryTest()
        {
            InitContext();
            SeedContext();
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

        [Fact]
        public void UpdateCargo_ShouldBeUpdated()
        {
            var cargo = _cargoRepository.QueryFirst(q => q.Price == 100);
            cargo.Price = 101;

            _cargoRepository.Update(cargo);
            _cargoRepository.SaveChanges();

            var cargoUpdated = _cargoRepository.QueryFirst(q => q.Id == cargo.Id);

            Assert.True(cargo.Price == 101);
        }

        [Fact]
        public void DeleteCargo_ShouldBeDeleted()
        {
            var cargo = _cargoRepository.QueryFirst(q => q.Price == 100);

            _cargoRepository.Remove(cargo.Id);
            _cargoRepository.SaveChanges();

            var cargoUpdated = _cargoRepository.QueryFirst(q => q.Id == cargo.Id);

            Assert.Null(cargoUpdated);
        }

        [Fact]
        public void QueryCargo_ShouldRetrieveAtLeastOne()
        {
            var cargos = _cargoRepository.Query(q => q.Price < 500);

            Assert.True(cargos.Count() >= 1);
        }

        [Fact]
        public void QueryBydIdCargo_ShouldRetrieveCorrect()
        {
            var cargo = _cargoRepository.Query(q => q.Price == 500).FirstOrDefault();

            var cargoRetrieved = _cargoRepository.QueryById(cargo.Id);

            Assert.True(cargoRetrieved.Id == cargo.Id);
        }

        [Fact]
        public void QueryFirstCargo_ShouldRetrieveCorrect()
        {
            var cargo = _cargoRepository.QueryFirst(q => q.Price == 500);

            var cargoRetrieved = _cargoRepository.QueryById(cargo.Id);

            Assert.True(cargoRetrieved.Id == cargo.Id);
        }
    }
}
