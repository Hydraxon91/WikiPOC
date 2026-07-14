import { get, post, put, putForm } from './apiClient';
import type { UserProfile, UserComment } from '../types/models';

export const getUserProfileByUsername = async (username: string, setUser: (user: UserProfile) => void) => {
  const data = await get<UserProfile>(`/api/UserProfile/GetByUserName/${encodeURIComponent(username)}`);
  setUser(data);
};

export const postComment = async (comment: Partial<UserComment>, token: string) => {
  return post<UserComment>('/api/UserComment/comment/', comment, token);
};

export const postEditedComment = async (commentId: string, editedComment: string, token: string) => {
  return put(`/api/UserComment/comment/${commentId}`, editedComment, token);
};

export const postProfileEdit = async (profile: { id: string; displayName: string; userName: string }, profilePictureFile: File | null | undefined, token: string) => {
  const formData = new FormData();
  formData.append('userUpdateForm.UserProfile.Id', profile.id);
  formData.append('userUpdateForm.UserProfile.DisplayName', profile.displayName);
  formData.append('userUpdateForm.UserProfile.UserName', profile.userName);
  formData.append('userUpdateForm.ProfilePictureFile', profilePictureFile);
  return putForm(`/api/UserProfile/UpdateProfile/${profile.id}`, formData, token);
};

export const getProfilePicture = async (pictureString: string) => {
  const BASE_URL = import.meta.env.VITE_API_URL;
  const response = await fetch(`${BASE_URL}/api/Image/profile/${pictureString}`);
  if (!response.ok) {
    throw new Error(`Failed to get Profile Picture ${pictureString}. Status: ${response.status}`);
  }
  return response.blob();
};
