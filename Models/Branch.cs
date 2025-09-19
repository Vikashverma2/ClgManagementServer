using System;

namespace ClgManagementServer.Models;

public class Branch
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CourseId { get; set; }
    public List<string> SubjectIds { get; set; }
    public string FeeStructureId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
