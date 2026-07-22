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
  isDeleted?: boolean;
}

export interface UserProfile {
  id: string;
  userName?: string;
  displayName?: string;
  profilePicture?: string;
  userId?: string;
  joinDate?: string;
  postCount?: number;
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
  isActive?: boolean;
  isSystemPreset?: boolean;
  userId?: string;
  interfaceEra?: string;
  themeName?: string;
  logo?: string;
  wikiName?: string;
  bodyColor?: string;
  articleColor?: string;
  articleRightColor?: string;
  articleRightInnerColor?: string;
  footerListLinkTextColor?: string;
  footerListTextColor?: string;
  fontFamily?: string;
  glassBgOpacity?: number;
  glassBlurRadius?: number;
  glassBorderReflection?: number;
  bgMeshGradient?: string;
  borderRadius?: string;
  borderStyle?: string;
  glassGlowIntensity?: number;
  bubbleCountDesktop?: number;
  bubbleCountMobile?: number;
  glassBaseColor?: string;
  glassBlob1Color?: string;
  glassBlob1ColorOuter?: string;
  glassBlob2Color?: string;
  glassBlob2ColorOuter?: string;
  glassBlob3Color?: string;
  glassBlob3ColorOuter?: string;
  glassBlob3Opacity?: number;
}
