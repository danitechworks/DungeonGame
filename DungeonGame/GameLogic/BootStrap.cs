using Autofac;
using DungeonGame.Battles;
using DungeonGame.Database;
using DungeonGame.Display;
using DungeonGame.Entities;
using DungeonGame.Monster;
using DungeonGame.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

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
            builder.RegisterType<BattleHandler>().SingleInstance();
            builder.RegisterType<GameSession>().SingleInstance();
            builder.RegisterType<BattleDisplay>().As<IBattleDisplay>().As<IDisplay>().SingleInstance();
            builder.RegisterType<DatabaseService>().As<IDataBaseService>().SingleInstance();

            var container = builder.Build();

            var app = container.Resolve<GameHandler>();
            app.RunApp();
        }
    }
}
