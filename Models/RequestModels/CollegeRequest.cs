using System;

namespace ClgManagementServer.Models.RequestModels;

public class UpdateCollegeRequest
{

    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int EstablishedYear { get; set; }
    public string ContactNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}
