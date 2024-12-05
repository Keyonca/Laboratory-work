public class Achievement
{
    public int ClubId { get; set; } // ID клуба
    public int GoldMedals { get; set; } // Золотые медали
    public int SilverMedals { get; set; } // Серебряные медали
    public int BronzeMedals { get; set; } // Бронзовые медали
    public int NationalCupWins { get; set; } // Выигранные национальные кубки
    public int NationalCupFinals { get; set; } // Проигранные финалы национальных кубков
    public int ChampionsLeagueWins { get; set; } // Выигранные Лиги Чемпионов
    public int ChampionsLeagueFinals { get; set; } // Проигранные финалы Лиги Чемпионов
    public int EuropaLeagueWins { get; set; } // Выигранные Лиги Европы
    public int EuropaLeagueFinals { get; set; } // Проигранные финалы Лиги Европы
    public int CupWinnersCupWins { get; set; } // Выигранные Кубки обладателей кубков
    public int CupWinnersCupFinals { get; set; } // Проигранные финалы Кубка обладателей кубков
    public int ConferenceLeagueWins { get; set; } // Выигранные Лиги Конференций
    public int ConferenceLeagueFinals { get; set; } // Проигранные финалы Лиги Конференций

    // Конструктор с параметрами
    public Achievement(int clubId, int goldMedals, int silverMedals, int bronzeMedals,
                        int nationalCupWins, int nationalCupFinals,
                        int championsLeagueWins, int championsLeagueFinals,
                        int europaLeagueWins, int europaLeagueFinals,
                        int cupWinnersCupWins, int cupWinnersCupFinals,
                        int conferenceLeagueWins, int conferenceLeagueFinals)
    {
        this.ClubId = clubId;
        this.GoldMedals = goldMedals;
        this.SilverMedals = silverMedals;
        this.BronzeMedals = bronzeMedals;
        this.NationalCupWins = nationalCupWins;
        this.NationalCupFinals = nationalCupFinals;
        this.ChampionsLeagueWins = championsLeagueWins;
        this.ChampionsLeagueFinals = championsLeagueFinals;
        this.EuropaLeagueWins = europaLeagueWins;
        this.EuropaLeagueFinals = europaLeagueFinals;
        this.CupWinnersCupWins = cupWinnersCupWins;
        this.CupWinnersCupFinals = cupWinnersCupFinals;
        this.ConferenceLeagueWins = conferenceLeagueWins;
        this.ConferenceLeagueFinals = conferenceLeagueFinals;
    }

    // Пустой конструктор
    public Achievement() { }

    // Перегрузка ToString
    public override string ToString()
    {
        return $"Club ID: {ClubId}, Gold: {GoldMedals}, Silver: {SilverMedals}, Bronze: {BronzeMedals}, " +
               $"National Cups (Wins: {NationalCupWins}, Finals: {NationalCupFinals}), " +
               $"Champions League (Wins: {ChampionsLeagueWins}, Finals: {ChampionsLeagueFinals}), " +
               $"Europa League (Wins: {EuropaLeagueWins}, Finals: {EuropaLeagueFinals}), " +
               $"Cup Winners' Cup (Wins: {CupWinnersCupWins}, Finals: {CupWinnersCupFinals}), " +
               $"Conference League (Wins: {ConferenceLeagueWins}, Finals: {ConferenceLeagueFinals})";
    }
}
