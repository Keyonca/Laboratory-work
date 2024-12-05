public class Club
{
    public int ClubId { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }

    // Конструктор с параметрами
    public Club(int clubId, string name, int countryId)
    {
        this.ClubId = clubId;
        this.Name = name;
        this.CountryId = countryId;
    }

    // Пустой конструктор
    public Club() { }

    // Перегрузка ToString
    public override string ToString() => $"Club ID: {ClubId}, Name: {Name}, Country ID: {CountryId}";
}
