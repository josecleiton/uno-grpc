using System;
using System.Threading.Tasks;
using Uno.Domain.Dtos;
using Uno.Domain.Entities;

namespace Uno.Domain.Services {
  public interface IUnoService {
    Player Join(Guid playerId);
    MovimentResultDto Moviment(Guid playerId, Card card);
    UnoResultDto Uno(Guid playerId);
  }
}
