//
//  ServiceCollectionExtensions.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Caching.API;
using Remora.Discord.Caching.Responders;
using Remora.Discord.Caching.Services;
using Remora.Discord.Gateway.Extensions;

namespace Remora.Discord.Caching.Extensions
{
    /// <summary>
    /// Defines extension methods for the <see cref="IServiceCollection"/> interface.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds caching implementations of various API types, overriding the normally non-caching versions.
        /// </summary>
        /// <remarks>
        /// The cache uses a run-of-the-mill <see cref="IMemoryCache"/>. Cache entry options for any cached type can be
        /// configured using <see cref="IOptions{CacheSettings}"/>.
        /// </remarks>
        /// <param name="services">The services.</param>
        /// <returns>The services, with caching enabled.</returns>
        public static IServiceCollection AddDiscordCaching(this IServiceCollection services)
        {
            services
                .AddMemoryCache();

            services
                .AddScoped<CacheService>()
                .AddOptions<CacheSettings>();

            services
                .Replace(ServiceDescriptor.Scoped<IDiscordRestChannelAPI, CachingDiscordRestChannelAPI>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestEmojiAPI, CachingDiscordRestEmojiAPI>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestGuildAPI, CachingDiscordRestGuildAPI>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestInviteAPI, CachingDiscordRestInviteAPI>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestOAuth2API, CachingDiscordRestOAuth2API>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestTemplateAPI, CachingDiscordRestTemplateAPI>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestUserAPI, CachingDiscordRestUserAPI>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestVoiceAPI, CachingDiscordRestVoiceAPI>())
                .Replace(ServiceDescriptor.Scoped<IDiscordRestWebhookAPI, CachingDiscordRestWebhookAPI>());

            services
                .AddResponder<CacheResponder>();

            return services;
        }
    }
}