﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.Auth;
using Pinch.SDK.WebSample.Helpers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class BaseController : Controller
    {
        private readonly PinchSettings _settings;

        public BaseController(IOptions<PinchSettings> options)
        {
            _settings = options.Value;
        }

        protected PinchApi GetApi()
        {
            var token = HttpContext.Session.GetObjectFromJson<GetAccessTokenFromCodeResponse>("AccessToken");

            if (token != null)
            {
                return new PinchApi(_settings.MerchantId, _settings.SecretKey, new PinchApiOptions(){
                    IsLive = false,
                    BaseUri = _settings.BaseUri,
                    AuthUri = _settings.AuthUri,
                    ApplicationId = _settings.ApplicationId,
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefreshToken,
                });
            }

            return new PinchApi(_settings.MerchantId, _settings.SecretKey, new PinchApiOptions()
            {
                IsLive = false,
                BaseUri = _settings.BaseUri,
                AuthUri = _settings.AuthUri
            });
        }
    }
}