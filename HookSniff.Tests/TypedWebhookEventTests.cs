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

        [Fact]
        public void ParseEndpointUpdatedData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.updated",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a1", ["endpointId"] = "e1" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointUpdatedData>();
            Assert.Equal("a1", data.AppId);
        }

        [Fact]
        public void ParseEndpointDeletedData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.deleted",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a1", ["endpointId"] = "e1" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointDeletedData>();
            Assert.Equal("e1", data.EndpointId);
        }

        [Fact]
        public void ParseEndpointEnabledData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.enabled",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a1", ["endpointId"] = "e1" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointEnabledData>();
            Assert.Equal("a1", data.AppId);
        }

        [Fact]
        public void ParseMessageAttemptFailingData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "message.atattempt.failing",
                ["data"] = new Dictionary<string, object>
                {
                    ["appId"] = "a1", ["msgId"] = "m1",
                    ["attempt"] = new Dictionary<string, object>
                    {
                        ["id"] = "att", ["timestamp"] = "t", ["responseStatusCode"] = 429
                    }
                },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<MessageAttemptFailingData>();
            Assert.Equal(429, data.Attempt.ResponseStatusCode);
        }

        [Fact]
        public void ParseMessageAttemptRecoveredData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "message.attempt.recovered",
                ["data"] = new Dictionary<string, object>
                {
                    ["appId"] = "a1", ["msgId"] = "m1",
                    ["attempt"] = new Dictionary<string, object>
                    {
                        ["id"] = "att", ["timestamp"] = "t", ["responseStatusCode"] = 200
                    }
                },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<MessageAttemptRecoveredData>();
            Assert.Equal(200, data.Attempt.ResponseStatusCode);
        }

        [Fact]
        public void EmptyData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.created",
                ["data"] = new Dictionary<string, object>(),
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointCreatedData>();
            Assert.Equal("", data.AppId);
        }

        [Fact]
        public void GetMissingKeyReturnsNull()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "test",
                ["data"] = new Dictionary<string, object> { ["x"] = 1 },
                ["timestamp"] = ""
            });
            Assert.Null(eventObj.Get("missing"));
        }

        [Fact]
        public void EventTypesAreCorrect()
        {
            var types = new[] { "endpoint.created", "endpoint.updated", "endpoint.deleted",
                                "endpoint.enabled", "endpoint.disabled" };
            foreach (var type in types)
            {
                var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
                {
                    ["event"] = type,
                    ["data"] = new Dictionary<string, object>(),
                    ["timestamp"] = ""
                });
                Assert.Equal(type, eventObj.Event);
            }
        }

        [Fact]
        public void UnicodeData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.created",
                ["data"] = new Dictionary<string, object> { ["appId"] = "ünïcödé", ["endpointId"] = "日本語" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointCreatedData>();
            Assert.Equal("ünïcödé", data.AppId);
            Assert.Equal("日本語", data.EndpointId);
        }

        [Fact]
        public void LargeData()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.created",
                ["data"] = new Dictionary<string, object> { ["appId"] = new string('a', 10000), ["endpointId"] = new string('e', 10000) },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointCreatedData>();
            Assert.Equal(10000, data.AppId.Length);
        }

        [Fact]
        public void SpecialCharacters()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.created",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a@b.c", ["endpointId"] = "e#1" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointCreatedData>();
            Assert.Equal("a@b.c", data.AppId);
        }

        [Fact]
        public void TriggerNone()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.disabled",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a", ["endpointId"] = "e", ["trigger"] = "none" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointDisabledData>();
            Assert.Equal("none", data.Trigger);
        }

        [Fact]
        public void TriggerFirstFailure()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.disabled",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a", ["endpointId"] = "e", ["trigger"] = "first-failure" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointDisabledData>();
            Assert.Equal("first-failure", data.Trigger);
        }

        [Fact]
        public void FailSince()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.disabled",
                ["data"] = new Dictionary<string, object> { ["appId"] = "a", ["endpointId"] = "e", ["failSince"] = "2026-01" },
                ["timestamp"] = ""
            });
            var data = eventObj.ParseData<EndpointDisabledData>();
            Assert.Equal("2026-01", data.FailSince);
        }

        [Fact]
        public void ToStringContainsEvent()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "endpoint.created",
                ["data"] = new Dictionary<string, object>(),
                ["timestamp"] = "2026-05-19"
            });
            Assert.Contains("endpoint.created", eventObj.ToString());
            Assert.Contains("2026-05-19", eventObj.ToString());
        }

        [Fact]
        public void IndexerAccess()
        {
            var eventObj = WebhookEvent.Parse(new Dictionary<string, object>
            {
                ["event"] = "test",
                ["data"] = new Dictionary<string, object> { ["x"] = 1 },
                ["timestamp"] = ""
            });
            Assert.Equal(1, eventObj["x"]);
        }
    }
}
