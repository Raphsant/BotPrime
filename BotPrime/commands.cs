using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DsharpBot
{
    public class Commands
    {
        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
        }

        [Command("random")]
        public async Task Random(CommandContext ctx, int min, int max)
        {
            var rnd = new Random();
            await ctx.RespondAsync($"🎲 Your random number is: {rnd.Next(min, max)}");
        }

        [Command("zavala")]
        public async Task Zavala(CommandContext ctx)
        {
            await ctx.RespondAsync($"Whether we wanted it or not, we've stepped into a war with the Cabal on Mars. So let's get to taking out their command, one by one. Valus Ta'aurc. From what I can gather he commands the Siege Dancers from an Imperial Land Tank outside of Rubicon. He's well protected, but with the right team, we can punch through those defenses, take this beast out, and break their grip on Freehold");
        }

        [Command("Hi")]
        public async Task greeting(CommandContext ctx, DiscordMember member)
        {
            await ctx.TriggerTypingAsync();
            var emoji = DiscordEmoji.FromName(ctx.Client, ":wave:");
            await ctx.RespondAsync($"{emoji} Hello, {member.Mention}!");
        }

        [Command("sayhi")]
        public async Task intro(CommandContext ctx)
        {
            await ctx.RespondAsync($"Hello, my name is M30W Prime and I'm going to protect you all from meanie people from the internet, please be polite and Love Anna");
        }

        [Command("bitch")]
        public async Task bitch(CommandContext ctx, DiscordMember member)
        {
            await ctx.RespondAsync($"Fuck you {member.Mention}");
            await ctx.Message.DeleteAsync();
        }

        [Command("hug")]
        public async Task hug(CommandContext ctx, DiscordMember member)
        {
            List<string> lines = File.ReadLines(@"C:\Users\Rafsa\source\repos\BotPrime\BotPrime\assets\gifs.txt").ToList();
            var rnd = new Random();
            int index = rnd.Next(lines.Count);
            var Embed = new DiscordEmbedBuilder();
            Embed.WithDescription($"{ctx.User.Mention} hugs {member.Mention} ♥ ");
            Embed.WithColor(DiscordColor.Purple);
            Embed.WithFooter("HUGGING SEQUENCE INITIATED");
            Embed.WithImageUrl(lines[index]);
            await ctx.Message.RespondAsync(embed: Embed.Build());
        }

        [Command("send")]
        public async Task send(CommandContext ctx)
        {
            ulong id = 380422480440852482;            
            var channel = ctx.Guild.GetChannel(id);
            string message;
            message = ctx.Message.Content.ToString();
            string msg = message.Remove(0, 6);
            await ctx.Client.SendMessageAsync(channel, msg, false, null);
        }

        [Command("update")]

        public async Task update(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            var Embed = new DiscordEmbedBuilder();
            string PatchNotes = File.ReadAllText(@"C:\Users\Rafsa\source\repos\BotPrime\BotPrime\assets\update.txt").ToString();
            Embed.WithColor(DiscordColor.Cyan);
            Embed.WithDescription(PatchNotes);
            await ctx.Message.RespondAsync(embed: Embed.Build());

        }
    }
}