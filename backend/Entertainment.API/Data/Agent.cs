using System;
using System.Collections.Generic;

namespace Entertainment.API.Data;

public partial class Agent
{
    public int AgentId { get; set; }

    public string? AgtFirstName { get; set; }

    public string? AgtLastName { get; set; }

    public string? AgtStreetAddress { get; set; }

    public string? AgtCity { get; set; }

    public string? AgtState { get; set; }

    public string? AgtZipCode { get; set; }

    public string? AgtPhoneNumber { get; set; }

    public string? DateHired { get; set; }

    public decimal? Salary { get; set; }

    public decimal? CommissionRate { get; set; }
}
