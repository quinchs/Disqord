﻿using System.Threading.Tasks;
using Disqord.Gateway.Api;
using Disqord.Gateway.Api.Models;

namespace Disqord.Gateway.Default.Dispatcher
{
    public class GuildRoleUpdateHandler : Handler<GuildRoleUpdateJsonModel, RoleUpdatedEventArgs>
    {
        public override async Task<RoleUpdatedEventArgs> HandleDispatchAsync(IGatewayApiClient shard, GuildRoleUpdateJsonModel model)
        {
            CachedRole oldRole;
            IRole newRole;
            if (CacheProvider.TryGetRoles(model.GuildId, out var cache) && cache.TryGetValue(model.Role.Id, out var role))
            {
                newRole = role;
                oldRole = role?.Clone() as CachedRole;
                newRole.Update(model.Role);
            }
            else
            {
                oldRole = null;
                newRole = new TransientRole(Client, model.GuildId, model.Role);
            }

            return new RoleUpdatedEventArgs(model.GuildId, oldRole, newRole);
        }
    }
}
