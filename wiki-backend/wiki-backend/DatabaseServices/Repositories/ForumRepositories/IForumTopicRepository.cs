﻿using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public interface IForumTopicRepository
{
    Task<IEnumerable<ForumTopic>> GetAllForumTopicsAsync();
    Task<ForumTopic> GetForumTopicBySlugAsync(string slug);
    Task AddForumTopicAsync(ForumTopic topic);
    Task UpdateForumTopicAsync(ForumTopic topic);
    Task DeleteForumTopicAsync(Guid id);
}