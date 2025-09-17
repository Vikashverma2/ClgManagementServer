using System;

namespace ClgManagementServer.Models.RequestModels;

public class UpdateCollegeRequest
{

    public string Name { get; set; }
    public string Location { get; set; }
    public int EstablishedYear { get; set; }
    public int ContactNumber { get; set; }
    public string Email { get; set; }

}
