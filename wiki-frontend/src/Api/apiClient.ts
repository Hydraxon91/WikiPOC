const BASE_URL = import.meta.env.VITE_API_URL;

const setTokenCookie = (token: string) => {
  const payload = JSON.parse(atob(token.split('.')[1]));
  const maxAge = Math.max(0, payload.exp - Math.floor(Date.now() / 1000));
  document.cookie = `jwt_token=${token}; path=/; max-age=${maxAge}; SameSite=Lax`;
};

class ApiError extends Error {
  status: number;
  constructor(message: string, status: number) {
    super(message);
    this.name = 'ApiError';
    this.status = status;
  }
}

async function request<T = any>(
  method: string,
  path: string,
  options?: { body?: any; token?: string; isFormData?: boolean }
): Promise<T> {
  const headers: Record<string, string> = {};

  if (!options?.isFormData) {
    headers['Content-Type'] = 'application/json';
  }

  if (options?.token) {
    headers['Authorization'] = `Bearer ${options.token}`;
  }

  const response = await fetch(`${BASE_URL}${path}`, {
    method,
    headers,
    body: options?.body
      ? options.isFormData
        ? options.body
        : JSON.stringify(options.body)
      : undefined,
  });

  if (response.status === 401) {
    if (options?.token) {
      const body = await response.json().catch(() => null);
      if (body?.reason === 'role_changed') {
        const refreshResponse = await fetch(`${BASE_URL}/api/Users/RefreshToken`, {
          method: 'POST',
          headers: { 'Authorization': `Bearer ${options.token}` },
        });
        if (refreshResponse.ok) {
          const { token } = await refreshResponse.json();
          setTokenCookie(token);
          headers['Authorization'] = `Bearer ${token}`;
          const retryResponse = await fetch(`${BASE_URL}${path}`, {
            method,
            headers,
            body: options?.body
              ? options.isFormData
                ? options.body
                : JSON.stringify(options.body)
              : undefined,
          });
          if (retryResponse.ok) {
            if (retryResponse.status === 204 || retryResponse.headers.get('content-length') === '0') {
              return undefined as T;
            }
            return retryResponse.json();
          }
        }
      }
    }
    document.cookie = 'jwt_token=; path=/; max-age=0';
    window.location.href = '/login';
    return undefined as T;
  }

  if (!response.ok) {
    const text = await response.text();
    throw new ApiError(text || response.statusText, response.status);
  }

  if (response.status === 204 || response.headers.get('content-length') === '0') {
    return undefined as T;
  }

  return response.json();
}

export function get<T = any>(path: string, token?: string) {
  return request<T>('GET', path, { token });
}

export function post<T = any>(path: string, body?: any, token?: string) {
  return request<T>('POST', path, { body, token });
}

export function put<T = any>(path: string, body?: any, token?: string) {
  return request<T>('PUT', path, { body, token });
}

export function del<T = any>(path: string, token?: string) {
  return request<T>('DELETE', path, { token });
}

export function postForm<T = any>(path: string, body: FormData, token?: string) {
  return request<T>('POST', path, { body, token, isFormData: true });
}

export function putForm<T = any>(path: string, body: FormData, token?: string) {
  return request<T>('PUT', path, { body, token, isFormData: true });
}

export function patch<T = any>(path: string, body?: any, token?: string) {
  return request<T>('PATCH', path, { body, token });
}
