﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenHTTP.Api.Http
{

    /// <summary>
    /// The type of protocol to use for the response.
    /// </summary>
    [Serializable]
    public enum ProtocolType
    {
        /// <summary>
        /// HTTP/1.0
        /// </summary>
        Http_1_0,
        /// <summary>
        /// HTTP/1.1
        /// </summary>
        Http_1_1
    }

}
