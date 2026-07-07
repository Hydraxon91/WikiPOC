import { get } from './apiClient';

export const searchWikiPages = async (query: string) => {
  return get(`/api/WikiPages/Search/${encodeURIComponent(query)}`);
};

export const searchForumTopics = async (query: string) => {
  return get(`/api/ForumTopic/Search/${encodeURIComponent(query)}`);
};

export const searchForumPosts = async (topicId: string, query: string) => {
  return get(`/api/ForumPost/Search/${encodeURIComponent(topicId)}/${encodeURIComponent(query)}`);
};
