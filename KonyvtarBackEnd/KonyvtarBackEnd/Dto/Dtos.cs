namespace KonyvtarBackEnd.Dto
{
    public record FelhasznaloDto(uint Id, string Name, DateTime MembershipStart, DateTime MembershipEnd, string UserName, int Id_Rule, int Id_Account_Image);
    public record CreateFelhasznaloDto(string Name, DateTime MembershipStart, DateTime MembershipEnd, string UserName, string Hash, int Id_Rule, int Id_Account_Image);
    public record ModifyFelhasznaloDto(uint Id, string Name, DateTime MembershipStart, DateTime MembershipEnd, string UserName, int Id_Rule, int Id_Account_Image);
    public record ModifyJelszo(string Hash);

    public record RegisterDto(string UserName, string Hash);
    public record LoginDto(string UserName, string Hash);

    public record AuthorDto(uint Id, string Name);
    public record CreateOrModifyAuthorDto(uint Id, string Name);

    public record PublisherDto(uint Id, string Name);
    public record CreateOrModifyPublisherDto(uint Id, string Name);

    public record SeriesDto(uint Id, string Name);
    public record CreateOrModifySeriesDto(uint Id, string Name);

    public record LoanHistoryDto(uint Id, int Book_Id, int User_Id, DateTime Date, DateTime Date_End, bool Returned, string Comment);
    public record CreateLoanHistoryDto(uint Id, uint Book_Id, uint User_Id, uint Deadline, bool Returned, string Comment);

    public record ModifyLoanHistoryDto(uint Id, uint Book_Id, uint User_Id, DateTime Date, DateTime Date_End, bool Returned, string Comment);

    public record BookDto(uint Id, int Warehouse_Num, DateTime Purchase_Date, uint Author_Id, string Title, int Series_Id, decimal Isbn_Num, decimal Szakjelzet, string Cutter_Jelzet, uint Publisher_Id, ushort Release_Date, decimal Price, string Comment, uint User_Id);
    public record CreateOrModifyKonyvDto(uint Id, uint Warehouse_Num, DateTime Purchase_Date, uint Author_Id, string Title, uint Series_Id, decimal Isbn_Num, decimal Szakjelzet, string Cutter_Jelzet, uint Publisher_Id, ushort Release_Date, decimal Price, string Comment, uint User_Id);

    public record RuleDto(int Id, string Name);
    public record CreateOrModifyRuleDto(int Id, string Name);

    public record AccountImgDto(int Id, string Name, string Path);
    public record CreateOrModifyAccountImgDto(int Id, string Name, string Path);

    public record EmailDto(string To, string Subject, string Body);

}
