using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DsharpBot
{
    internal class Program
    {
        private static DiscordClient discord;
        private static CommandsNextModule commands;
        private static DiscordBan ban;
        private static DiscordGuild guild;
        private static DiscordUser user;
        private static DiscordMember member;
        private static DiscordChannel channel;
        private static DiscordMessage message;
        private static DiscordRole role;
        private static DiscordRole guest;
        static DiscordGame game;
        
        

        private static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "token.txt"),
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug,
                
            });
           
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().Contains("nigga"))
                    member = (DiscordMember)e.Author;
                await member.BanAsync();
            };
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().Contains("tranny"))
                    member = (DiscordMember)e.Author;
                await member.BanAsync();
            };
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().Contains("retarded"))
                    member = (DiscordMember)e.Author;
                await member.BanAsync();
            };
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().Contains("faggot"))
                    member = (DiscordMember)e.Author;
                await member.BanAsync();
            };
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().Contains(";;bitch"))
                    await message.DeleteAsync();
            };

            discord.GuildMemberAdded += async e =>
            {
                guest = e.Guild.GetRole(609506619532771329);
                await e.Member.GrantRoleAsync(guest);
            };           

            discord.Ready += async e =>
            {
                var game = new DiscordGame();
                game.Name = "Killing Sooper";
                await discord.UpdateStatusAsync(game: game);
                
            };

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = ";;"
            });

            var builder = new DiscordEmbedBuilder();

            builder.WithImageUrl("https://titles.trackercdn.com/destiny/common/destiny2_content/screenshots/3588934839.jpg");

            commands.RegisterCommands<Commands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);


            
        }
    }
}