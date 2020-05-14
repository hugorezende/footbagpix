namespace FootbagPix.Models
{
    public interface IScoreModel
    {
        int ComboCounter { get; set; }
        int CurrentScore { get; set; }
        int MaxComboCount { get; set; }
    }
}