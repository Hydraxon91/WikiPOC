import { post } from './apiClient';

export const handleLoginSubmit = async (email: string, password: string) => {
  try {
    return await post<any>('/api/Auth/Login', { email, password });
  } catch (error: any) {
    try {
      return JSON.parse(error.message);
    } catch {
      throw error;
    }
  }
};

export const handleRegisterSubmit = async (email: string, username: string, password: string, role: string) => {
  try {
    return await post<any>('/api/Auth/Register', { email, username, password, role });
  } catch (error: any) {
    try {
      return JSON.parse(error.message);
    } catch {
      throw error;
    }
  }
};
