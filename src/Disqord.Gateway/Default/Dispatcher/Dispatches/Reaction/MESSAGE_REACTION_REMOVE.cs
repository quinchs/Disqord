﻿using System.Threading.Tasks;
using Disqord.Gateway.Api;
using Disqord.Gateway.Api.Models;

namespace Disqord.Gateway.Default.Dispatcher
{
    public class MessageReactionRemoveHandler : Handler<MessageReactionRemoveJsonModel, ReactionRemovedEventArgs>
    {
        public override ValueTask<ReactionRemovedEventArgs> HandleDispatchAsync(IGatewayApiClient shard, MessageReactionRemoveJsonModel model)
        {
            CachedUserMessage message;
            if (CacheProvider.TryGetMessages(model.ChannelId, out var messageCache))
            {
                message = messageCache.GetValueOrDefault(model.MessageId);
                message?.Update(model);
            }
            else
            {
                message = null;
            }

            var e = new ReactionRemovedEventArgs(model.GuildId.GetValueOrNullable(), model.UserId, model.ChannelId, model.MessageId, message, Emoji.Create(model.Emoji));
            return new(e);
        }
    }
}
