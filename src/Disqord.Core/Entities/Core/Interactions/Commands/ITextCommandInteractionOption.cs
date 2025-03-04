﻿using System.Collections.Generic;

namespace Disqord
{
    /// <summary>
    ///     Represents a provided value for a text command option.
    /// </summary>
    public interface ITextCommandInteractionOption
    {
        /// <summary>
        ///     Gets the type of this option.
        /// </summary>
        ApplicationCommandOptionType Type { get; }

        /// <summary>
        ///     Gets the value of this option.
        /// </summary>
        object Value { get; }

        /// <summary>
        ///     Gets the nested options of this option.
        /// </summary>
        IReadOnlyDictionary<string, ITextCommandInteractionOption> Options { get; }
    }
}
