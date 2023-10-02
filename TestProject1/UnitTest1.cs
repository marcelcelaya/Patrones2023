using System;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Domain;
using Data.Contracts;
using Business.Implementation;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Add_WhenEntityIsNotNull_ShouldReturnEntityId()
        {
            // Arrange
            var entity = new Encuesta   
            {
                // Define propiedades de ejemplo para la entidad
                Title = "Título de la Encuesta",
                Color = 1
            };

            // Configurar un mock para IEncuestaRepository
            var encuestaRepositoryMock = new Mock<IEncuestaRepository>();
            encuestaRepositoryMock.Setup(repo => repo.Add(It.IsAny<Encuesta>())).Returns(1); // Simula el resultado de la operación Add

            // Crear una instancia de EncuestaService con el mock de IEncuestaRepository
            var service = new EncuestaService(encuestaRepositoryMock.Object);

            // Act
            var result = service.Add(entity);

            // Assert
            Assert.NotEqual(0, result); // El resultado debe ser un ID no nulo
            encuestaRepositoryMock.Verify(repo => repo.Add(entity), Times.Once); // Verificar que se llamó a Add en el repositorio una vez con la entidad correcta
        }

        [Fact]
        public void Add_WhenEntityIsNull_ShouldReturnZero()
        {
            // Arrange
            Encuesta entity = null;

            // Configurar un mock para IEncuestaRepository
            var encuestaRepositoryMock = new Mock<IEncuestaRepository>();
            encuestaRepositoryMock.Setup(repo => repo.Add(It.IsAny<Encuesta>())).Returns(0); // Simula que no se agrega ninguna entidad

            // Crear una instancia de EncuestaService con el mock de IEncuestaRepository
            var service = new EncuestaService(encuestaRepositoryMock.Object);

            // Act
            var result = service.Add(entity);

            // Assert
            Assert.Equal(0, result); // El resultado debe ser 0 ya que la entidad es nula
            encuestaRepositoryMock.Verify(repo => repo.Add(It.IsAny<Encuesta>()), Times.Never); // Verificar que Add en el repositorio nunca se llamó
        }
    }
}
