import { get, post, put, del, postForm } from './apiClient';
import type { ForumTopic, ForumPost, ForumComment } from '../types/models';

export const getForumTopics = async () => get<ForumTopic[]>('/api/ForumTopic');

export const getForumTopicBySlug = async (slug: string) => get<ForumTopic>(`/api/ForumTopic/${slug}`);

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
