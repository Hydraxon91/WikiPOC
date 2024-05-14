const BASE_URL = process.env.REACT_APP_API_URL;

//Forum Topic methods
export const getForumTopics = async () => {
    const response = await fetch(`${BASE_URL}/api/ForumTopic`);
    if (!response.ok) {
      throw new Error(`Failed to get ForumTopics. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };

  export const getForumTopicBySlug = async (slug) => {
    const response = await fetch(`${BASE_URL}/api/ForumTopic/${slug}`);
    if (!response.ok) {
      throw new Error(`Failed to get ForumTopic. Status: ${response.status}`);
    }
    const data = await response.json();
    console.log(data);
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

//Forum Post methods
export const getForumPostTitles = async () => {
    const response = await fetch(`${BASE_URL}/api/ForumPost`);
    if (!response.ok) {
      throw new Error(`Failed to get forumPost titles. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };

  export const getForumPostById = async (id) => {
    const response = await fetch(`${BASE_URL}/api/ForumPost/${id}`);
    if (!response.ok) {
      throw new Error(`Failed to get forumPost. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };

  export const createForumPost = async (forumPost, token) => {
    const response = await fetch(`${BASE_URL}/api/ForumPost`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
      },
      body: JSON.stringify(forumPost),
    });
  
    if (!response.ok) {
      throw new Error(`Failed to create forumPost. Status: ${response.status}`);
    }
  
    return await response.json();
  };

  export const updateForumPost = async (forumPost, token) => {
    const response = await fetch(`${BASE_URL}/api/ForumPost/${forumPost.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
      },
      body: JSON.stringify(forumPost),
    });
  
    if (!response.ok) {
      throw new Error(`Failed to update forumPost. Status: ${response.status}`);
    }
  
    return await response.json();
  };

  export const deleteForumPost = async (forumPost, token) => {
   
    const response = await fetch(`${BASE_URL}/api/ForumPost/${forumPost.id}`, {
      method: 'DELETE',
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    });
  
    if (!response.ok) {
      throw new Error(`Failed to delete forumPost. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };