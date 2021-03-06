﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using RestBus.AspNet.Server;
using RestBus.Common;
using System;

namespace Microsoft.AspNetCore.Builder
{

    public static class ServerExtensions
    {

        /// <summary>
        /// Configures the RestBus server to use a specified subscriber
        /// </summary>
        /// <param name="app">The Application builder</param>
        /// <param name="subscriber">The RestBus subscriber</param>
        public static void ConfigureRestBusServer(this IApplicationBuilder app, IRestBusSubscriber subscriber)
        {
            if (app == null) throw new ArgumentNullException("app");
            if (subscriber == null) throw new ArgumentNullException("subscriber");

            var feature = app.ServerFeatures.Get<IServerInformation>();
            if (feature == null) return; //Application isn't running RestBus server so return

            var serverInfo = feature as ServerInformation;
            if (serverInfo != null)
            {
                serverInfo.Subscriber = subscriber;
            }
        }

    }

}