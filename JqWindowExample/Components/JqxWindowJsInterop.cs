using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JqWindowExample.Components
{
    public class JqxWindowJsInterop : IDisposable
    {
        private readonly IJSRuntime jsRuntime;
        private string InstanceId;
        private DotNetObjectReference<JqxWindowJsInterop> _JqxWindowJsInteropReference;

        public JqxWindowJsInterop(IJSRuntime jsRuntime, string instanceId)
        {
            this.jsRuntime = jsRuntime;
            InstanceId = instanceId;
            _JqxWindowJsInteropReference = DotNetObjectReference.Create(this);
        }

        public event EventHandler JqxWindowInitialized;

        [JSInvokable]
        public async Task OnJqxWindowInitializedJs()
        {
            JqxWindowInitialized?.Invoke(this, new EventArgs());
        }

        public async Task Close()
        {
            await jsRuntime.InvokeVoidAsync(
               "jqxWindowComponent.close",
               InstanceId);
        }

        public async Task Open()
        {
            await jsRuntime.InvokeVoidAsync(
               "jqxWindowComponent.open",
               InstanceId);
        }

        public async ValueTask<string> Initialize()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return await jsRuntime.InvokeAsync<string>(
                "jqxWindowComponent.initialize",
                InstanceId,
                _JqxWindowJsInteropReference);
        }

        public void Dispose()
        {
            jsRuntime.InvokeAsync<string>(
                "jqxWindowComponent.dispose",
                InstanceId);
            _JqxWindowJsInteropReference?.Dispose();
        }
    }
}
