namespace MiniLibraryAfterCore.DomainModel;

public record BorrowBookResult(Loan Loan, Receipt Receipt, Book Book)
{
    public object Value { get; set; }
}
