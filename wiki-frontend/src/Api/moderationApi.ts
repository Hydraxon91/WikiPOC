import { get, put, del } from './apiClient';

export interface FlaggedCommentItem {
  flag: {
    id: string;
    commentId: string;
    commentType: string;
    flaggedByUserProfileId: string;
    reason: string;
    createdAt: string;
    isResolved: boolean;
    flaggedByUserProfile: {
      id: string;
      userName: string;
      displayName: string;
    };
  };
  commentContent: string | null;
  commentAuthorName: string | null;
  commentAuthorProfileId: string | null;
}

export const getFlaggedComments = async (token: string) =>
  get<FlaggedCommentItem[]>('/api/Moderation/flagged-comments', token);

export const getFlaggedCommentsCount = async (token: string) =>
  get<{ count: number }>('/api/Moderation/flagged-comments/count', token);

export const resolveFlag = async (flagId: string, token: string) =>
  put(`/api/Moderation/flagged-comments/${flagId}/resolve`, undefined, token);

export const modDeleteComment = async (flagId: string, token: string) =>
  del(`/api/Moderation/flagged-comments/${flagId}/delete-comment`, token);
