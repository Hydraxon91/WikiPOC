import { get, post, put, del, postForm } from './apiClient';
import type { ForumTopic, ForumPost, ForumComment } from '../types/models';

export const getForumTopics = async () => get<ForumTopic[]>('/api/ForumTopic');

export const getForumTopicBySlug = async (slug: string) => get<ForumTopic>(`/api/ForumTopic/${slug}`);

export const createForumTopic = async (forumTopic: Partial<ForumTopic>, token: string) =>
  post<ForumTopic>('/api/ForumTopic', forumTopic, token);

export const updateForumTopic = async (forumTopic: ForumTopic, token: string) =>
  put<ForumTopic>(`/api/ForumTopic/${forumTopic.id}`, forumTopic, token);

export const deleteForumTopic = async (forumTopic: ForumTopic, token: string) =>
  del(`/api/ForumTopic/${forumTopic.id}`, token);

export const getForumPostTitles = async () => get<string[]>('/api/ForumPost');

export const getForumPostById = async (id: string) => get<ForumPost>(`/api/ForumPost/${id}`);

export const getForumPostBySlug = async (slug: string) => get<ForumPost>(`/api/ForumPost/${slug}`);

export const createForumPost = async (forumPost: Partial<ForumPost>, token: string) => {
  const formData = new FormData();
  formData.append('forumPostForm.PostTitle', forumPost.postTitle ?? '');
  formData.append('forumPostForm.Content', forumPost.content ?? '');
  formData.append('forumPostForm.ForumTopicId', forumPost.forumTopicId?.toString() ?? '');
  formData.append('forumPostForm.UserId', forumPost.userId?.toString() ?? '');
  formData.append('forumPostForm.UserName', forumPost.userName ?? '');
  return postForm<ForumPost>('/api/ForumPost/postTopic', formData, token);
};

export const updateForumPost = async (forumPost: ForumPost, token: string) =>
  put<ForumPost>(`/api/ForumPost/${forumPost.id}`, forumPost, token);

export const deleteForumPost = async (forumPost: ForumPost, token: string) =>
  del(`/api/ForumPost/${forumPost.id}`, token);

export const postForumComment = async (comment: Partial<ForumComment> & { wikiPageId?: string }, token: string) => {
  const { wikiPageId, ...updatedComment } = comment;
  updatedComment.forumPostId = wikiPageId;
  return post<ForumComment>('/api/ForumComment/comment/', updatedComment, token);
};

export const postEditedForumComment = async (commentId: string, editedComment: string, token: string) =>
  put(`/api/ForumComment/comment/${commentId}`, editedComment, token);
