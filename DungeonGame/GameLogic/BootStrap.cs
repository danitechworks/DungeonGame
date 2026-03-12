using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using DungeonGame.Entities;
using DungeonGame.Display;
using DungeonGame.Utilities;
using DungeonGame.Monster;

namespace DungeonGame.GameLogic
{
    public class BootStrap
    {
        private static Autofac.IContainer container;

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PlayerHandler>().SingleInstance();
            builder.RegisterType<CharacterHandler>().SingleInstance();
            builder.RegisterType<MonsterHandler>().SingleInstance();
            builder.RegisterType<PlayerDisplay>().As<IPlayerDisplay>().As<IDisplay>().SingleInstance();
            builder.RegisterType<CharacterDisplay>().As<ICharacterDisplay>().As<IDisplay>().SingleInstance();
            builder.RegisterType<MonsterDisplay>().As<IMonsterDisplay>().As<IDisplay>().SingleInstance();
            builder.RegisterType<GameHandler>().SingleInstance();

            var container = builder.Build();

            var app = container.Resolve<GameHandler>();
            app.RunApp();
        }
    }
}
