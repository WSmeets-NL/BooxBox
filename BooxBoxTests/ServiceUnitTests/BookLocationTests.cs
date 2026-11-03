using BooxBox.Interfaces;
using BooxBox.Models;
using BooxBox.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BooxBoxTests.ServiceUnitTests
{
    public class BookLocationTests
    {
        [Fact]
        public async void GetAllBookLocationsAsyncReturnsAllBookLocations()
        {
            //Arrange 
            List<BookLocation> bookLocationList = new List<BookLocation>();

            BookLocation location1 = new BookLocation()
            {
                Id = 1,
                Name = "Eiken Kast"
            };

            BookLocation location2 = new BookLocation()
            {
                Id = 2,
                Name = "Metalen Kast"
            };

            bookLocationList.Add(location1);
            bookLocationList.Add(location2);

            Mock<IBookLocationRepository> mockLocationRepo = new Mock<IBookLocationRepository>();
            mockLocationRepo.Setup(r => r.GetAllBookLocationsAsync()).ReturnsAsync(bookLocationList);

            BookLocationService locationService = new BookLocationService(mockLocationRepo.Object);

            //Act

            List<BookLocation> returnedLocations = await locationService.GetAllBookLocationsAsync();

            //Assert

            Assert.NotNull(returnedLocations);
            Assert.Equal(location1, returnedLocations[0]);
            Assert.Equal(location2, returnedLocations[1]);
        }

        [Fact]
        public async Task AddBookLocationCorrectlyCallsRepo()
        {
            //Arrange

            BookLocation testLocation = new BookLocation()
            {
                Id = 1,
                Name = "Verhuisdoos"
            };

            Mock<IBookLocationRepository> mockLocationRepo = new Mock<IBookLocationRepository>();
            mockLocationRepo.Setup(r => r.AddBookLocationAsync(testLocation)).Returns(Task.CompletedTask);

            BookLocationService locationService = new BookLocationService(mockLocationRepo.Object);


            //Act
            await locationService.AddBookLocation(testLocation);

            //Assert
            mockLocationRepo.Verify(r => r.AddBookLocationAsync(testLocation), Times.Once);
        }

        [Fact]
        public async Task GetBookLocationByIdReturnsCorrectLocation()
        {
            //Arrange 
            List<BookLocation> bookLocationList = new List<BookLocation>();

            BookLocation location1 = new BookLocation()
            {
                Id = 1,
                Name = "Eiken Kast"
            };

            BookLocation location2 = new BookLocation()
            {
                Id = 2,
                Name = "Metalen Kast"
            };

            bookLocationList.Add(location1);
            bookLocationList.Add(location2);

            Mock<IBookLocationRepository> mockLocationRepo = new Mock<IBookLocationRepository>();
            mockLocationRepo.Setup(r => r.GetBookLocationByIdAsync(2)).ReturnsAsync(location2);

            BookLocationService locationService = new BookLocationService(mockLocationRepo.Object);

            //Act

            BookLocation returnedLocation = await locationService.GetBookLocationById(2);

            //Assert

            Assert.NotNull(returnedLocation);
            Assert.Equal(location2, returnedLocation);
        }

        [Fact]
        public async Task UpdateBookLocationCorrectlyCallsRepo()
        {
            //Arrange

            BookLocation testLocation = new BookLocation()
            {
                Id = 1,
                Name = "Verhuisdoos"
            };

            Mock<IBookLocationRepository> mockLocationRepo = new Mock<IBookLocationRepository>();
            mockLocationRepo.Setup(r => r.UpdateBookLocationAsync(testLocation)).Returns(Task.CompletedTask);

            BookLocationService locationService = new BookLocationService(mockLocationRepo.Object);


            //Act
            await locationService.UpdateBookLocation(testLocation);

            //Assert
            mockLocationRepo.Verify(r => r.UpdateBookLocationAsync(testLocation), Times.Once);
        }

        [Fact]
        public async Task DeleteBookLocationByIdCorrectlyCallsRepo()
        {
            //Arrange

            BookLocation testLocation = new BookLocation()
            {
                Id = 1,
                Name = "Verhuisdoos"
            };

            Mock<IBookLocationRepository> mockLocationRepo = new Mock<IBookLocationRepository>();
            mockLocationRepo.Setup(r => r.DeleteBookLocationByIdAsync(1)).Returns(Task.CompletedTask);

            BookLocationService locationService = new BookLocationService(mockLocationRepo.Object);


            //Act
            await locationService.DeleteBookLocationById(1);

            //Assert
            mockLocationRepo.Verify(r => r.DeleteBookLocationByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetLocationNameReturnsLocationName()
        {
            //Arrange

            BookLocation testLocation = new BookLocation()
            {
                Id = 1,
                Name = "Verhuisdoos"
            };

            Mock<IBookLocationRepository> mockLocationRepo = new Mock<IBookLocationRepository>();
            mockLocationRepo.Setup(r => r.GetBookLocationNameAsync(1)).ReturnsAsync(testLocation.Name);

            BookLocationService locationService = new BookLocationService(mockLocationRepo.Object);


            //Act
            String locationName = await locationService.GetLocationName(1);

            //Assert
            Assert.Equal(testLocation.Name, locationName);
        }
    }
    
}
