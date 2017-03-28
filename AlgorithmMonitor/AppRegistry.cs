﻿using GalaSoft.MvvmLight.Messaging;
using Monitor.Model;
using Monitor.Model.Charting.Mutations;
using Monitor.Model.Sessions;
using Monitor.Model.Statistics;
using StructureMap;

namespace Monitor
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            // Messaging
            For<IMessenger>().Use(Messenger.Default);

            // Model
            For<ISessionService>().Singleton().Use<SessionService>();
            For<IResultConverter>().Singleton().Use<ResultConverter>();
            For<IResultSerializer>().Singleton().Use<ResultSerializer>();

            For<IStatisticsFormatter>().Use<StatisticsFormatter>();
            For<IResultMutator>().Singleton().Use<BenchmarkResultMutator>(); // Implement pipeline pattern if more mutators will exist in the future.
        }
    }
}
