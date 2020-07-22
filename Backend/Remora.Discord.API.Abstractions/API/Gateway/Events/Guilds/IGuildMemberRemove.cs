//
//  IGuildMemberRemove.cs
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

using Remora.Discord.API.Abstractions.Users;
using Remora.Discord.Core;

namespace Remora.Discord.API.Abstractions.Events
{
    /// <summary>
    /// Represents a user being removed from the guild.
    /// </summary>
    public interface IGuildMemberRemove
    {
        /// <summary>
        /// Gets the ID of the guild the member was in.
        /// </summary>
        Snowflake GuildID { get; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        IUser User { get; }
    }
}