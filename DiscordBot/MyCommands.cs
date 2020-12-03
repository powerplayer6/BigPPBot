using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;

namespace DiscordBot
{
    class MyCommands
    {
        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
            var interactivity = ctx.Client.GetInteractivityModule();
            var msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id == ctx.User.Id && xm.Content.ToLower() == "how are you?", TimeSpan.FromMinutes(1));
            if (msg != null)
                await ctx.RespondAsync($"I'm fine, thank you!");
        }

        [Command("buddy")]
        public async Task Retard(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://cdn.memegenerator.es/imagenes/memes/full/30/33/30338243.jpg");
        }

        [Command("fan")]
        public async Task Fan(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://i.imgur.com/XxUT2VR.png");
        }

        [Command("retard")]
        public async Task Buddy(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://i.kym-cdn.com/entries/icons/mobile/000/025/993/ogbr.jpg");
        }

        [Command("okay")]
        [Aliases("ok")]
        public async Task Okay(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://cdn.discordapp.com/avatars/513697905266393102/c497a828768ef32ea0b7eb896e41a03e.png?size=4096");
        }

        [Command("dummkopf")]
        public async Task Dummkopf(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://i.redd.it/dtdnkprbijz11.jpg");
        }

        [Command("size")]
        public async Task Size(CommandContext ctx)
        {
            Random rnd = new Random();
            if (ctx.User.Id == 268001225977364480)
            {
                await ctx.RespondAsync($"{ctx.User.Mention}, your size is 10000.");
            }
            else
            {
                int i = rnd.Next(1, 11);
                await ctx.RespondAsync($"{ctx.User.Mention}, your size is " + i + ".");
            }
        }

        [Command("user")]
        public async Task User(CommandContext ctx)
        {
            await ctx.RespondAsync("ID: "+ctx.User.Id+"\nAvatar: "+ctx.User.AvatarUrl+"\nPresence: "+ctx.User.Presence.Game.Name);
            await ctx.RespondAsync("Guid ID: " + ctx.Guild.Id);
        }

        [Command("say")]
        public async Task Say(CommandContext ctx)
        {
            await ctx.RespondAsync(ctx.Message.Content.Remove(0, 5));
        }

        [Command("dots")]
        public async Task Dots(CommandContext ctx)
        {
            if (ctx.Guild.Id == 511179434070507520)
            {
                await ctx.RespondAsync(".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n." +
                "\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n." +
                "\n.\n.\n.\n.\n.\n.\n");
            }
            else await ctx.RespondAsync("How 'bout no?");
        }

        [Command("rps")]
        public async Task Rps(CommandContext ctx)
        {
            string userinput = ctx.Message.Content.Remove(0, 6).ToLower();
            if (userinput != "rock" && userinput != "paper" && userinput != "scissors")
            {
                await ctx.RespondAsync("only rock paper scissors asshole");
            }
            else
            {
                string botinput="";
                string outcome="";
                Random rnd = new Random();
                int i = rnd.Next(1, 4);
                if (i == 1)
                {
                    botinput = "rock";
                }
                else if (i == 2)
                {
                    botinput = "paper";
                }
                else if (i == 3)
                {
                    botinput = "scissors";
                }
                //checking the outcome of the RPS
                if (userinput==botinput)
                {
                    outcome = "tie";
                }
                else
                {
                    //user rock
                    if (userinput=="rock"&&botinput=="scissors")
                    {
                        outcome = "win";
                    }
                    if (userinput == "rock" && botinput == "paper")
                    {
                        outcome = "lose";
                    }
                    //user paper
                    if (userinput == "paper" && botinput == "rock")
                    {
                        outcome = "win";
                    }
                    if (userinput == "paper" && botinput == "scissors")
                    {
                        outcome = "lose";
                    }
                    //user scissors
                    if (userinput == "scissors" && botinput == "paper")
                    {
                        outcome = "win";
                    }
                    if (userinput == "scissors" && botinput == "rock")
                    {
                        outcome = "lose";
                    }
                }
                await ctx.RespondAsync("I use "+botinput+"! You "+outcome+"!");
            }
        }

        [Command("flip")]
        public async Task Flip(CommandContext ctx)
        {
            Random rnd = new Random();
            int i = rnd.Next(1,101);
            string result = "";
            if (i<50)
            {
                result = "heads";
            }
            else if (i>51)
            {
                result = "tails";
            }
            else if (i==51)
            {
                result = "it fell on the side";
            }
            await ctx.RespondAsync("The result was "+result+"!");
        }

        [Command("iq")]
        public async Task IQ(CommandContext ctx)
        {
            Random rnd = new Random((int)ctx.User.Id);
            int i = rnd.Next(1, 51);
            await ctx.RespondAsync("Your IQ is "+i+ " 😔");
        }

        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            Random rnd = new Random();
            int i = rnd.Next(50, 150);
            i = i + 10000;
            await Task.Delay(10000);
            await ctx.RespondAsync("Your ping is: "+i+"ms");
        }

        [Command("gaming")]
        public async Task Gaming(CommandContext ctx)
        {
            await ctx.RespondAsync("Epic");
        }

        [Command("fate")]
        public async Task Fate(CommandContext ctx)
        {
            await ctx.RespondAsync("https://cdn.discordapp.com/attachments/534308826133037096/663388556252676108/received_955561124809380.jpeg");
        }

        [Command("madlibs")]
        [Description("vayn1, vayn2, avid1, golga10, pp1")]
        public async Task Madlibs(CommandContext ctx)
        {
            Random rnd = new Random();
            //vayn1
            string[] a = { "direction of", "framing in", "symbolism of", "shot-framing of", "storyboard of" };
            string[] b = { "this scene", "this shot", "this anime", "OreGairu", "Monogatari", "Gridman 9" };
            string[] c = { "spectacular", "stellar", "amazing", "brilliant" };
            string[] d = { "marvel", "wonder", "great example" };
            string[] e = { "artist integrity", "modern anime", "the staff's talent" };

            //vayn2
            string[] a1 = { "my balls to be crushed", "my balls to be stepped on", "to be stepped on", "to be dominated", "to be looked down upon", "to be trashtalked", "to be murdered just a little" };
            string[] b1 = {"a sadistic anime girl", "the helltaker girls", "Lulu", "Akane", "Setsuko", "Elaina"};

            //avid1
            string[] a2 = { "bogan", "stupid", "bitch", "dumb", "pussy", "absolute" };
            string[] b2 = { " little", " lidl", " ranga", " didgeridoo", "-ass", " bitch", " smoothbrained", " even more stupid than my water bottle" };
            string[] c2 = { " cunt", " bitch", " dimwit", " bobo", " piece of shit"};
            string[] d2 = { "you explode in front of your chickens and your guts go flying everywhere and they peck at your remains only to develop an appetite for human flesh and eat your whole family and everyone you love", "parrots peck your eyebalsl out", "your car crashes and you die and your friends have to throw your body in some roadside ditch", "you become human bacon", "all your teeth rot and they fall out", "possums chew your thumbs off in your sleep tonight", "termites eat you alive while you sleep goodnight", "you choke on eggs" };

            //golga10
            string[] a3 = { "bonk", "bink", "bonkus", "bungus", "bing", "bling", "bünk", "book", "bukt", "bücher" };
            string[] b3 = { "wank", "bonk", "wonkus", "wungus", "wong", "blang", "würm", "worm", "🪱" };
            string[] c3 = { "cowards", "fools", "disappointments", "idots", "idiots", "dumdums", "absolute fools", "bitches", "verzögert", "sluts" };

            //pp1
            string[] a4 = { "read Catulus", "watch Saiki", "watch Persona 3", "play Persona 3", "play Persona 5", "watch Sora no Woto", "read Bakarina novels", "play Genshin" };
            string[] b4 = { "rartard", "absolute coward", "actual retard", "internetdude", "coward", "bastard" };

            if (ctx.Message.Content.ToLower().Remove(0, 10)=="vayn1") //vayn symbolism
            {
                await ctx.RespondAsync("Vayn: The " + a[rnd.Next(0, a.Length)] + " " + b[rnd.Next(0, b.Length)] + " was " + c[rnd.Next(0, c.Length)] + ", truly a " + d[rnd.Next(0, d.Length)] + " of " + e[rnd.Next(0, e.Length)]+ " 🙏");
            }
            if (ctx.Message.Content.ToLower().Remove(0, 10) == "vayn2") //vayn femdom
            {
                await ctx.RespondAsync("Vayn: I want " + a1[rnd.Next(0, a1.Length)]+ " by "+ b1[rnd.Next(0, b1.Length)] + " 😔");
            }
            if (ctx.Message.Content.ToLower().Remove(0, 10) == "avid1") //avid
            {
                await ctx.RespondAsync("Avid: You " + a2[rnd.Next(0, a2.Length)] + b2[rnd.Next(0, b2.Length)] + c2[rnd.Next(0, c2.Length)] + " I hope " + d2[rnd.Next(0, d2.Length)]);
            }
            if (ctx.Message.Content.ToLower().Remove(0, 10) == "golga10") //golga
            {
                await ctx.RespondAsync("Golga: Read " + a3[rnd.Next(0, a3.Length)] + b3[rnd.Next(0, b3.Length)] + " you " + c3[rnd.Next(0, c3.Length)]);
            }

            if (ctx.Message.Content.ToLower().Remove(0, 10) == "pp1") //pp
            {
                await ctx.RespondAsync("PP: ID, "+ a4[rnd.Next(0, a4.Length)]+" you "+ b4[rnd.Next(0, b4.Length)]);
            }
        }
    }
}
