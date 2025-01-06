using Api.Features.Book;
using Common;
using FastEndpoints;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests;

public class CreateBookEndpointTest
{
    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenInsertsBook()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        mockRepository.Verify(r => r.InsertAsync(capturedBook, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenResponseIsNotNull()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        var response = endpoint.Response;

        Assert.NotNull(response);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenResponseIdMatchesBookId()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        var response = endpoint.Response;

        Assert.Equal(response.Id, capturedBook.Id);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookTitleMatchesRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.Title, capturedBook.Title);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookAuthorMatchesRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.Author, capturedBook.Author);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookISBNMatchesRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.ISBN, capturedBook.ISBN);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookPublisherMatchesRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.Publisher, capturedBook.Publisher);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookPublishedDateMatchesRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.PublishedDate, capturedBook.PublishedDate);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookPagesMatchRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.Pages, capturedBook.Pages);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookAvailableCopiesMatchRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.AvailableCopies, capturedBook.AvailableCopies);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookTotalCopiesMatchRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
        Assert.Equal(request.TotalCopies, capturedBook.TotalCopies);
    }

    [Fact]
    public async Task GivenAValidBook_WhenCreating_ThenBookGenreMatchesRequest()
    {
        //Arrange
        var request = new Api.Features.Book.Create.Request(
            Title: "Galactic Codex of Time",
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

        var endpoint = Factory.Create<Api.Features.Book.Create.Endpoint>(mockRepository.Object, mockLogger.Object);

        //Act
        await endpoint.HandleAsync(request, CancellationToken.None);

        //Assert
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
        //Arrange
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
        
        //Act
        var validationResult = await validator.ValidateAsync(request, CancellationToken.None);

        //Assert
        Assert.False(validationResult.IsValid);
    }
}