//
//  Markdown.Timestamps.cs
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

using System;

namespace Remora.Discord.API.Format
{
    public partial class Markdown
    {
        /// <summary>
        /// Formats a Unix timestamp value into Discord Markdown Timestamp.
        /// </summary>
        /// <param name="unixTimestamp">The Unix timestamp to format.</param>
        /// <param name="timestampStyle">The style to format into.</param>
        /// <returns>
        /// A Discord markdown-formatted Timestamp string.
        /// </returns>
        public static string Timestamp(long unixTimestamp, TimestampStyle timestampStyle = TimestampStyle.Default)
            => $"<t:{unixTimestamp}:{TimestampStyleToCode(timestampStyle)}>";

        /// <summary>
        /// Formats a Unix timestamp value into Discord Markdown Timestamp.
        /// </summary>
        /// <param name="dateTimeOffset">The time to format.</param>
        /// <param name="timestampStyle">The style to format into.</param>
        /// <returns>
        /// A Discord markdown-formatted Timestamp string.
        /// </returns>
        public static string Timestamp(DateTimeOffset dateTimeOffset, TimestampStyle timestampStyle = TimestampStyle.Default)
            => Timestamp(dateTimeOffset.ToUnixTimeSeconds(), timestampStyle);

        /// <summary>
        /// Formats a Unix timestamp value into Discord Markdown Timestamp.
        /// </summary>
        /// <param name="dateTime">The time to format.</param>
        /// <param name="timestampStyle">The style to format into.</param>
        /// <returns>
        /// A Discord markdown-formatted Timestamp string.
        /// </returns>
        public static string Timestamp(DateTime dateTime, TimestampStyle timestampStyle = TimestampStyle.Default)
            => Timestamp(((DateTimeOffset)dateTime).ToUnixTimeSeconds(), timestampStyle);

        private static char TimestampStyleToCode(TimestampStyle timestampStyle)
        {
            return timestampStyle switch
            {
                TimestampStyle.ShortTime => 'f',
                TimestampStyle.LongTime => 'F',
                TimestampStyle.ShortDate => 'd',
                TimestampStyle.LongDate => 'D',
                TimestampStyle.ShortDateTime => 'f',
                TimestampStyle.LongDateTime => 'F',
                TimestampStyle.RelativeTime => 'R',
                _ => TimestampStyleToCode(TimestampStyle.Default)
            };
        }
    }
}
