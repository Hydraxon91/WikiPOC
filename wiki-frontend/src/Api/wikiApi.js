const BASE_URL = 'http://localhost:5000';

export const getWikiPages = async () => {
  const response = await fetch(`${BASE_URL}/api/WikiPages`);
  if (!response.ok) {
    throw new Error(`Failed to get WikiPages. Status: ${response.status}`);
  }
  const data = await response.json();
  return data;
};

export const getWikiPageTitles = async () => {
    const response = await fetch(`${BASE_URL}/api/WikiPages/GetTitles`);
    if (!response.ok) {
      throw new Error(`Failed to get WikiPage Titles. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };

export const getWikiPageById = async (id) => {
    const response = await fetch(`${BASE_URL}/api/WikiPages/GetById/${id}`);
    if (!response.ok) {
      throw new Error(`Failed to get WikiPage. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };

  export const getWikiPageByTitle = async (title) => {
    const response = await fetch(`${BASE_URL}/api/WikiPages/GetByTitle/${title}`);
    if (!response.ok) {
      throw new Error(`Failed to get WikiPage. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };

export const createWikiPage = async (newPage, token, decodedToken) => {
  console.log(decodedToken);
  var role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  var userName = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
  var url = role==="Admin"? `${BASE_URL}/api/WikiPages/admin` : `${BASE_URL}/api/WikiPages/user`;
  if (role !== "Admin") {
    newPage = { ...newPage, isNewPage: true, submittedBy: `${userName}`};
  }
  console.log('Request Data:', JSON.stringify(newPage));

  const response = await fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`,
    },
    body: JSON.stringify(newPage),
  });
  if (!response.ok) {
    throw new Error(`Failed to create WikiPage. Status: ${response.status}`);
  }
  const data = await response.json();
  return data;
};


export const updateWikiPage = async (id, updatedPage, token, decodedToken) => {
    var role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    var userName = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    var url = role==="Admin"? `${BASE_URL}/api/WikiPages/admin/${id}` : `${BASE_URL}/api/WikiPages/user`;
    var method = role==="Admin"? "PUT" : "POST";

    var postBody = updateWikiPage;

    if (role !== "Admin") {
      console.log("notadmin");
      postBody = { 
        ...updatedPage,
        wikiPage: updatedPage,
        wikiPageId: id,
        isNewPage: false,
        submittedBy: `${userName}`
      };
    }
    console.log('Request Data:', JSON.stringify(postBody));

    const response = await fetch(url, {
      method: method,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
      },
      body: JSON.stringify(postBody),
    });
    if (!response.ok) {
      throw new Error(`Failed to update WikiPage. Status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  };

export const deleteWikiPage = async (id, token) =>{
    const response = await fetch(`${BASE_URL}/api/WikiPages/admin/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
        },
      });

      if (!response.ok) {
        // Handle the error, you can throw an exception or return an error object
        throw new Error(`Failed to delete WikiPage. Status: ${response.status}`);
      }

      const data = await response.json();
      return data;
};

export const fetchCurrentStyles = async (setStyles) => {
  try {
    const response = await fetch(`${BASE_URL}/api/Style`); // Replace with your actual endpoint
    if (!response.ok) {
      throw new Error(`Failed to fetch default styles. Status: ${response.status}`);
    }
    const data = await response.json();
    setStyles(data);
  } catch (error) {
    console.error('Error fetching default styles:', error);
  }
};

export const updateStyles = async (newStyles) => {
  try {
    const response = await fetch(`${BASE_URL}/api/Style`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newStyles),
    });

    if (!response.ok) {
      throw new Error(`Failed to update styles. Status: ${response.status}`);
    }

    const updatedData = await response.json();
    // setStyles(updatedData);
  } catch (error) {
    console.error('Error updating styles:', error);
  }
};