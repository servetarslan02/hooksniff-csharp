using System;
using System.Collections.Generic;
using Xunit;
using HookSniff;

namespace HookSniff.Tests
{
    public class TypedWebhookEventTests
    {
        [Fact]
        public void ParseEndpointCreatedData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.created",
                ["data"] = new Dictionary<string, object>
                {
                    ["appId"] = "a1",
                    ["endpointId"] = "e1",
                    ["appUid"] = "u1"
                },
                ["timestamp"] = "2026-05-19"
            });

            Assert.Equal("endpoint.created", eventObj.Event);
            var data = eventObj.ParseData<EndpointCreatedData>();
            Assert.Equal("a1", data.AppId);
            Assert.Equal("e1", data.EndpointId);
            Assert.Equal("u1", data.AppUid);
        }

        [Fact]
        public void ParseEndpointDisabledData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.disabled",
                ["data"] = new Dictionary<string, object>
                {
                    ["appId"] = "a1",
                    ["endpointId"] = "e1",
                    ["failSince"] = "2026-01",
                    ["trigger"] = "repeated-failure"
                },
                ["timestamp"] = ""
            });

            var data = eventObj.ParseData<EndpointDisabledData>();
            Assert.Equal("2026-01", data.FailSince);
            Assert.Equal("repeated-failure", data.Trigger);
        }

        [Fact]
        public void ParseMessageAttemptExhaustedData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "message.attempt.exhausted",
                ["data"] = new Dictionary<string, object>
                {
                    ["appId"] = "a1",
                    ["msgId"] = "m1",
                    ["lastAttempt"] = new Dictionary<string, object>
                    {
                        ["id"] = "att",
                        ["timestamp"] = "t",
                        ["responseStatusCode"] = 500
                    }
                },
                ["timestamp"] = ""
            });

            var data = eventObj.ParseData<MessageAttemptExhaustedData>();
            Assert.Equal("m1", data.MsgId);
            Assert.Equal(500, data.LastAttempt.ResponseStatusCode);
        }

        [Fact]
        public void BackwardCompatGet()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.created",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a1" },
                ["timestamp"] = "t"
            });

            Assert.Equal("a1", eventObj.Get("appId"));
            Assert.Equal("a1", eventObj["appId"]);
            Assert.Equal("endpoint.created", eventObj.EventType);
        }
    }
}
