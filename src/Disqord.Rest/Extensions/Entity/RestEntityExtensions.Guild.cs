﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Disqord.AuditLogs;
using Disqord.Rest.Pagination;

namespace Disqord.Rest
{
    public static partial class RestEntityExtensions
    {
        public static IPagedEnumerable<IAuditLog> EnumerateAuditLogs(this IGuild guild, int limit, Snowflake? actorId = null, Snowflake? startFromId = null, IRestRequestOptions options = null)
            => guild.EnumerateAuditLogs<IAuditLog>(limit, actorId, startFromId, options);

        public static IPagedEnumerable<TAuditLog> EnumerateAuditLogs<TAuditLog>(this IGuild guild, int limit, Snowflake? actorId = null, Snowflake? startFromId = null, IRestRequestOptions options = null)
            where TAuditLog : IAuditLog
        {
            var client = guild.GetRestClient();
            return client.EnumerateAuditLogs<TAuditLog>(guild.Id, limit, actorId, startFromId, options);
        }

        public static Task<IReadOnlyList<IAuditLog>> FetchAuditLogsAsync(this IGuild guild, int limit = 100, Snowflake? actorId = null, Snowflake? startFromId = null, IRestRequestOptions options = null)
            => guild.FetchAuditLogsAsync<IAuditLog>(limit, actorId, startFromId, options);

        public static Task<IReadOnlyList<TAuditLog>> FetchAuditLogsAsync<TAuditLog>(this IGuild guild, int limit = 100, Snowflake? actorId = null, Snowflake? startFromId = null, IRestRequestOptions options = null)
            where TAuditLog : IAuditLog
        {
            var client = guild.GetRestClient();
            return client.FetchAuditLogsAsync<TAuditLog>(guild.Id, limit, actorId, startFromId, options);
        }

        public static Task LeaveAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.LeaveGuildAsync(guild.Id, options);
        }

        public static Task<IGuild> ModifyAsync(this IGuild guild, Action<ModifyGuildActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyGuildAsync(guild.Id, action, options);
        }

