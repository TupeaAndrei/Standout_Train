using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Standout_Train.BL.Classes;
using Standout_Train.BL.Interfaces;
using Standout_Train.DAL.Context;
using Standout_Train.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Standout_Train.Tests.DALTests
{
    public class DbOperationsTests
    {
        private IUnitOfWork _unitOfWork;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<TrainContext> options = new DbContextOptionsBuilder<TrainContext>();
            TrainContext context = new TrainContext(options.UseSqlServer("").Options);
            _unitOfWork = new UnitOfWork(context);
        }

        [Test]
        public async Task GetByIdTest()
        {
            int id = 1;
            Customer expectedResult = new Customer
            {
                Id = 1,
                FirstName = "Tupea",
                LastName = "Andrei",
                Age = 22,
                Adress = "Str Libertatii",
                LoyaltyPoints = 25,
                ZipCode = "525200",
                EmailAdress = "andreichris55@yahoo.com",
                PhoneNumber = "0746670688"
            };

            Customer actualResult = await _unitOfWork.Customers.GetByIdAsync(id);

            Assert.Equals(expectedResult, actualResult);
        }

        [Test]
        public async Task GetByIdShouldThrowArgumentError()
        {
            int id = int.MinValue;

            Assert.Throws<ArgumentException>(async () => await _unitOfWork.Customers.GetByIdAsync(id));
        }

        [Test]
        public async Task AddMethodShouldThrowExceptionOnNullEntity()
        {
            Train train = null;

            Assert.Throws<DbUpdateException>(async () => await _unitOfWork.Trains.AddAsync(train));
        }

        [Test]
        public async Task AddMethodShouldThrowExceptionOnInvalidEntity()
        {
            Customer customer = new Customer
            {
                FirstName = null, // Database makes this parameter required, so it should throw error on null input.
                LastName = "Andrei",
                Age = 22,
                Adress = "Str Libertatii",
                LoyaltyPoints = 25,
                ZipCode = "525200",
                EmailAdress = "andreichris55@yahoo.com",
                PhoneNumber = "0746670688"
            };

            Assert.Throws<DbUpdateException>(async () => await _unitOfWork.Customers.AddAsync(customer));
        }

        [Test]
        public async Task UpdateMethodTest()
        {
            int id = 1;
            Customer customer = await _unitOfWork.Customers.GetByIdAsync(id);
            customer.Age = 24;

            await _unitOfWork.Customers.Update(id, customer);

            Customer actualResult = await _unitOfWork.Customers.GetByIdAsync(id);

            Assert.Equals(customer, actualResult);
        }

        [Test]
        public async Task UpdateShouldThrowErrorOnInvalidId()
        {
            var id = int.MinValue;

            Assert.Throws<ArgumentException>(async () => await _unitOfWork.Customers.Update(id, new Customer()));
        }

        [Test]
        public async Task GetBookedTicketsByCustomerTest()
        {
            Customer customer = await _unitOfWork.Customers.GetByIdAsync(1);
            List<Ticket>? expectedResult = (await _unitOfWork.Tickets.GetAllAsync()).Where(t => t.CustomerId == customer.Id).ToList();


            List<Ticket>? actualResult = (await _unitOfWork.Customers.GetBookedTickets(customer)).ToList();

            Assert.Equals(actualResult, expectedResult);
        }

        [Test]
        public async Task GetUserAchievmentsTest()
        {
            Customer customer = await _unitOfWork.Customers.GetByIdAsync(1);
            List<Achievments>? expectedResult = (await _unitOfWork.Achievments.GetAllAsync()).Where(a => a.CustomerId == customer.Id).ToList();

            List<Achievments>? actualResult = (await _unitOfWork.Customers.GetUserAchievments(customer)).ToList();

            Assert.Equals(actualResult, expectedResult);
        }

        [Test]
        public async Task GetAllTrainsThatStartInCity()
        {
            string mockCity = "Brasov";
            List<Train>? expectedResult = (await _unitOfWork.Trains.GetAllAsync()).Where(t => t.DepartureCity.Equals(mockCity)).ToList();

            List<Train>? actualResult = (await _unitOfWork.Trains.GetAllTrainsThatStartFromCity(mockCity)).ToList();

            Assert.Equals(expectedResult, actualResult);
        }

        [Test]
        public async Task GetAllTrainsThatEndInCity()
        {
            string mockCity = "Brasov";
            List<Train>? expectedResult = (await _unitOfWork.Trains.GetAllAsync()).Where(t => t.ArrivalCity.Equals(mockCity)).ToList();

            List<Train>? actualResult = (await _unitOfWork.Trains.GetAllTrainsThatStopInCity(mockCity)).ToList();

            Assert.Equals(actualResult, expectedResult);
        }
    }
}