import { get, post, put, del, postForm } from './apiClient';

export const getForumTopics = async () => get('/api/ForumTopic');

export const getForumTopicBySlug = async (slug: string) => get(`/api/ForumTopic/${slug}`);

export const createForumTopic = async (forumTopic: any, token: string) =>
  post('/api/ForumTopic', forumTopic, token);

export const updateForumTopic = async (forumTopic: any, token: string) =>
  put(`/api/ForumTopic/${forumTopic.id}`, forumTopic, token);

export const deleteForumTopic = async (forumTopic: any, token: string) =>
  del(`/api/ForumTopic/${forumTopic.id}`, token);

export const getForumPostTitles = async () => get('/api/ForumPost');

export const getForumPostById = async (id: string) => get(`/api/ForumPost/${id}`);

export const getForumPostBySlug = async (slug: string) => get(`/api/ForumPost/${slug}`);

export const createForumPost = async (forumPost: any, token: string) => {
  const formData = new FormData();
  formData.append('forumPostForm.PostTitle', forumPost.postTitle);
  formData.append('forumPostForm.Content', forumPost.content);
  formData.append('forumPostForm.ForumTopicId', forumPost.forumTopicId.toString());
  formData.append('forumPostForm.UserId', forumPost.userId.toString());
  formData.append('forumPostForm.UserName', forumPost.userName);
  return postForm('/api/ForumPost/postTopic', formData, token);
};

export const updateForumPost = async (forumPost: any, token: string) =>
  put(`/api/ForumPost/${forumPost.id}`, forumPost, token);

export const deleteForumPost = async (forumPost: any, token: string) =>
  del(`/api/ForumPost/${forumPost.id}`, token);

export const postForumComment = async (comment: any, token: string) => {
  const { wikiPageId, ...updatedComment } = comment;
  updatedComment.forumPostId = wikiPageId;
  return post('/api/ForumComment/comment/', updatedComment, token);
};

export const postEditedForumComment = async (commentId: string, editedComment: string, token: string) =>
  put(`/api/ForumComment/comment/${commentId}`, editedComment, token);
