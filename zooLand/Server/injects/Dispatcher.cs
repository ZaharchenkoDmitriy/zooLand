﻿using System;
using System.Net;

namespace ConsoleApplication1.server
{
    public abstract class Dispatcher
    {
        public abstract Responce getResponce(HttpListenerRequest request);       
    }
}