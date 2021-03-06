﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteamKit2;

namespace SteamBotLite
{
    class AdminModule : BaseModule
    {
       
        VBot SteamBot;

        public AdminModule(VBot bot, Dictionary<string, object> config) : base(bot, config)
        {
            SteamBot = bot;
            adminCommands.Add(new Reboot(bot, this));
            adminCommands.Add(new Rename(bot, this));
        }

        public override string getPersistentData()
        {
               return "";
        }

        public override void loadPersistentData()
        {
            throw new NotImplementedException();
        }


        private class Reboot : BaseCommand
        {
            // Command to query if a server is active
            AdminModule module;
            
            public Reboot(VBot bot, AdminModule module) : base(bot, "!Reboot")
            {
                this.module = module;
            }
            protected override string exec(SteamID sender, string param)
            {
                module.SteamBot.Reboot();
                return "Rebooted";
            }

        }
        private class Rename : BaseCommand
        {
            // Command to query if a server is active
            AdminModule module;

            public Rename(VBot bot, AdminModule module) : base(bot, "!Rename")
            {
                this.module = module;
            }
            protected override string exec(SteamID sender, string param)
            {
                string[] command = param.Split(new char[] { ' ' }, 2);
                if (command.Length > 1)
                {
                    module.SteamBot.Username = command[1];
                    return "Renamed";
                }
                return "There was an error with that name";
            }

        }
    }
}