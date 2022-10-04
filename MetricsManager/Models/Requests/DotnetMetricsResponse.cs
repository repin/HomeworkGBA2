﻿using System.Text.Json.Serialization;

namespace MetricsManager.Models.Requests
{
    public class DotnetMetricsResponse
    {

        /// <summary>
        /// Идентификатор агента
        /// </summary>
        public int AgentId { get; set; }

        [JsonPropertyName("metrics")]
        public DotnetMetric[] Metrics { get; set; }
    }
}
