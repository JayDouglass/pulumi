// Copyright 2016-2020, Pulumi Corporation

using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Pulumirpc;

namespace Pulumi
{
    internal class GrpcEngine : IEngine
    {
        private readonly Engine.EngineClient _engine;

        public GrpcEngine(string engine)
        {
            // maxRpcMessageSize raises the gRPC Max Message size from `4194304` (4mb) to `419430400` (400mb)
            var maxRpcMessageSize = 400 * 1024 * 1024;
            var grpcChannelOptions = new GrpcChannelOptions { MaxReceiveMessageSize = maxRpcMessageSize, Credentials = ChannelCredentials.Insecure };
            this._engine = new Engine.EngineClient(GrpcChannel.ForAddress(new Uri($"http://{engine}"), grpcChannelOptions));
        }
        
        public async Task LogAsync(LogRequest request)
            => await this._engine.LogAsync(request);
        
        public async Task<SetRootResourceResponse> SetRootResourceAsync(SetRootResourceRequest request)
            => await this._engine.SetRootResourceAsync(request);

        public async Task<GetRootResourceResponse> GetRootResourceAsync(GetRootResourceRequest request)
            => await this._engine.GetRootResourceAsync(request);
    }
}
