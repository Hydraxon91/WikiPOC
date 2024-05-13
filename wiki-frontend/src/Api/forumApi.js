const BASE_URL = process.env.REACT_APP_API_URL;

export const getForumTopics = async () => {
    const response = await fetch(`${BASE_URL}/api/ForumTopic`);
    if (!response.ok) {
      throw new Error(`Failed to get WikiPages. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };


  export const createForumTopic = async (forumTopic, token) => {
    const response = await fetch(`${BASE_URL}/api/ForumTopic`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
      },
      body: JSON.stringify(forumTopic),
    });
  
    if (!response.ok) {
      throw new Error(`Failed to create ForumTopic. Status: ${response.status}`);
    }
  
    return await response.json();
  };

  export const updateForumTopic = async (forumTopic, token) => {
    const response = await fetch(`${BASE_URL}/api/ForumTopic/${forumTopic.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
      },
      body: JSON.stringify(forumTopic),
    });
  
    if (!response.ok) {
      throw new Error(`Failed to update ForumTopic. Status: ${response.status}`);
    }
  
    return await response.json();
  };

  export const deleteForumTopic = async (forumTopic, token) => {
   
    const response = await fetch(`${BASE_URL}/api/ForumTopic/${forumTopic.id}`, {
      method: 'DELETE',
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    });
  
    if (!response.ok) {
      throw new Error(`Failed to delete ForumTopic. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };