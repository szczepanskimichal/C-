namespace MiniLibraryAfterCore.DomainModel;

public record BookId
{
    private int Id { get; }

    private BookId(int id)
    {
        Id = id;
    }

    public static Result<BookId> Create(string id)
    {
       /* if (!int.TryParse(id, out var bookId))
        {
            return Result<BookId>.Failure("Invalid book id.");
        }
        return Result<BookId>.Success(new BookId(bookId));
        */
       return !int.TryParse(id, out var bookId)
           ? Result<BookId>.Failure("Invalid book id.")
           : Result<BookId>.Success(new BookId(bookId));
    }
}