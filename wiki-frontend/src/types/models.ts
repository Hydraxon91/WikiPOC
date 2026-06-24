export interface WikiPage {
  id: string;
  title?: string;
  content?: string;
  siteSub?: string;
  roleNote?: string;
  categoryId?: string;
  category?: Category;
  paragraphs?: Paragraph[];
  postDate?: string;
  lastUpdateDate?: string;
}

export interface UserSubmittedWikiPage extends WikiPage {
  submittedBy?: string;
  approved?: boolean;
  isNewPage?: boolean;
  wikiPageId?: string;
}

export interface Category {
  id: string;
  categoryName?: string;
  wikiPages?: WikiPage[];
}

export interface Paragraph {
  id: string;
  title?: string;
  content?: string;
  wikiPageId?: string;
}

export interface ForumTopic {
  id: string;
  title?: string;
  description?: string;
  slug?: string;
  order?: number;
  forumPosts?: ForumPost[];
}

export interface ForumPost {
  id: string;
  postTitle?: string;
  content?: string;
  slug?: string;
  postDate?: string;
  forumTopicId?: string;
  forumTopic?: ForumTopic;
  userId?: string;
  userName?: string;
  user?: UserProfile;
  comments?: ForumComment[];
}

export interface ForumComment {
  id: string;
  content?: string;
  userProfileId?: string;
  userProfile?: UserProfile;
  forumPostId?: string;
  postDate?: string;
  isEdited?: boolean;
}

export interface UserProfile {
  id: string;
  userName?: string;
  displayName?: string;
  profilePicture?: string;
  userId?: string;
}

export interface UserComment {
  id: string;
  content?: string;
  userProfileId?: string;
  userProfile?: UserProfile;
  wikiPageId?: string;
  postDate?: string;
  isEdited?: boolean;
}

export interface StyleModel {
  id?: number;
  logo?: string;
  wikiName?: string;
  bodyColor?: string;
  articleColor?: string;
  articleRightColor?: string;
  articleRightInnerColor?: string;
  footerListLinkTextColor?: string;
  footerListTextColor?: string;
  fontFamily?: string;
}
