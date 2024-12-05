public class Country
{
    public int CountryId { get; set; }
    public string Name { get; set; }

    // Конструктор с параметрами
    public Country(int countryId, string name)
    {
        this.CountryId = countryId;
        this.Name = name;
    }

    // Пустой конструктор
    public Country() { }

    // Перегрузка ToString
    public override string ToString() => $"Country ID: {CountryId}, Name: {Name}";
}
