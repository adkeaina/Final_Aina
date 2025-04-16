using System;
using System.Collections.Generic;

namespace Entertainment.API.Data;

public partial class Engagement
{
    public int EngagementNumber { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? StartTime { get; set; }

    public string? StopTime { get; set; }

    public decimal? ContractPrice { get; set; }

    public int? CustomerId { get; set; }

    public int? AgentId { get; set; }

    public int? EntertainerId { get; set; }
}
