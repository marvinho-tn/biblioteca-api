using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common;

public record Book
{
    /// <summary>
    /// Um identificador único para o livro.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }

    /// <summary>
    /// O título do livro.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// O autor do livro.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// O número ISBN do livro, que é um identificador único padrão.
    /// </summary>
    public string ISBN { get; set; }

    /// <summary>
    /// A editora do livro.
    /// </summary>
    public string Publisher { get; set; }

    /// <summary>
    /// A data de publicação do livro.
    /// </summary>
    public DateTime PublishedDate { get; set; }

    /// <summary>
    /// O número de páginas do livro.
    /// </summary>
    public int Pages { get; set; }

    /// <summary>
    /// O número de cópias disponíveis para empréstimo.
    /// </summary>
    public int AvailableCopies { get; set; }

    /// <summary>
    /// O número total de cópias do livro.
    /// </summary>
    public int TotalCopies { get; set; }

    /// <summary>
    /// O gênero do livro.
    /// </summary>
    public string Genre { get; set; }
}

public record Loan
{
    /// <summary>
    /// Um identificador único para o empréstimo.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }

    /// <summary>
    /// O identificador do livro que está sendo emprestado.
    /// </summary>
    public string BookId { get; set; }

    /// <summary>
    /// O identificador do usuário que está fazendo o empréstimo.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// A data em que o livro foi emprestado.
    /// </summary>
    public DateTime LoanDate { get; set; }

    /// <summary>
    /// A data de devolução prevista para o livro.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// A data em que o livro foi devolvido (pode ser nula se o livro ainda não foi devolvido).
    /// </summary>
    public DateTime ReturnDate { get; set; }

    /// <summary>
    /// O status do empréstimo (e.g., Em Andamento, Devolvido, Atrasado).
    /// </summary>
    public LoanStatus Status { get; set; }

    public enum LoanStatus
    {
        /// <summary>
        /// Andamento
        /// </summary>
        InProgress = 1,
        
        /// <summary>
        /// Devolvido
        /// </summary>
        Returned = 2,
        
        /// <summary>
        /// Atrasado
        /// </summary>
        Overdue = 3,
    }
}