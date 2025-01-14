﻿namespace SharedModel.Payloads.Requests.Groups
{
    public record GetGroupsQueryDtoResponse
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
        public DateTime Created { get; init; }
        public DateTime Updated { get; init; }

    }
}
