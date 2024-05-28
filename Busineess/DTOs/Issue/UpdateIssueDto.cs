﻿using Entities.Enums;

namespace Busineess.DTOs.Issue
{
    public class UpdateIssueDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoryPoint { get; set; }
        public int ProjectId { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
    }
}
