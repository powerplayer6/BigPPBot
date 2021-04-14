using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Entities;

namespace DiscordBot
{
    public class Program
    {
        public static int cnt = 0;
        public static string mes1, mes2;

        public static string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
        // ^ reads the file
        public static string line = lines[lines.Length - 1]; // takes the last row
        public static int epicCounter = int.Parse(line); // makes the last row the new counter number

        public static string[] tokens = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\token.txt");
        public static string token = tokens[tokens.Length - 1];

        public static DateTime starterTime = DateTime.Now;

        static InteractivityModule interactivity;
        static CommandsNextModule commands;
        static DiscordClient discord;
        public static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug,

            });
            discord.MessageCreated += async e =>
            {
                /*if (e.Message.Content.Length>=350 && e.Message.Author.IsBot==false) //copypasta
                {
                    await e.Message.RespondAsync(e.Message.Content);
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\pasta.txt", true))
                    {
                        file.WriteLine(e.Message.Content.ToString());
                        file.WriteLine();
                    }
                }*/

                /*if (cnt == 2 && e.Message.Author.IsBot == false)
                {
                    mes2 = e.Message.Content;
                    if (mes1 == mes2)
                    {
                        await e.Message.RespondAsync(mes2);
                        cnt = 0;
                    }
                    else
                    {
                        mes1 = e.Message.Content;
                        cnt = 1;
                    }
                }
                if (cnt == 1 && e.Message.Author.IsBot == false)
                {
                    mes2 = e.Message.Content;
                    if (mes2 == mes1)
                    {
                        cnt++;
                    }
                    else
                    {
                        mes1 = e.Message.Content;
                    }
                }
                if (cnt==0 && e.Message.Author.IsBot==false)
                {
                    mes1 = e.Message.Content;
                    cnt++;
                }*/

                switch (cnt) //the 4 horsemen
                {
                    case 0:
                        if (e.Message.Author.IsBot == false)
                        {
                            mes1 = e.Message.Content;
                            cnt++;
                        }
                        break;
                    case 1:
                        if (e.Message.Author.IsBot == false)
                        {
                            mes2 = e.Message.Content;
                            if (mes2 == mes1)
                            {
                                cnt++;
                            }
                            else
                            {
                                mes1 = e.Message.Content;
                            }
                        }
                        break;
                    case 2:
                        if (e.Message.Author.IsBot == false)
                        {
                            mes2 = e.Message.Content;
                            if (mes1 == mes2)
                            {
                                await e.Message.RespondAsync(mes2);
                                cnt = 0;
                            }
                            else
                            {
                                mes1 = e.Message.Content;
                                cnt = 1;
                            }
                        }
                        break;
                }

                if (e.Message.Content.StartsWith("FRANZ"))
                { await e.Message.RespondAsync("HANSDI"); }
                if (e.Message.Content.ToLower()=="bad bot")
                    { await e.Message.RespondAsync("no u"); }
                if (e.Message.Content.ToLower() == "good bot")
                { await e.Message.RespondAsync("yes me!"); }
                if (e.Message.Content.ToLower() == "p!counter") //epic counter summon
                {
                    await e.Message.RespondAsync("Messages containing the E-word: "+epicCounter);
                }
                if (e.Message.Content.ToLower().Contains("epic")) //counting the epics coolchamp
                {
                    epicCounter += 1;
                    await e.Message.CreateReactionAsync(DiscordEmoji.FromUnicode("😎"));
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
                    {
                        file.WriteLine(epicCounter.ToString()); //every time an epic is said it updates the counter file
                    }
                }
                if (e.Message.Content.ToLower() == "p!uptime") //uptime counter test
                {
                    TimeSpan taim = DateTime.Now - starterTime;
                    await e.Message.RespondAsync("Uptime: "+taim.Days+" days, "+taim.Hours+" hours, "+taim.Minutes+" minutes and "+taim.Seconds+" seconds");
                }
                if (e.Message.Content.ToLower().Contains("fuck pp"))
                {
                    await e.Message.RespondAsync("fuck you too");
                }
                };
            interactivity = discord.UseInteractivity(new InteractivityConfiguration
            {
                // default pagination behaviour to just ignore the reactions
                PaginationBehaviour = TimeoutBehaviour.Ignore,

                // default pagination timeout to 5 minutes
                PaginationTimeout = TimeSpan.FromMinutes(5),

                // default timeout for other actions to 2 minutes
                Timeout = TimeSpan.FromMinutes(2)
            });
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "p!",
                EnableDms = false
            });
            commands.RegisterCommands<MyCommands>();
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
