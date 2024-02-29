const BASE_URL = 'http://localhost:5000';

export const getUserProfileById = async (username, setUser) => {
    const response = await fetch(`${BASE_URL}/api/UserProfile/GetByUserName/${username}`);
    if (!response.ok) {
      throw new Error(`Failed to get UserProfile for ${username}. Status: ${response.status}`);
    }
    const data = await response.json();
    setUser(data);
  };

  export const postComment = async (comment, token) => {
    const response = await fetch(`${BASE_URL}/api/UserComment/comment/`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
        },
        body: JSON.stringify(comment),
      });

      if (!response.ok) {
        // Handle the error, you can throw an exception or return an error object
        throw new Error(`Failed to delete WikiPage. Status: ${response.status}`);
      }

      const data = await response.json();
      return data;
  };