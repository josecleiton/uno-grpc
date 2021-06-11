using System;
using System.Threading.Tasks;
using Uno.Domain.Dtos;
using Uno.Domain.Entities;
using Uno.Domain.Services;

namespace Uno.Services {
  public class UnoService : IUnoService {
    private readonly RoomService _roomService;
    public UnoService(RoomService roomService) {
      _roomService = roomService;
    }
    public Player Join(Guid playerId) {
      return _roomService.AddPlayer(playerId);
    }

    public MovimentResultDto Moviment(Guid playerId, Card card) {
      throw new NotImplementedException();
    }

    public UnoResultDto Uno(Guid playerId) {
      throw new NotImplementedException();
    }
  }
}
