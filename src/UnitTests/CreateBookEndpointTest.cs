using Api.Features.Book;
using Common;
using FastEndpoints;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests;

public class CreateBookEndpointTest
{
    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenReturnsSuccess()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title:
            "The mockRepository.Verify(r => r.InsertAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()), Times.Once);Galactic Codex of Time",
            Author: "Chrono Voyager",
            ISBN: "987-65-43210-XYZ",
            Publisher: "Transdimensional Press",
            PublishedDate: new DateTime(2088, 7, 14),
            Pages: 999,
            AvailableCopies: 13,
            TotalCopies: 42,
            Genre: "Cosmic Sci-Fi"
        );

        var mockRepository = new Mock<IBookRepository>();
        var mockLogger = new Mock<ILogger<Api.Features.Book.Create.Endpoint>>();
        var capturedBook = new Book();

        mockRepository.Setup(r => r.InsertAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()))
            .Callback<Book, CancellationToken>((book, token) => capturedBook = book)
            .Returns(Task.CompletedTask);

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object,
            mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        var response = endpoint.Response;

        mockRepository.Verify(r => r.InsertAsync(capturedBook, It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(response);

        Assert.Equal(response.Id, capturedBook.Id);

        Assert.Equal(request.Title, capturedBook.Title);
        Assert.Equal(request.Author, capturedBook.Author);
        Assert.Equal(request.ISBN, capturedBook.ISBN);
        Assert.Equal(request.Publisher, capturedBook.Publisher);
        Assert.Equal(request.PublishedDate, capturedBook.PublishedDate);
        Assert.Equal(request.Pages, capturedBook.Pages);
        Assert.Equal(request.AvailableCopies, capturedBook.AvailableCopies);
        Assert.Equal(request.TotalCopies, capturedBook.TotalCopies);
        Assert.Equal(request.Genre, capturedBook.Genre);
    }

    [Fact]
    public async Task GivenABookWithAllInvalidFields_WhenCreating_ThenReturnsError()
    {
        var request = new Api.Features.Book.Create.Request(
            Title: "",
            Author: "",
            ISBN: "",
            Publisher: "",
            PublishedDate: DateTime.MinValue,
            Pages: 0,
            AvailableCopies: 0,
            TotalCopies: 0,
            Genre: ""
        );

        var validator = new Api.Features.Book.Create.Validator();
        var validationResult = await validator.ValidateAsync(request, CancellationToken.None);

        Assert.False(validationResult.IsValid);
    }

    [Fact]
    public async Task GivenABookWithNegativePages_WhenCreating_ThenReturnsError()
    {
        var request = new Api.Features.Book.Create.Request(
            Title: "Negative Pages Book",
            Author: "Author",
            ISBN: "123-45-67890-XYZ",
            Publisher: "Publisher",
            PublishedDate: DateTime.Now,
            Pages: -1,
            AvailableCopies: 1,
            TotalCopies: 1,
            Genre: "Genre"
        );

        var validator = new Api.Features.Book.Create.Validator();
        var validationResult = await validator.ValidateAsync(request, CancellationToken.None);

        Assert.False(validationResult.IsValid);
    }
}