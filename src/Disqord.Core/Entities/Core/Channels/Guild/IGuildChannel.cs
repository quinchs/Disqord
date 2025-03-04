﻿using System.Collections.Generic;

namespace Disqord
{
    /// <summary>
    ///     Represents a guild channel.
    /// </summary>
    public interface IGuildChannel : IChannel, IGuildEntity, IMentionable
    {
        /// <summary>
        ///     Gets the position within the guild of this channel.
        /// </summary>
        int Position { get; }

        /// <summary>
        ///     Gets the permission overwrites of this channel.
        /// </summary>
        IReadOnlyList<IOverwrite> Overwrites { get; }
    }
}
