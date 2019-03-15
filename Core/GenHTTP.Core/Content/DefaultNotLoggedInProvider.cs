﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GenHTTP.Api.Abstraction;
using GenHTTP.Api.Abstraction.Elements;
using GenHTTP.Api.Content;
using GenHTTP.Api.Http;
using GenHTTP.Api.SessionManagement;

namespace GenHTTP.Core.Content
{

    /// <summary>
    /// Shows a default login page.
    /// </summary>
    public class DefaultNotLoggedInProvider : IContentProvider
    {
        private Server _Server;

        /// <summary>
        /// Create a new default not logged in provider.
        /// </summary>
        /// <param name="server">The related server</param>
        public DefaultNotLoggedInProvider(Server server)
        {
            _Server = server;
        }

        /// <summary>
        /// Will return false.
        /// </summary>
        public bool RequiresLogin
        {
            get { return false; }
        }

        /// <summary>
        /// Will always return true.
        /// </summary>
        /// <param name="request">The request to check responsibility for</param>
        /// <param name="info">Information about the user's session</param>
        /// <returns>true</returns>
        public bool IsResponsible(IHttpRequest request, AuthorizationInfo info)
        {
            return true;
        }

        /// <summary>
        /// Generate a simple login mask.
        /// </summary>
        /// <param name="request">The request to handle</param>
        /// <param name="response">The response to write to</param>
        /// <param name="info">The session information</param>
        public void HandleRequest(IHttpRequest request, IHttpResponse response, AuthorizationInfo info)
        {
            var page = _Server.NewPage();

            page.Title = "Login required";

            Form frm = new Form(".");

            frm.AddText("Username: ");
            frm.AddInput(InputType.Text, "Username", "Username");

            frm.AddNewLine(DocumentType.XHtml_1_1_Strict);

            frm.AddText("Password: ");
            frm.AddInput(InputType.Password, "Password", "Password");

            frm.AddNewLine(DocumentType.XHtml_1_1_Strict, 2);

            frm.AddButton("Action", "Login", "Login", ButtonType.Submit);

            page.Value = frm.Serialize(DocumentType.XHtml_1_1_Strict);

            response.Header.Type = ResponseType.Unauthorized;

            response.Send(page);
        }

    }

}
