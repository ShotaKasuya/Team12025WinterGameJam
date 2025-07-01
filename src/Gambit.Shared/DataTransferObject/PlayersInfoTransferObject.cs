using System.Collections.Generic;
using System.Linq;
using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    [MessagePackObject]
    public readonly struct PlayersInfoTransferObject
    {
        public PlayersInfoTransferObject
        (
            IEnumerable<PlayerIdTransferObject> playerIds
        )
        {
            PlayerIds = playerIds.ToArray();
        }

        [Key(0)]
        public readonly PlayerIdTransferObject[] PlayerIds;
    }
}