﻿using Disqord.Models;

namespace Disqord
{
    /// <summary>
    ///     Represents a guild's widget settings.
    /// </summary>
    public interface IGuildWidget : IGuildEntity, IPossibleChannelEntity, IJsonUpdatable<GuildWidgetJsonModel>
    {
        /// <summary>
        ///     Gets whether the widget is enabled.
        /// </summary>
        bool IsEnabled { get; }
    }
}