        public static Task DeleteAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.DeleteGuildAsync(guild.Id, options);
        }

        public static Task<IReadOnlyList<IGuildChannel>> FetchChannelsAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchChannelsAsync(guild.Id, options);
        }

        public static Task<ITextChannel> CreateTextChannelAsync(this IGuild guild, string name, Action<CreateTextChannelActionProperties> action = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateTextChannelAsync(guild.Id, name, action, options);
        }

        public static Task<IVoiceChannel> CreateVoiceChannelAsync(this IGuild guild, string name, Action<CreateVoiceChannelActionProperties> action = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateVoiceChannelAsync(guild.Id, name, action, options);
        }

        public static Task<ICategoryChannel> CreateCategoryChannelAsync(this IGuild guild, string name, Action<CreateCategoryChannelActionProperties> action = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateCategoryChannelAsync(guild.Id, name, action, options);
        }

        public static Task ReorderChannelsAsync(this IGuild guild, IReadOnlyDictionary<Snowflake, int> positions, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ReorderChannelsAsync(guild.Id, positions, options);
        }

        public static Task<IReadOnlyList<IThreadChannel>> FetchActiveThreadsAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchActiveThreadsAsync(guild.Id, options);
        }

        public static Task<IMember> FetchMemberAsync(this IGuild guild, Snowflake memberId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchMemberAsync(guild.Id, memberId, options);
        }

        public static IPagedEnumerable<IMember> EnumerateMembers(this IGuild guild, int limit, Snowflake? startFromId = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.EnumerateMembers(guild.Id, limit, startFromId, options);
        }

        public static Task<IReadOnlyList<IMember>> FetchMembersAsync(this IGuild guild, int limit = 1000, Snowflake? startFromId = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchMembersAsync(guild.Id, limit, startFromId, options);
        }

        public static Task<IReadOnlyList<IMember>> SearchMembersAsync(this IGuild guild, string query, int limit = 1000, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.SearchMembersAsync(guild.Id, query, limit, options);
        }

        public static Task SetCurrentMemberNickAsync(this IGuild guild, string nick, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.SetCurrentMemberNickAsync(guild.Id, nick, options);
        }

        public static Task<IMember> ModifyMemberAsync(this IGuild guild, Snowflake memberId, Action<ModifyMemberActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyMemberAsync(guild.Id, memberId, action, options);
        }

        public static Task GrantRoleAsync(this IGuild guild, Snowflake memberId, Snowflake roleId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.GrantRoleAsync(guild.Id, memberId, roleId, options);
        }

        public static Task RevokeRoleAsync(this IGuild guild, Snowflake memberId, Snowflake roleId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.RevokeRoleAsync(guild.Id, memberId, roleId, options);
        }

        public static Task KickMemberAsync(this IGuild guild, Snowflake memberId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.KickMemberAsync(guild.Id, memberId, options);
        }

        public static Task<IReadOnlyList<IBan>> FetchBansAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchBansAsync(guild.Id, options);
        }

        public static Task<IBan> FetchBanAsync(this IGuild guild, Snowflake userId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchBanAsync(guild.Id, userId, options);
        }

        public static Task CreateBanAsync(this IGuild guild, Snowflake userId, string reason = null, int? deleteMessageDays = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateBanAsync(guild.Id, userId, reason, deleteMessageDays, options);
        }

        public static Task DeleteBanAsync(this IGuild guild, Snowflake userId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.DeleteBanAsync(guild.Id, userId, options);
        }

        public static Task<IReadOnlyList<IRole>> FetchRolesAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchRolesAsync(guild.Id, options);
        }

        public static Task<IRole> CreateRoleAsync(this IGuild guild, Action<CreateRoleActionProperties> action = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateRoleAsync(guild.Id, action, options);
        }

        public static Task<IReadOnlyList<IRole>> ReorderRolesAsync(this IGuild guild, IReadOnlyDictionary<Snowflake, int> positions, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ReorderRolesAsync(guild.Id, positions, options);
        }

        public static Task<IRole> ModifyRoleAsync(this IGuild guild, Snowflake roleId, Action<ModifyRoleActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyRoleAsync(guild.Id, roleId, action, options);
        }

        public static Task DeleteRoleAsync(this IGuild guild, Snowflake roleId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.DeleteRoleAsync(guild.Id, roleId, options);
        }

        public static Task<int> FetchPruneGuildCountAsync(this IGuild guild, int days, IEnumerable<Snowflake> roleIds = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchPruneGuildCountAsync(guild.Id, days, roleIds, options);
        }

        public static Task<int?> PruneGuildAsync(this IGuild guild, int days, bool computePruneCount = true, IEnumerable<Snowflake> roleIds = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.PruneGuildAsync(guild.Id, days, computePruneCount, roleIds, options);
        }

        public static Task<IReadOnlyList<IGuildVoiceRegion>> FetchVoiceRegionsAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildVoiceRegionsAsync(guild.Id, options);
        }

        public static Task<IReadOnlyList<IInvite>> FetchInvitesAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildInvitesAsync(guild.Id, options);
        }

        public static Task<IReadOnlyList<IIntegration>> FetchIntegrationsAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchIntegrationsAsync(guild.Id, options);
        }

        public static Task DeleteIntegrationAsync(this IGuild guild, Snowflake integrationId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.DeleteIntegrationAsync(guild.Id, integrationId, options);
        }

        public static Task<IGuildWidget> FetchWidgetAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchWidgetAsync(guild.Id, options);
        }

        public static Task<IGuildWidget> ModifyWidgetAsync(this IGuild guild, Action<ModifyWidgetActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyWidgetAsync(guild.Id, action, options);
        }

        public static Task<IVanityInvite> FetchVanityInviteAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchVanityInviteAsync(guild.Id, options);
        }

        public static Task<IGuildPreview> FetchPreviewAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchPreviewAsync(guild.Id, options);
        }

        /*
         * Emoji
         */
        public static Task<IReadOnlyList<IGuildEmoji>> FetchEmojisAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildEmojisAsync(guild.Id, options);
        }

        public static Task<IGuildEmoji> FetchEmojiAsync(this IGuild guild, Snowflake emojiId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildEmojiAsync(guild.Id, emojiId, options);
        }

        public static Task<IGuildEmoji> CreateEmojiAsync(this IGuild guild, string name, Stream image, Action<CreateGuildEmojiActionProperties> action = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateGuildEmojiAsync(guild.Id, name, image, action, options);
        }

        public static Task<IGuildEmoji> ModifyEmojiAsync(this IGuild guild, Snowflake emojiId, Action<ModifyGuildEmojiActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyGuildEmojiAsync(guild.Id, emojiId, action, options);
        }

        public static Task DeleteEmojiAsync(this IGuild guild, Snowflake emojiId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.DeleteGuildEmojiAsync(guild.Id, emojiId, options);
        }

        /*
         * Webhook
         */
        public static Task<IReadOnlyList<IWebhook>> FetchWebhooksAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildWebhooksAsync(guild.Id, options);
        }

        /*
         * Template
         */
        public static Task<IReadOnlyList<IGuildTemplate>> FetchTemplatesAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchTemplatesAsync(guild.Id, options);
        }

        public static Task<IGuildTemplate> CreateTemplateAsync(this IGuild guild, string name, Action<CreateTemplateActionProperties> action = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateTemplateAsync(guild.Id, name, action, options);
        }

        public static Task<IGuildTemplate> SynchronizeTemplateAsync(this IGuild guild, string templateCode, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.SynchronizeTemplateAsync(guild.Id, templateCode, options);
        }

        public static Task<IGuildTemplate> ModifyTemplateAsync(this IGuild guild, string templateCode, Action<ModifyTemplateActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyTemplateAsync(guild.Id, templateCode, action, options);
        }

        public static Task<IGuildTemplate> DeleteTemplateAsync(this IGuild guild, string templateCode, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.DeleteTemplateAsync(guild.Id, templateCode, options);
        }

        /*
         * Sticker
         */
        public static Task<IReadOnlyList<IGuildSticker>> FetchStickersAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildStickersAsync(guild.Id, options);
        }

        public static Task<IGuildSticker> FetchStickerAsync(this IGuild guild, Snowflake stickerId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildStickerAsync(guild.Id, stickerId, options);
        }

        public static Task<IGuildSticker> CreateStickerAsync(this IGuild guild, string name, string tags, Stream image, StickerFormatType imageType, string description = null, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.CreateGuildStickerAsync(guild.Id, name, tags, image, imageType, description, options);
        }

        public static Task<IGuildSticker> ModifyStickerAsync(this IGuild guild, Snowflake stickerId, Action<ModifyGuildStickerActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyGuildStickerAsync(guild.Id, stickerId, action, options);
        }

        public static Task DeleteStickerAsync(this IGuild guild, Snowflake stickerId, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.DeleteGuildStickerAsync(guild.Id, stickerId, options);
        }

        /*
         * Voice State
        */
        public static Task ModifyCurrentMemberVoiceStateAsync(this IGuild guild, Snowflake channelId, Action<ModifyCurrentMemberVoiceStateActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyCurrentMemberVoiceStateAsync(guild.Id, channelId, action, options);
        }

        public static Task ModifyMemberVoiceStateAsync(this IGuild guild, Snowflake memberId, Snowflake channelId, Action<ModifyMemberVoiceStateActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyMemberVoiceStateAsync(guild.Id, memberId, channelId, action, options);
        }

        /*
         * Welcome Screen
         */
        public static Task<IGuildWelcomeScreen> FetchWelcomeScreenAsync(this IGuild guild, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.FetchGuildWelcomeScreenAsync(guild.Id, options);
        }

        public static Task<IGuildWelcomeScreen> ModifyWelcomeScreenAsync(this IGuild guild, Action<ModifyWelcomeScreenActionProperties> action, IRestRequestOptions options = null)
        {
            var client = guild.GetRestClient();
            return client.ModifyGuildWelcomeScreenAsync(guild.Id, action, options);
        }
    }
}
