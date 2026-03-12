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
            builder.RegisterType<RandomGenerator>().SingleInstance();
            builder.RegisterType<MonsterHandler>().SingleInstance();
            builder.RegisterType<PlayerDisplay>().As<IDisplay>().SingleInstance();
            container = builder.Build();
            var app = container.Resolve<GameHandler>();
            app.RunApp();
        }
    }
}
