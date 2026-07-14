import { post } from './apiClient';

export const handleLoginSubmit = async (email: string, password: string) => {
  try {
    return await post<unknown>('/api/Auth/Login', { email, password });
  } catch (error: unknown) {
    if (error instanceof Error) {
      try {
        return JSON.parse(error.message);
      } catch {
        throw error;
      }
    }
    throw error;
  }
};

export const handleRegisterSubmit = async (email: string, username: string, password: string, role: string) => {
  try {
    return await post<unknown>('/api/Auth/Register', { email, username, password, role });
  } catch (error: unknown) {
    if (error instanceof Error) {
      try {
        return JSON.parse(error.message);
      } catch {
        throw error;
      }
    }
    throw error;
  }
};
