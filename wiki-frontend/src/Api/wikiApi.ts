import { get, post, put, del, postForm, putForm, patch } from './apiClient';

export const getWikiPages = async () => {
  return get('/api/WikiPages');
};

export const getWikiPageTitles = async () => {
    return get('/api/WikiPages/GetTitles');
  };

export const getWikiPageById = async (id) => {
    return get(`/api/WikiPages/GetById/${id}`);
  };

  export const getWikiPageByTitle = async (title) => {
    return get(`/api/WikiPages/GetByTitle/${encodeURIComponent(title)}`);
  };

export const createWikiPage = async (newPage, token, decodedToken, images) => {
  var role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  var userName = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
  var url = role==="Admin"? `/api/WikiPages/admin` : `/api/WikiPages/user`;

  const formData = new FormData();
  if (role !== "Admin") {
    formData.append('wikiPageWithImagesInputModel.IsNewPage', 'true')
    formData.append('wikiPageWithImagesInputModel.Approved', 'false')
    formData.append('wikiPageWithImagesInputModel.SubmittedBy', userName);
  }

  formData.append(`wikiPageWithImagesInputModel.Title`, newPage.title);
  formData.append(`wikiPageWithImagesInputModel.CategoryId`, newPage.category);
  formData.append(`wikiPageWithImagesInputModel.SiteSub`, newPage.siteSub);
  formData.append(`wikiPageWithImagesInputModel.RoleNote`, newPage.roleNote);
  formData.append(`wikiPageWithImagesInputModel.Content`, newPage.content);
  formData.append(`model.Paragraphs`, newPage.paragraphs);

  images.forEach((image, index) => {
    formData.append(`wikiPageWithImagesInputModel.Images[${index}].FileName`, image.name);
    formData.append(`wikiPageWithImagesInputModel.Images[${index}].DataURL`, image.dataURL);
  });

  return postForm(url, formData, token);
};


export const updateWikiPage = async (updatedPage, token, decodedToken, images) => {
    var role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    var userName = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    var url = role==="Admin"? `/api/WikiPages/admin/${updatedPage.id}` : `/api/WikiPages/userUpdate/${updatedPage.id}`;
    const formData = new FormData();
    if (role !== "Admin") {
      formData.append('wikiPageWithImagesInputModel.WikiPageId', updatedPage.id)
      formData.append('wikiPageWithImagesInputModel.SubmittedBy', userName);
    }
    formData.append(`wikiPageWithImagesInputModel.Title`, updatedPage.title);
    formData.append(`wikiPageWithImagesInputModel.CategoryId`, updatedPage.category);
    formData.append(`wikiPageWithImagesInputModel.SiteSub`, updatedPage.siteSub);
    formData.append(`wikiPageWithImagesInputModel.RoleNote`, updatedPage.roleNote);
    formData.append(`wikiPageWithImagesInputModel.Content`, updatedPage.content);
    formData.append(`model.Paragraphs`, updatedPage.paragraphs);
    images && images.forEach((image, index) => {
      formData.append(`wikiPageWithImagesInputModel.Images[${index}].FileName`, image.name);
      formData.append(`wikiPageWithImagesInputModel.Images[${index}].DataURL`, image.dataURL);
    });
    return putForm(url, formData, token);
  };

export const deleteWikiPage = async (id, token) =>{
    return del(`/api/WikiPages/admin/${id}`, token);
};

export const fetchCurrentStyles = async () => {
  return get('/api/Style');
};

export const updateStyles = async (newStyles, logoPictureFile, token) => {
  const formData = new FormData();
  formData.append('styleUpdateForm.StyleModel.WikiName', newStyles.wikiName);
  formData.append('styleUpdateForm.StyleModel.BodyColor', newStyles.bodyColor);
  formData.append('styleUpdateForm.StyleModel.ArticleRightColor', newStyles.articleRightColor);
  formData.append('styleUpdateForm.StyleModel.ArticleRightInnerColor', newStyles.articleRightInnerColor);
  formData.append('styleUpdateForm.StyleModel.ArticleColor', newStyles.articleColor);
  formData.append('styleUpdateForm.StyleModel.FooterListLinkTextColor', newStyles.footerListLinkTextColor);
  formData.append('styleUpdateForm.StyleModel.FooterListTextColor', newStyles.footerListTextColor);
  formData.append('styleUpdateForm.StyleModel.FontFamily', newStyles.fontFamily);
  formData.append('styleUpdateForm.LogoPictureFile', logoPictureFile);

  return putForm('/api/Style', formData, token);
};

export const getLogo = async(pictureString) => {
  try {
    if (pictureString.startsWith('blob:')) {
      return pictureString;
    }
    const response = await fetch(`${import.meta.env.VITE_API_URL}/api/Image/${pictureString}`);
    if (!response.ok) {
        throw new Error(`Failed to get Logo Picture ${pictureString}. Status: ${response.status}`);
    }

    const imageUrl = await response.blob();

    return imageUrl;
  } catch (error) {
      throw new Error(`Failed to fetch Logo picture: ${error.message}`);
  }
};

export const getNewPageTitles = async (token) => {
  return get('/api/WikiPages/GetSubmittedPageTitles', token);
};


export const getNewPageById = async (id, token) => {
  return get(`/api/WikiPages/GetSubmittedPageById/${id}`, token);
};

export const getUpdatePageTitles = async (token) => {
  return get('/api/WikiPages/GetSubmittedUpdates', token);
};


export const getUpdatePageById = async (id, token) => {
  return get(`/api/WikiPages/GetSubmittedUpdateById/${id}`, token);
};

export const acceptUserSubmittedUpdate = async (id, token) => {
  return patch(`/api/WikiPages/AdminAccept/${id}`, undefined, token);
};

export const acceptUserSubmittedPage = async (updatedPage, token) => {
  return post('/api/WikiPages/AdminAccept', updatedPage.userSubmittedWikiPage.id, token);
};

export const declineUserSubmittedWikiPage = async (id, token) =>{
  return del(`/api/WikiPages/AdminDecline/${id}`, token);
};

export const fetchCategories = async () => {
  return get('/api/Category');
};


export const addCategory = async (categoryName, token) => {
  return post('/api/Category', categoryName, token);
};

export const deleteCategory = async (categoryId, token) => {
  return del(`/api/Category/${categoryId}`, token);
};
