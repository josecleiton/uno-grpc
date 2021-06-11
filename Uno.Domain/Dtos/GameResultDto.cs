namespace Uno.Domain.Dtos {
  public class GameStateResultDto {
    public ShouldDrawDto? ShouldDraw { get; set; }
    public bool ShouldRotate { get; set; }
  }
}